using Godot;
using System;

public class ThirdPersonCamera : Camera
{
    private readonly Vector3 ZERO = new Vector3(0, 0, 0);
    private Spatial _cutesy;
    private Vector3 _lastPosition;

    public override void _Ready()
    {
        _cutesy = GetTree().GetRoot().GetNode("Node/Cutesy") as Spatial;
        Input.SetMouseMode(Input.MouseMode.Captured);
    }

    public override void _Input(InputEvent @event)
    {
        if(@event is InputEventMouseMotion mouseMotionEvent)
        {
            ProcessMouseInputEvent(mouseMotionEvent);
        }
    }

    private void ProcessMouseInputEvent(InputEventMouseMotion @mouseMotionEvent)
    {
        var cutesyPos = _cutesy.GetTranslation();
        var currentPos = cutesyPos + GetTranslation();
	
//         	GD.Print("cutesy at:");
//         	GD.Print(cutesyPos);
//         	GD.Print("camera at:");
//         	GD.Print(currentPos);

        var xAngle = @mouseMotionEvent.Relative.x;
//         	GD.Print("rotating by:");
//         	GD.Print(xAngle);
        var horizontalCenter = new Vector2(cutesyPos.x, cutesyPos.z);
        var horizontalPoint = new Vector2(currentPos.x, currentPos.z);
        var rotatedHorizontal = RotateAroundCenter(horizontalPoint, horizontalCenter, xAngle);
        var horizontalCoordinate = new Vector3(rotatedHorizontal.x, currentPos.y, rotatedHorizontal.y);
//         	GD.Print("camera getting translated to:");
//         	GD.Print(horizontalCoordinate);
	
        SetTranslation(horizontalCoordinate - cutesyPos);
	
//         	GD.Print("\n");

        currentPos = cutesyPos + GetTranslation();
        var yAngle = @mouseMotionEvent.Relative.y;
        var verticalCenter = new Vector2(cutesyPos.y, cutesyPos.z);
        var verticalPoint = new Vector2(currentPos.y, currentPos.z);
        var rotatedVertical = RotateAroundCenter(verticalPoint, verticalCenter, yAngle);
        var verticalCoordinate = new Vector3(currentPos.x, rotatedVertical.x, rotatedVertical.y);

        SetTranslation(verticalCoordinate - cutesyPos);
        LookAt(cutesyPos, new Vector3(0, 1, 0));

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
