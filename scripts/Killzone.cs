using Godot;

public partial class Killzone : Area2D
{
    private Timer _timer;
    public override void _Ready()
    {
        base._Ready();
        _timer = GetNode<Timer>("Timer");
    }
    public void OnBodyEntered(Node2D body)
    {
        GD.Print("You died!");
        Engine.TimeScale = 0.5;

        if(body.GetNode<CollisionShape2D>("CollisionShape2D") is CollisionShape2D collisionShape2D)
        {
            collisionShape2D.QueueFree();
        }

        _timer.Start();
    }

    public void OnTimerTimeout()
    {
        Engine.TimeScale = 1.0;
        GetTree().ReloadCurrentScene();
    }
}
