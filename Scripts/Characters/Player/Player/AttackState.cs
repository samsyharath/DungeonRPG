using Godot;
using System;

public partial class AttackState : PlayerState
{
    [Export] private Timer comboTimerNode;

    private int comboCounter = 1;
    private int maxComboCount = 2;

    public override void _Ready()
    {
        base._Ready();

        comboTimerNode.Timeout += () => comboCounter = 1;
    }
    protected override void EnterState()
    {
        characterNode.AnimPlayerNode.Play(GameConstants.ANIM_ATTACK + comboCounter, -1, 2.5f);
        characterNode.AnimPlayerNode.AnimationFinished += HandleAnimationFinished;
    }

    protected override void ExitState()
    {
        characterNode.AnimPlayerNode.AnimationFinished -= HandleAnimationFinished;
        comboTimerNode.Start();
    }

    private void HandleAnimationFinished(StringName animName)
    {
        comboCounter++;

        comboCounter = Mathf.Wrap(comboCounter, 1, maxComboCount + 1);
        characterNode.ToggleHitbox(true);
        characterNode.StateMachineNode.SwitchState<IdleState>();
    }

    private void PerformHit()
    {
        Vector3 newPosition = characterNode.SpriteNode.FlipH ?
            Vector3.Left :
            Vector3.Right;
        float distanceMultiplier = 0.75f;
        newPosition *= distanceMultiplier;
        characterNode.HitBoxNode.Position = newPosition;
        GD.Print("Perform Hit!");
        characterNode.ToggleHitbox(false);
    }


}
