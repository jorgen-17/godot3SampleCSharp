using Godot;
using System;

public class Cutesy : Spatial
{
    private const string MOVE_FORWARD = "move_forward";
    private const string MOVE_BACK = "move_back";
    private const string RUN_FORWARD = "runForward";
    private const string ESCAPE = "escape";
    private const int RUNNING_DISPLACEMENT_PER_SECOND = 50;
    private const int ANIMATION_PLAYER_INDEX = 1;
    private const float RUN_ANIMATION_SPEED = 2F;
    private readonly Vector3 _forward = new Vector3(0, 0, 1);
    private AnimationPlayer _animPlayer;

    public override void _Ready()
    {
        _animPlayer = GetChild(ANIMATION_PLAYER_INDEX) as AnimationPlayer;
        _animPlayer.SetCurrentAnimation(RUN_FORWARD);
        _animPlayer.GetAnimation(RUN_FORWARD).Loop = true;
        _animPlayer.Stop();
    }

    public override void _Process(float delta)
    {   
        if(Input.IsActionJustPressed(ESCAPE))
        {
            GetTree().Quit();
        }

        if(Input.IsActionJustPressed(MOVE_FORWARD))
        {
            _animPlayer.Play(RUN_FORWARD, -1, RUN_ANIMATION_SPEED);
        }
        else if(Input.IsActionPressed(MOVE_FORWARD))
        {
            var displacement = RUNNING_DISPLACEMENT_PER_SECOND * delta;
            Translate(displacement * _forward);
            _animPlayer.Advance(delta);
        }
        else if(Input.IsActionJustReleased(MOVE_FORWARD))
        {
            _animPlayer.Stop();
            _animPlayer.Seek(0, true);
        }
        if(Input.IsActionJustPressed(MOVE_BACK))
        {
            _animPlayer.PlayBackwards(RUN_FORWARD);
        }
        else if(Input.IsActionPressed(MOVE_BACK))
        {
            var displacement = -RUNNING_DISPLACEMENT_PER_SECOND * delta;
            Translate(displacement * _forward);
            _animPlayer.Advance(delta);
        }
        else if(Input.IsActionJustReleased(MOVE_BACK))
        {
            _animPlayer.Stop();
            _animPlayer.Seek(0, true);
        }
    }
}
