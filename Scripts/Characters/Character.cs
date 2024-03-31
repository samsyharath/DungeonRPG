using Godot;
using System;

public abstract partial class Character : CharacterBody3D
{
    [Export] private StatResource[] stats;

    [ExportGroup("Required Nodes")]
    [Export] public AnimationPlayer AnimPlayerNode {get; private set;}
    [Export] public Sprite3D SpriteNode {get; private set;}
    [Export] public StateMachine StateMachineNode {get; private set;}
    [Export] public Area3D HurtboxNode {get; private set;}

    [ExportGroup("AI Nodes")]
    [Export] public Path3D PathNode {get; private set;}
    [Export] public NavigationAgent3D AgentNode {get; private set; }
    [Export]public Area3D ChaseAreaNode {get; private set;}
    [Export] public Area3D AttackAreaNode { get; private set;}
    
    public Vector2 direction = new();
    public override void _Ready()
    {
        HurtboxNode.AreaEntered += HandleHurtboxEntered;
    }

    private void HandleHurtboxEntered(Area3D area)
    {
        StatResource health = GetStatResource(Stat.Health);
        GD.Print(health.StatValue);
        
    }

    public StatResource GetStatResource(Stat stat)
    {
        StatResource result = null;

        foreach(StatResource element in stats){
            if (element.StatType == stat)
            {
                result = element;
            }
        }
        return result;
    }

    public void Flip()
    {
        bool isNotMovingHorizontally = Velocity.X == 0;
        if (isNotMovingHorizontally) { return; }
        bool isMovingLeft = Velocity.X < 0;
        SpriteNode.FlipH = isMovingLeft;
    }
}