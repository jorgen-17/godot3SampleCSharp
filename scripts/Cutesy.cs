using Godot;
using System;

public class Cutesy : Spatial
{
    private const string MOVE_FORWARD = "move_forward";
    private const string MOVE_BACK = "move_back";
    private const string RUN_FORWARD = "runForward";
    private const int RUNNING_DISPLACEMENT_PER_SECOND = 50;
    private const int ANIMATION_PLAYER_INDEX = 1;
    private const float RUN_ANIMATION_SPEED = 2F;
    private Vector3 _forward = new Vector3(0, 0, 1);
    private AnimationPlayer _animPlayer;

    public override void _Ready()
    {
        this._animPlayer = this.GetChild(ANIMATION_PLAYER_INDEX) as AnimationPlayer;
        this._animPlayer.SetCurrentAnimation(RUN_FORWARD);
        GD.Print(this._animPlayer.GetAutoplay());
        this._animPlayer.SetSpeedScale(RUN_ANIMATION_SPEED);
    }

    public override void _Process(float delta)
    {
        if(Input.IsActionPressed(MOVE_FORWARD))
        {
            var displacement = RUNNING_DISPLACEMENT_PER_SECOND * delta;
            this.Translate(displacement * this._forward);
            this._animPlayer.Advance(delta);
        }
        else if(Input.IsActionJustReleased(MOVE_FORWARD))
        {
            this._animPlayer.Seek(0, true);
        }
        if(Input.IsActionPressed(MOVE_BACK))
        {
            var displacement = -RUNNING_DISPLACEMENT_PER_SECOND * delta;
            this.Translate(displacement * this._forward);
            this._animPlayer.Advance(-delta);
        }
        else if(Input.IsActionJustReleased(MOVE_BACK))
        {
            this._animPlayer.Seek(0, true);
        }
    }
}
