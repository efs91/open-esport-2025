using System;
using Godot;
using Openesport.Utils;

public partial class IAController3D : CharacterController3D
{
	
	
	
	private Vector2 _movementVector = Vector2.Zero;
	private bool _isSprinting = false;
	private bool _isCrouching = false;
	private bool _isJumping = false;

	public override void _Ready()
	{
		base._Ready();
		
	}

	public override void Setup()
	{
		base.Setup();
		
	}

	

	public override void _PhysicsProcess(double delta)
	{
		// Utiliser les variables d'état pour appeler Move
		Move((float)delta, _movementVector, _isJumping, _isCrouching, _isSprinting, false, false);
	}

	// Gestionnaires d'événements
	

	

	public override void _ExitTree()
	{
		
	}
}
