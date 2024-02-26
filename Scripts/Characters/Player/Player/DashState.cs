using Godot;
using System;

public partial class DashState : PlayerState
{
	[Export] private Timer dashTimerNode;
	[Export(PropertyHint.Range, "0,30,0.1")] private float speed = 10;
	public override void _Ready()
	{
		base._Ready();
		dashTimerNode.Timeout += HandleDashTimeout;
	}
	protected override void EnterState()
	{
		characterNode.AnimPlayerNode.Play(GameConstants.ANIME_DASH);
		characterNode.Velocity = new(
			characterNode.direction.X, 0, characterNode.direction.Y
			);

			if (characterNode.Velocity == Vector3.Zero) {
				characterNode.Velocity = characterNode.SpriteNode.FlipH ?
				Vector3.Left :
				Vector3.Right;
			}
			characterNode.Velocity *= speed;
			dashTimerNode.Start();
	}
	public override void _PhysicsProcess(double delta)
    {
        
		characterNode.MoveAndSlide();
		characterNode.Flip();

    }
	private void HandleDashTimeout()
	{
		characterNode.Velocity = Vector3.Zero;
		characterNode.StateMachineNode.SwitchState<IdleState>();
	}
    
}