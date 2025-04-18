using Godot;
using System;

public class InputEvents
{
    // Événements de mouvement
    public event Action<Vector2> OnMovementChanged;
    public event Action<bool> OnSprintStateChanged;
    public event Action<bool> OnCrouchStateChanged;
    public event Action<bool> OnJumpStateChanged;
    public event Action<bool> OnSlideStateChanged;
    

    // Événements d'actions
    public event Action<bool> OnShootStateChanged;
    public event Action OnReloadTriggered;
    public event Action OnSwitchWeaponTriggered;
    public event Action OnSwitchWeaponUpTriggered;
    public event Action OnSwitchWeaponDownTriggered;
    public event Action<bool> OnInGameMenuToggle;
    public event Action<bool> OnAimStateChanged;
    public event Action<bool> OnReloadStateChanged;
    public event Action OnAimTriggered;
    public event Action OnAimReleased;

    // Événements de souris
    public event Action<Vector2> OnMouseMotionChanged;
    public event Action<int, bool> OnMouseButtonStateChanged;

    // État actuel
    private Vector2 _movementVector = Vector2.Zero;
    private bool _isSprinting = false;
    private bool _isCrouching = false;
    private bool _isJumping = false;
    private bool _isSliding = false;
    private bool _isShooting = false;
    private bool _isAiming = false;
    private Vector2 _mouseMotion = Vector2.Zero;
    private bool[] _mouseButtonStates = new bool[3]; // Pour les 3 boutons de souris

    public void UpdateMovementVector(Vector2 movementVector)
    {
       //GD.Print($"[InputEvents] UpdateMovementVector appelé avec le vecteur : {movementVector}");
        _movementVector = movementVector;
        OnMovementChanged?.Invoke(movementVector);
    }

    public void UpdateSprintState(bool isSprinting)
    {
        _isSprinting = isSprinting;
        OnSprintStateChanged?.Invoke(isSprinting);
    }

    public void UpdateCrouchState(bool isCrouching)
    {
        _isCrouching = isCrouching;
        OnCrouchStateChanged?.Invoke(isCrouching);
    }

    public void UpdateJumpState(bool isJumping)
    {
        _isJumping = isJumping;
        OnJumpStateChanged?.Invoke(isJumping);
    }

    public void UpdateSlideState(bool isSliding)
    {
        _isSliding = isSliding;
        OnSlideStateChanged?.Invoke(isSliding);
    }

    public void UpdateShootState(bool isShooting)
    {
        _isShooting = isShooting;
        OnShootStateChanged?.Invoke(isShooting);
    }

    public void UpdateAimState(bool isAiming)
    {
        _isAiming = isAiming;
        OnAimStateChanged?.Invoke(isAiming);
    }

    public void UpdateReloadState(bool isReloading)
    {
        // OnReloadStateChanged?.Invoke(isReloading);
    }

    public void TriggerReload()
    {
        OnReloadTriggered?.Invoke();
    }

    public void TriggerAim()
    {
        OnAimTriggered?.Invoke();
    }

    public void ReleaseAim()
    {
        OnAimReleased?.Invoke();
    }

    public void TriggerSwitchWeapon()
    {
        OnSwitchWeaponTriggered?.Invoke();
        //GD.Print("[InputEvents] TriggerSwitchWeapon appelé");
    }

    public void TriggerSwitchWeaponUp()
    {
        OnSwitchWeaponUpTriggered?.Invoke();
        //GD.Print("[InputEvents] TriggerSwitchWeaponUp appelé");
    }

    public void TriggerSwitchWeaponDown()
    {
        OnSwitchWeaponDownTriggered?.Invoke();
        //GD.Print("[InputEvents] TriggerSwitchWeaponDown appelé");
    }

    public void TriggerInGameMenuToggle(bool isEnabled)
    {
        OnInGameMenuToggle?.Invoke(isEnabled);
    }

    // Gestion de la souris
    public void UpdateMouseMotion(Vector2 motion)
    {
        _mouseMotion = motion;
        OnMouseMotionChanged?.Invoke(motion);
    }

    public void UpdateMouseButton(int buttonIndex, bool pressed)
    {
        if (buttonIndex >= 0 && buttonIndex < _mouseButtonStates.Length)
        {
            _mouseButtonStates[buttonIndex] = pressed;
            OnMouseButtonStateChanged?.Invoke(buttonIndex, pressed);
        }
    }

    // Getters pour l'état actuel
    public Vector2 GetMovementVector() => _movementVector;
    public bool IsSprinting() => _isSprinting;
    public bool IsCrouching() => _isCrouching;
    public bool IsJumping() => _isJumping;
    public bool IsSliding() => _isSliding;
    public bool IsShooting() => _isShooting;
    public bool IsAiming() => _isAiming;
    public Vector2 GetMouseMotion() => _mouseMotion;
    public bool IsMouseButtonPressed(int buttonIndex) => buttonIndex >= 0 && buttonIndex < _mouseButtonStates.Length && _mouseButtonStates[buttonIndex];
} 