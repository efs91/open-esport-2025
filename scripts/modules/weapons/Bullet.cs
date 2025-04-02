using Godot;
using System;

public partial class Bullet : RigidBody3D
{
	private const float LIFETIME = 20.0f;
	private const float INITIAL_SPEED = 250.0f;
	private PackedScene _trailScene;
	private Vector3 _initialDirection;
	private float _lifetime = 5.0f; // 5 secondes de durée de vie
	private float _initialSpeed = 50.0f; // 50 m/s de vitesse initiale

	public override void _Ready()
	{
		_trailScene = GD.Load<PackedScene>("res://scenes/modules/weapons/bullet_trail.tscn");
		var trail = _trailScene.Instantiate();
		AddChild(trail);

		// Désactiver les collisions au démarrage
		CollisionLayer = 0;
		
		// Créer un timer pour réactiver les collisions après 0.1ms
		GetTree().CreateTimer(0.1f).Timeout += OnEnableCollisions;
		
		// Démarrer le timer de durée de vie
		GetTree().CreateTimer(_lifetime).Timeout += OnLifetimeEnd;
	}

	public void set_initial_direction(Vector3 direction)
	{
		_initialDirection = direction.Normalized();
		GD.Print($"Direction reçue par la balle : {_initialDirection}");
		
		// Appliquer la vitesse initiale dans la direction donnée
		LinearVelocity = _initialDirection * _initialSpeed;
		GD.Print($"Vitesse initiale appliquée : {LinearVelocity}");
	}

	private void OnEnableCollisions()
	{
		// Réactiver les collisions (layer 1)
		GD.Print("Réactivation des collisions");
		CollisionLayer = 1;
	}

	private void OnLifetimeEnd()
	{
		GD.Print("Durée de vie de la balle terminée");
		QueueFree();
	}

	public override void _Process(double delta)
	{
		// La balle se détruira automatiquement après LIFETIME secondes
		// grâce au système de lifetime de Godot
	}
} 
