using Godot;
using System;
using Openesport.Utils;

public partial class AiPlayer : CharacterBody3D
{
	private LogManager _logManager;
	private Area3D _area3D;
	private CollisionShape3D _collisionShape;

	public override void _Ready()
	{
		_logManager = GetNode<LogManager>(GlobalPaths.Managers.LOG_MANAGER);
		_area3D = GetNode<Area3D>("Area3D");
		_collisionShape = GetNode<CollisionShape3D>("CollisionShape3D");
		
		// Connecter les signaux de l'Area3D
		_area3D.BodyEntered += OnAreaBodyEntered;
		_area3D.BodyExited += OnAreaBodyExited;
	}

	private void OnAreaBodyEntered(Node body)
	{
		_logManager.Info($"Un objet est entré dans la zone de l'AI : {body.Name}");
		if (body is Node3D node3D)
		{
			// Calculer les positions relatives
			var capsuleShape = _collisionShape.Shape as CapsuleShape3D;
			if (capsuleShape != null)
			{
				float height = capsuleShape.Height;
				float radius = capsuleShape.Radius;
				
				// Définir les limites des zones
				float headBottom = GlobalPosition.Y + height * 0.6f; // 60% du haut
				float bodyBottom = GlobalPosition.Y + height * 0.2f; // 20% du haut
				
				// Position Y de l'objet qui entre en collision
				float objectY = node3D.GlobalPosition.Y;
				
				// Déterminer dans quelle zone se trouve l'objet
				if (objectY > headBottom)
				{
					_logManager.Info("Touché dans la tête !");
				}
				else if (objectY > bodyBottom)
				{
					_logManager.Info("Touché dans le corps !");
				}
				else
				{
					_logManager.Info("Touché dans les jambes !");
				}
			}
		}
		_logManager.Info($"Type de l'objet : {body.GetType()}");
	}

	private void OnAreaBodyExited(Node body)
	{
		_logManager.Info($"Un objet est sorti de la zone de l'AI : {body.Name}");
	}
}
