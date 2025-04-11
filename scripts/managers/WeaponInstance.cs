using Godot;

public partial class WeaponInstance : Node3D
{
    [Export]
    public float Damage { get; set; } = 10f;

    [Export]
    public int MaxAmmo { get; set; } = 30;

    [Export]
    public float FireRate { get; set; } = 0.1f;

    [Export]
    public float RecoilX { get; set; } = 0.5f;

    [Export]
    public float RecoilY { get; set; } = 0.3f;

    [Export]
    public bool IsAutomatic { get; set; } = false;

    [Export]
    public string AmmoType { get; set; } = "9mm";

    [Export]
    public Vector3 AimPosition { get; set; } = Vector3.Zero;

    public Node3D MuzzlePoint { get; private set; }

    public override void _Ready()
    {
        MuzzlePoint = GetNode<Node3D>("MuzzlePoint");
    }
} 