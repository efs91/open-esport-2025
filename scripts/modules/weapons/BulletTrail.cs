using Godot;
using System;

public partial class BulletTrail : GpuParticles3D
{
	private StandardMaterial3D _material;
	private float _fadeOutTime = 0.5f;
	private float _currentTime = 0f;

	public override void _Ready()
	{
		GD.Print("Initialisation de la traînée de la balle");

		// Créer le matériau simple
		_material = new StandardMaterial3D();
		_material.AlbedoColor = new Color(1, 1, 1, 0.8f);
		_material.NoDepthTest = true;

		// Créer un PointMesh
		var pointMesh = new PointMesh();
		pointMesh.Material = _material;

		// Configurer le système de particules
		DrawPass1 = pointMesh;
		Emitting = true;
		Amount = 1000;
		Lifetime = 1f;
		OneShot = false;
		Explosiveness = 0.0f;
		FixedFps = 60; // 60 FPS pour une émission fluide
		ProcessMaterial = new ParticleProcessMaterial
		{
			Direction = Vector3.Zero,
			Spread = 0.0f,
			InitialVelocityMin = 0.0f,
			InitialVelocityMax = 0.0f,
			Gravity = Vector3.Zero,
			ScaleMin = 0.02f,
			ScaleMax = 0.02f,
			Color = new Color(1, 1, 1, 1),
			EmissionShape = ParticleProcessMaterial.EmissionShapeEnum.Point
		};

		GD.Print($"Traînée configurée avec {Amount} particules à {FixedFps} FPS");
	}

	public override void _Process(double delta)
	{
		_currentTime += (float)delta;
		if (_currentTime >= _fadeOutTime)
		{
			GD.Print("Suppression de la traînée après " + _currentTime + " secondes");
			QueueFree();
		}
	}
}
