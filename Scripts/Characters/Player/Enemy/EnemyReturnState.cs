using Godot;
using System;

public partial class EnemyReturnState : EnemyState
{
    private Vector3 destination;
    public override void _Ready()
    {
        base._Ready();
    }
    protected override void EnterState()
    {
        characterNode.AnimPlayerNode.Play(GameConstants.ANIM_MOVE);
    }
}