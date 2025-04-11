@icon("icon.svg")
extends Node3D


signal give_damage(obj:Node3D, damage:float, point:Vector3)
signal update_ammo(magazine:int, inventory_ammo:int, ammo_type:String)

#region Export vars
@export var inventory : Dictionary = {
	"weapons" = [[0,-1], [1,-1], [2,-1], [3,-1], [4,-1], [5,-1]],
	"ammo" = {
		"none" = 0,
		"9mm" = 0,
		"rifle" = 0,
		"shell" = 0,
	},
}
@export var melee_damage : float = 100
@export var show_muzzle_smoke : bool = true
@export_group("Camera")
@export var camera : Camera3D
@export var recoil : bool = true
@export_subgroup("Recoil configs")
## What to rotate on X axis with recoil (most of the time the camera)
@export var node_recoil_x : Node3D
## What to rotate on Y axis with recoil (most of the time the character)
@export var node_recoil_y : Node3D
@export var recoil_x_clamp_max : float = 1.4
@export var recoil_x_clamp_min : float = -1.4
@export_subgroup("")
@export var sway : bool = false
@export_subgroup("Sway configs")
@export var sway_look_sens : float = 50.0
@export var sway_move_sens : float = 80.0
@export_subgroup("")
@export var shake : bool = true
@export_subgroup("Shake configs")
@export var shake_strength : float = 0.5
@export var shake_decay : float = 3.0
@export var shake_max_offset := Vector2(.01, .01)
@export var shake_max_roll : float = 0.01
@export_group("Multipliers")
@export var delta_multiplier : float = 1.0
@export var damage_multiplier : float = 1.0
@export_group("Actions")
@export var action_fire : String = "shoot"
@export var action_reload : String = "reload"
@export var action_melee : String = "melee"
@export var action_ads : String = "aim"
@export var action_next_weapon : String = "switch_weapon"
@export var action_previous_weapon : String = "switch_weapon"
#endregion

# Plugin scene nodes
var FireRayCast : RayCast3D
var MeleeRayCast : RayCast3D

var bulletholeScene : PackedScene = preload("decals/bullethole/bullethole.tscn")
var scratchScene : PackedScene = preload("decals/scratch/scratch.tscn")
var muzzleFlashScene : PackedScene = preload("muzzleflash/MuzzleFlash.tscn")
var muzzleSmokeScene : PackedScene = preload("muzzlesmoke/MuzzleSmoke.tscn")
var bulletScene : PackedScene = preload("res://scenes/modules/weapons/bullet.tscn")

var weapons : Array[PackedScene] = [
	preload("fps-knife/fps-knife.tscn"),
	preload("fps-c19/fps-c19.tscn"),
	preload("fps-smg45/fps-smg45.tscn"),
	preload("fps-ak/fps-ak.tscn"),
	preload("fps-lmg63/fps-lmg63.tscn"),
	preload("fps-sawnoff/fps-sawnoff.tscn"),
]
var weapon_index : int # current weapon index
var weapon_change : int # weapon to take after hide weapon
var weapon : Node3D
var animation : AnimationTree
var state_machine : AnimationNodeStateMachinePlayback
var muzzlePoint : Node3D
var is_reloading : bool = false

var start_pos : Vector3
var ads_pos : Vector3
var ads : bool = false

var max_magazine : int
var magazine : int

var sway_rotation_target : Vector3
var recoiling : bool = false
var recoil_target : Vector2
var shake_current : float = 0.0

# Add nodes and settings to plugin scene
func _enter_tree() -> void:

	MeleeRayCast = RayCast3D.new()
	MeleeRayCast.target_position = Vector3(0,0,1)
	add_child(MeleeRayCast)
	
	FireRayCast = RayCast3D.new()
	FireRayCast.target_position = Vector3(0,0,0)
	add_child(FireRayCast)


func _ready() -> void:

	if sway and camera:
		top_level = true
	take_weapon(0)

	


func update_inventory():
	inventory["weapons"][weapon_index][1] = magazine
	update_ammo.emit(magazine, inventory["ammo"][weapon.get_meta("ammo_type", "none")], weapon.get_meta("ammo_type", "none"))

func aim(toggle:bool=true) -> void:
	if toggle and (state_machine.get_current_node() != "idle" and state_machine.get_current_node() != "fire"):
		return
	if !ads and toggle:
		ads = true
	elif ads:
		ads = false

func add_decal(pos:Vector3, normal:Vector3, decal:PackedScene, father:Node3D) -> void:
	var bullethole : Decal = decal.instantiate()
	father.add_child(bullethole)
	bullethole.global_position = pos
	if normal != Vector3.UP:
		bullethole.look_at(pos + Vector3.UP, normal)
	bullethole.rotate(normal, randf_range(0, 2*PI))

func shoot_bullet() -> void:
	if muzzlePoint:
		var bullet = bulletScene.instantiate()
		get_tree().root.add_child(bullet)
		bullet.global_transform = muzzlePoint.global_transform
		var direction = muzzlePoint.global_transform.basis.z
		bullet.set_initial_direction(direction)

func check_damage(raycast:RayCast3D, damage:float, melee:bool=true) -> void:
	if raycast.is_colliding():
		var collider = raycast.get_collider()
		if collider.has_method("take_damage"):
			collider.take_damage(damage)
			var collision_point = raycast.get_collision_point()
			var collision_normal = raycast.get_collision_normal()
			add_decal(collision_point, collision_normal, bulletholeScene, collider)

func muzzle_flash():
	if muzzlePoint:
		var muzzleFlash : Node3D = muzzleFlashScene.instantiate()
		muzzleFlash.scale /= weapon.scale
		muzzlePoint.add_child(muzzleFlash)

func muzzle_smoke():
	if muzzlePoint and show_muzzle_smoke:
		var muzzleSmoke : Node3D = muzzleSmokeScene.instantiate()
		muzzleSmoke.scale /= weapon.scale
		muzzlePoint.add_child(muzzleSmoke)

func add_recoil():

	if recoil and weapon.get_meta("recoil_x",0)+weapon.get_meta("recoil_y",0)>0:
		
		recoiling = true
		
		var recoil_x:float = randf_range(weapon.get_meta("recoil_x",0)*.2, weapon.get_meta("recoil_x",0))
		var recoil_y:float = randf_range(-weapon.get_meta("recoil_y",0), weapon.get_meta("recoil_y",0))
	
		
		recoil_target.x = clampf(node_recoil_x.rotation.x + recoil_x, recoil_x_clamp_min, recoil_x_clamp_max)
		recoil_target.y = node_recoil_y.rotation.y + recoil_y
	


func add_camera_shake(amount:float):
	if shake and camera and weapon.get_meta("recoil_x",0)+weapon.get_meta("recoil_y",0)>0:
		shake_current = min(shake_current+amount, 1.0)

func camera_shake():
	if shake and camera:
		var amount = pow(shake_current, 2)
		camera.rotation.z = shake_max_roll * amount * randf_range(-1, 1)
		camera.h_offset = shake_max_offset.x * amount * randf_range(-1, 1)
		camera.v_offset = shake_max_offset.y * amount * randf_range(-1, 1)

func take_weapon(inventory_index:int) -> void:

	inventory_index = wrapi(inventory_index, 0, inventory["weapons"].size())
	var inventory_weapon = inventory["weapons"][inventory_index]
	var index = inventory_weapon[0] # Weapon index of weapons array
	index = clampi(index, 0, weapons.size()-1)

	

	
	# Add weapon to scene in there is none
	if !weapon or !weapon.is_inside_tree():
		weapon = weapons[index].instantiate()
		weapon.visible = false # avoid first frame in wrong position
		add_child(weapon)
	# If it's the same as the current weapon, do nothing
	elif weapon_index == inventory_index:
		
		return
	# If there is already a weapon, hide it then change it
	else:
		weapon_change = inventory_index
		state_machine.travel("hide")
		return
	
	weapon_index = inventory_index
	weapon_change = inventory_index
	
	animation = weapon.get_node("AnimationTree")
	state_machine = animation["parameters/playback"]
	muzzlePoint = weapon.find_child("MuzzlePoint")
	
	start_pos = weapon.position
	ads_pos = weapon.get_meta("ads_pos", start_pos)
	
	max_magazine = weapon.get_meta("max_magazine",0)
	magazine = inventory_weapon[1]
	if magazine == -1:
		magazine = max_magazine
	update_inventory()
	
	FireRayCast.target_position.z = weapon.get_meta("range")
	
	animation.connect("animation_finished", _on_animation_tree_animation_finished)
	animation.connect("animation_started", _on_animation_tree_animation_started)
	

func hide_weapon() -> void:
	animation.disconnect("animation_finished", _on_animation_tree_animation_finished)
	animation.disconnect("animation_started", _on_animation_tree_animation_started)
	if weapon_change != weapon_index:
		weapon.connect("tree_exited", take_weapon.bind(weapon_change))
	weapon.queue_free()

func checkstate(is_shooting: bool, is_reloading: bool, is_aiming: bool) -> void:
	if weapon != null:

		# Single fire
		if !weapon.get_meta("auto", false):
			if is_shooting and (magazine > 0 or max_magazine == 0):
				state_machine.travel("fire")
		
		# Actions
		if is_reloading :
			
			state_machine.travel("reload")
			if inventory["ammo"][weapon.get_meta("ammo_type", "none")] > 0:
				self.is_reloading = true
				if magazine > 0 and "reload_full" in animation.get_animation_list():
					
					state_machine.travel("reload_full")
				else:
					
					state_machine.travel("reload")
		if is_aiming:
			aim()

func _process(delta) -> void:
	if weapon != null:
		# ADS animation
		if ads and weapon.position != ads_pos:
			weapon.position = weapon.position.move_toward(ads_pos, weapon.get_meta("delta",1.5)*delta_multiplier*delta)
		if !ads and weapon.position != start_pos:
			weapon.position = weapon.position.move_toward(start_pos, weapon.get_meta("delta",1.5)*delta_multiplier*delta)
		
		# Automatic fire
		if weapon.get_meta("auto", false):
			if Input.is_action_pressed(action_fire) and (magazine > 0 or max_magazine == 0):
				state_machine.travel("fire")

func _physics_process(delta) -> void:
	# Recoil
	if recoiling and recoil and node_recoil_x and node_recoil_y:
		node_recoil_x.rotation.x = lerp_angle(node_recoil_x.rotation.x, recoil_target.x, delta*15)
		node_recoil_y.rotation.y = lerp_angle(node_recoil_y.rotation.y, recoil_target.y, delta*15)
	# Sway
	if sway and camera:
		sway_rotation_target = camera.global_rotation.reflect(Vector3(0,1,0))
		sway_rotation_target.y -= PI
		rotation.y = lerp_angle(rotation.y, sway_rotation_target.y, delta*sway_look_sens)
		rotation.x = lerp_angle(rotation.x, sway_rotation_target.x, delta*sway_look_sens)
		rotation.z = lerp_angle(rotation.z, sway_rotation_target.z, delta*sway_look_sens)
		position = position.lerp(camera.global_position, delta*sway_move_sens)
	# Shake
	if shake and camera and shake_current > 0:
		shake_current = max(shake_current - shake_decay * delta, 0)
		camera_shake()

func _on_animation_tree_animation_finished(anim_name: StringName) -> void:
	if anim_name == "reload" or anim_name == "reload_full":
		self.is_reloading = false
		# Reload magazine
		if inventory["ammo"][weapon.get_meta("ammo_type", "none")] >= max_magazine-magazine:
			inventory["ammo"][weapon.get_meta("ammo_type", "none")] -= max_magazine-magazine
			magazine = max_magazine
		else:
			magazine += inventory["ammo"][weapon.get_meta("ammo_type", "none")]
			inventory["ammo"][weapon.get_meta("ammo_type", "none")] = 0
		update_inventory()
	# Remove weapon
	if anim_name == "hide":
		hide_weapon()
	# Stop recoil
	if anim_name == "fire":
		recoiling = false

func _on_animation_tree_animation_started(anim_name: StringName) -> void:
	# Show weapon on animationTree start
	if anim_name == "take" and !weapon.visible:
		weapon.visible = true
	# If any animation other than idle and fire starts, do not aim
	if anim_name != "idle" and anim_name != "fire":
		aim(false)
	if anim_name == "fire":
		# Récupérer le WeaponManager depuis la scène player
		
		var weapon_manager = $"../WeaponManager"
		# Vérifier que l'option "Use New Weapon System" n'est pas activée
		if max_magazine != 0:
			magazine -= 1
			update_inventory()
		shoot_bullet()
		check_damage(FireRayCast, weapon.get_meta("damage"), weapon.get_meta("melee", false))
		muzzle_flash()
		muzzle_smoke()
		add_recoil()
		add_camera_shake(shake_strength)
	if anim_name == "melee":
		check_damage(MeleeRayCast, melee_damage, true)
