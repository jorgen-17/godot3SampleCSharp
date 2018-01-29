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

    public static Vector2 RotateAroundCenter(Vector2 point, Vector2 center, float degrees)
    {
        var angle = DegreeToRadian(degrees);
        var rotatedX = (float) (Math.Cos(angle) * (point.x - center.x) - Math.Sin(angle) * (point.y - center.y) + center.x);
        var rotatedY = (float) (Math.Sin(angle) * (point.x - center.x) + Math.Cos(angle) * (point.y - center.y) + center.y);
        return new Vector2(rotatedX, rotatedY);
    }
    
    private static float DegreeToRadian(float angle)
    {
        return (float) ((Math.PI * angle) / 180.0);
    }
}
