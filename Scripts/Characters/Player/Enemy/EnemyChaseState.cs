using Godot;
using System;
using System.Linq;

public partial class EnemyChaseState : EnemyState
{
    [Export] private Timer timerNode;
    private CharacterBody3D target;

    protected override void EnterState()
    {
        characterNode.AnimPlayerNode.Play(GameConstants.ANIM_MOVE);
        target = characterNode.ChaseAreaNode
        .GetOverlappingBodies()
        .First() as CharacterBody3D;
        timerNode.Timeout += HandleTimeout;
        characterNode.AttackAreaNode.BodyEntered += HandleAttackBodyAreaEntered;
        characterNode.ChaseAreaNode.BodyExited += HandleChaseAreaBodyExited;
    }




    protected override void ExitState()
    {
        timerNode.Timeout -= HandleTimeout;
        characterNode.AttackAreaNode.BodyEntered -= HandleAttackBodyAreaEntered;
        characterNode.ChaseAreaNode.BodyExited -= HandleChaseAreaBodyExited;
    }



    public override void _PhysicsProcess(double delta)
    {
        destination = target.GlobalPosition;
        characterNode.AgentNode.TargetPosition = destination;

        Move();
    }
    
    private void HandleTimeout()
    {
        characterNode.AgentNode.TargetPosition = destination;
    }

        private void HandleAttackBodyAreaEntered(Node3D body)
    {
        characterNode.StateMachineNode.SwitchState<EnemyAttackState>();
    }
        private void HandleChaseAreaBodyExited(Node3D body)
    {
        characterNode.StateMachineNode.SwitchState<EnemyReturnState>();
    }
}
