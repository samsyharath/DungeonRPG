using Godot;
using System;

public partial class IdleState : Node
{
    public override void _Ready()
    {
        Player characterNode = GetOwner<Player>();
        characterNode.animPlayerNode.Play(GameConstants.ANIM_IDLE);
    }
}
