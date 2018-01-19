using Godot;
using System;

public class ThirdPersonCamera : Camera
{
    private readonly Vector3 ZERO = new Vector3(0, 0, 0);
    private Spatial _cutesy;
    private Vector3 _lastPosition;

    public override void _Ready()
    {
        Input.SetMouseMode(Input.MouseMode.Captured);
    }

    public override void _Process(float delta) { }
}
