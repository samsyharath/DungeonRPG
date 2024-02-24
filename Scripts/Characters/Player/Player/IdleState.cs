using Godot;
using System;

public partial class IdleState : PlayerState
{
    public override void _PhysicsProcess(double delta)
    {
        if (characterNode.direction != Vector2.Zero)
        {
            characterNode.StateMachineNode.SwitchState<MoveState>();
        }
    }

    protected override void EnterState(){
        characterNode.AnimPlayerNode.Play(GameConstants.ANIM_IDLE);
    }
    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed(GameConstants.INPUT_DASH))
        {
            characterNode.StateMachineNode.SwitchState<DashState>();
        }
    }
}