using Godot;
using System;

public partial class Bullet : RigidBody3D
{
	private const float LIFETIME = 20.0f;
	private PackedScene _trailScene;
	private Vector3 _initialDirection;
	private float _lifetime = 5.0f; // 5 secondes de durée de vie
	private float _initialSpeed = 250.0f; // 250 m/s de vitesse initiale

	public override void _Ready()
	{
		GD.Print("Bullet Ready");
		_trailScene = GD.Load<PackedScene>("res://scenes/modules/weapons/bullet_trail.tscn");
		var trail = _trailScene.Instantiate();
		AddChild(trail);

		// Configurer les collisions
		//CollisionLayer = 1;  // Layer 1 pour les balles
		//CollisionMask = 1;   // Détecter les objets sur le layer 1
		
		// Connecter le signal de collision
		BodyEntered += OnBodyEntered;
		GD.Print("Signal BodyEntered connecté");

		// Démarrer le timer de durée de vie
		GetTree().CreateTimer(_lifetime).Timeout += OnLifetimeEnd;
	}

	private void OnBodyEntered(Node body)
	{
		GD.Print($"La balle a touché : {body.Name} à la position {GlobalPosition}");
	}

	public void set_initial_direction(Vector3 direction)
	{
		_initialDirection = direction.Normalized();
		
		// Appliquer la vitesse initiale dans la direction donnée
		LinearVelocity = _initialDirection * _initialSpeed;
		GD.Print($"Balle tirée avec vitesse : {LinearVelocity}");
	}

	private void OnLifetimeEnd()
	{
		GD.Print("Balle détruite après timeout");
		QueueFree();
	}

	public override void _Process(double delta)
	{
		// La balle se détruira automatiquement après LIFETIME secondes
		// grâce au système de lifetime de Godot
	}
} 
