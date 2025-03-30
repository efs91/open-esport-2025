using System;
using Godot;

// Ability that adds extra speed when actived (Sprint).

public partial class SprintAbility3D : MovementAbility3D
{
    // Speed to be multiplied when activating the ability
    [Export] public float SpeedMultiplier = 1.6f;

    // Returns the speed multiplier when the ability is active
    public override float GetSpeedModifier()
    {
        if (IsActived())
        {
            return SpeedMultiplier;
        }
        return base.GetSpeedModifier();
    }

    // No need to override Apply as we only modify speed
    public override Vector3 Apply(Vector3 velocity, float speed, bool isOnFloor, Vector3 direction, float delta)
    {
        return velocity;
    }
}
