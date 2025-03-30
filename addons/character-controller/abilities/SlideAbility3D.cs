using System;
using Godot;

public partial class SlideAbility3D : MovementAbility3D
{
	private CharacterController3D _controller;
	private float _defaultFriction;
	private float _slideFriction = 0.1f;
	// Cooldown entre deux slides en secondes
	private float _slideCooldown = 1.0f;
	// Temps du dernier slide (en secondes)
	private float _lastSlideTime = 0f;
	// Multiplicateur appliqué à la vitesse initiale pour donner un léger boost
	private float _slideSpeedMultiplier = 1.05f; // 5% de plus
	private float _maxSlideSpeed;
	private float _initialSlideSpeed;
	// Vitesse courante du slide (mise à jour chaque frame)
	private float _currentSlideSpeed;
	// RayCast pour détecter la pente
	private RayCast3D _slopeCheck;
	private const float SLOPE_CHECK_LENGTH = 2.0f;
	// Pour comparer l'angle de la pente (en radians)
	private const float MIN_SLOPE_ANGLE = 0.1f;
	// Multiplicateur de vitesse maximal (défini à partir du sprint)
	private float _maxSlideSpeedMultiplier;
	private Vector3 _slideDirection = Vector3.Zero;
	private bool _isSliding = false;

	// Constantes pour l'accélération/décélération
	private const float BASE_ACCELERATION = 10f;    // Accélération de base en descente
	private const float BASE_DECELERATION = 40f;      // Décélération de base en montée
	private const float FLAT_DECELERATION = 15f;      // Décélération sur terrain plat

	[Signal]
	public delegate void SlideStartedEventHandler();
	[Signal]
	public delegate void SlideEndedEventHandler();

	public override void _Ready()
	{
		base._Ready();
		_controller = GetParent<CharacterController3D>();
		_defaultFriction = _controller.Friction;
		_maxSlideSpeedMultiplier = _controller.SprintSpeedMultiplier * 2;
		_maxSlideSpeed = _controller.Speed * _maxSlideSpeedMultiplier;

		// Configurer le RayCast3D pour détecter la pente sous le personnage
		_slopeCheck = new RayCast3D();
		_slopeCheck.TargetPosition = new Vector3(0, -SLOPE_CHECK_LENGTH, 0);
		_slopeCheck.Enabled = true;
		AddChild(_slopeCheck);
	}

	// Renvoie l'angle de la pente et un "slope sign" indiquant si la direction du slide correspond à une descente (négatif) ou une montée (positif)
	private bool GetSlopeInfo(out float slopeAngle, out float slopeSign)
	{
		slopeAngle = 0f;
		slopeSign = 0f;
		if (_slopeCheck.IsColliding())
		{
			Vector3 normal = _slopeCheck.GetCollisionNormal();
			slopeAngle = normal.AngleTo(Vector3.Up);
			// Calculer le vecteur "descendant" sur la pente
			Vector3 downhill = (Vector3.Up - normal * normal.Dot(Vector3.Up)).Normalized();
			slopeSign = Mathf.Sign(downhill.Dot(_slideDirection));
			return true;
		}
		return false;
	}

	public override float GetSpeedModifier()
	{
		if (IsActived())
		{
			return 1.0f;
		}
		return base.GetSpeedModifier();
	}

	private void ResetSlide()
	{
		_isSliding = false;
		_slideDirection = Vector3.Zero;
		// Rétablir la friction par défaut
		_controller.Friction = _defaultFriction;
		// Mettre à jour le temps du dernier slide
		_lastSlideTime = Time.GetTicksMsec() / 1000.0f;
		EmitSignal(SignalName.SlideEnded);
	}

	public override void SetActive(bool active)
	{
		if (active)
		{
			float currentTime = Time.GetTicksMsec() / 1000.0f;
			if (currentTime - _lastSlideTime < _slideCooldown)
			{
				// Si le cooldown n'est pas terminé, ne pas activer le slide
				return;
			}
		}
		if (!active && _isSliding)
		{
			ResetSlide();
		}
		base.SetActive(active);
	}

	public override Vector3 Apply(Vector3 velocity, float speed, bool isOnFloor, Vector3 direction, float delta)
	{
		if (IsActived())
		{
			if (!_isSliding)
			{
				// Début du slide
				_isSliding = true;
				// Définir la direction de glissade à partir de l'input s'il y en a, sinon utiliser la direction de la vélocité
				_slideDirection = (direction.Length() > 0.1f) ? direction.Normalized() : (velocity.Length() > 0.1f ? velocity.Normalized() : Vector3.Zero);
				_initialSlideSpeed = velocity.Length() * _slideSpeedMultiplier;
				_currentSlideSpeed = _initialSlideSpeed;
				velocity = _slideDirection * _currentSlideSpeed;
				// Réduire la friction pour simuler un glissement sur une surface lisse
				_controller.Friction = _slideFriction;
				EmitSignal(SignalName.SlideStarted);
			}
			else
			{
				// Mise à jour de la vitesse en fonction de la pente
				float slopeAngle, slopeSign;
				float acceleration = 0f;
				if (GetSlopeInfo(out slopeAngle, out slopeSign))
				{
					// Si l'angle est presque nul, c'est du plat
					if (slopeAngle < 0.05f)
					{
						acceleration = -FLAT_DECELERATION;
					}
					else
					{
						// Normaliser l'angle par rapport à Pi/2 (90°)
						float slopeFactor = slopeAngle / (Mathf.Pi / 2);
						// Correction inversée : en descente (slopeSign < 0), on accélère ; en montée (slopeSign > 0), on freine.
						if (slopeSign < 0)
						{
							acceleration = BASE_ACCELERATION * slopeFactor;
						}
						else if (slopeSign > 0)
						{
							acceleration = -BASE_DECELERATION * slopeFactor;
						}
						else
						{
							acceleration = -FLAT_DECELERATION;
						}
					}
				}
				else
				{
					acceleration = -FLAT_DECELERATION;
				}
				// Mise à jour de la vitesse courante
				_currentSlideSpeed += acceleration * delta;
				_currentSlideSpeed = Mathf.Max(_currentSlideSpeed, 0);
				_currentSlideSpeed = Mathf.Min(_currentSlideSpeed, _maxSlideSpeed);
				velocity = _slideDirection * _currentSlideSpeed;
				// La glissade se termine lorsque la vitesse descend au niveau de la vitesse de marche
				if (_currentSlideSpeed <= speed)
				{
					ResetSlide();
					velocity = Vector3.Zero;
					GD.Print("SLIDE FINI");
				}
			}
		}
		else
		{
			if (_isSliding)
			{
				ResetSlide();
			}
		}
		return velocity;
	}
}
