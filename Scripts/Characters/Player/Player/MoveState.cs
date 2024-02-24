using Godot;
using System;

public partial class MoveState : Node
{
    private Player characterNode;
    public override void _Ready()
    {
        characterNode = GetOwner<Player>();
    }
    public override void _PhysicsProcess(double delta)
    {
        GD.Print("Move state physics process.");
        if (characterNode.direction == Vector2.Zero)
        {
            characterNode.stateMachineNode.SwitchState<IdleState>();
        }
    }
    public override void _Notification(int what)
    {
        if (what == 5001)
        {
            characterNode.animPlayerNode.Play(GameConstants.ANIM_MOVE);
        }
    }
}
