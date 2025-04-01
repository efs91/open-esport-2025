using System;
using Godot;

// Capacité de tir basique qui affiche "tire" dans la console

public partial class ShootAbility3D : MovementAbility3D
{
	// Nombre de balles par seconde
	[Export] public float BulletsPerSecond = 10f;

	private bool _isShooting = false;
	private AnimationTree _animationTree;
	private Node3D _muzzlePoint;
	private Timer _shootTimer;

	public override void _Ready()
	{
		base._Ready();
		// S'abonner aux événements de clic de souris
		Input.MouseMode = Input.MouseModeEnum.Captured;
		
		// Créer le timer pour le tir
		_shootTimer = new Timer();
		_shootTimer.OneShot = false;
		_shootTimer.WaitTime = 1.0f / BulletsPerSecond;
		_shootTimer.Timeout += OnShootTimerTimeout;
		AddChild(_shootTimer);
		
		// Récupérer le WeaponHolder
		
		

		// Récupérer l'arme actuelle
		

		
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseButton)
		{
			if (mouseButton.ButtonIndex == MouseButton.Left)
			{
				_isShooting = mouseButton.Pressed;
				if (_isShooting)
				{
					_shootTimer.Start();
					Fire(); // Tir immédiat
				}
				else
				{
					_shootTimer.Stop();
				}
			}
		}
	}

	private void OnShootTimerTimeout()
	{
		if (_isShooting)
		{
			Fire();
		}
	}

	private void Fire()
	{
		GD.Print("tire");
		if (_animationTree != null)
		{
			var playback = _animationTree.Get("parameters/playback").As<AnimationNodeStateMachinePlayback>();
			if (playback != null)
			{
				playback.Travel("fire");
			}
		}
	}

	public override Vector3 Apply(Vector3 velocity, float speed, bool isOnFloor, Vector3 direction, float delta)
	{
		return velocity;
	}
} 
