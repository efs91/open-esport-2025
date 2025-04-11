using System;
using Godot;

// Health Ability, manage health system for CharacterController3D.

public partial class HealthAbility3D : MovementAbility3D
{
	// Maximum health value
	[Export] public float MaxHealth = 100.0f;

	// Current health value
	private float _currentHealth;

	// Event triggered when health changes
	public event Action<float> OnHealthChanged;

	// Event triggered when character dies
	public event Action OnDeath;

	public override void _Ready()
	{
		base._Ready();
		_currentHealth = MaxHealth;
	}

	// Take damage and return true if character is still alive
	public bool TakeDamage(float damage)
	{
		if (!IsActived())
			return true;

		_currentHealth = Mathf.Max(0, _currentHealth - damage);
		OnHealthChanged?.Invoke(_currentHealth);

		if (_currentHealth <= 0)
		{
			OnDeath?.Invoke();
			return false;
		}

		return true;
	}

	// Heal character and return true if healing was successful
	public bool Heal(float amount)
	{
		if (!IsActived())
			return false;

		_currentHealth = Mathf.Min(MaxHealth, _currentHealth + amount);
		OnHealthChanged?.Invoke(_currentHealth);
		return true;
	}

	// Get current health percentage
	public float GetHealthPercentage()
	{
		return _currentHealth / MaxHealth;
	}

	// Get current health value
	public float GetCurrentHealth()
	{
		return _currentHealth;
	}

	// Reset health to max value
	public void ResetHealth()
	{
		_currentHealth = MaxHealth;
		OnHealthChanged?.Invoke(_currentHealth);
	}
} 
