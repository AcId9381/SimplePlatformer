using Godot;
using System;

public partial class Slime : Node2D	
{
	private RayCast2D _rayCastRight, _rayCastLeft;
	private AnimatedSprite2D _sprite;

	public float Speed = 60.0f;
	public int Direction = 1;

    public override void _Ready()
    {
        base._Ready();
		_rayCastRight = GetNode<RayCast2D>("RayCastRight");
		_rayCastLeft = GetNode<RayCast2D>("RayCastLeft");
		_sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    }
    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
		base._Process(delta);

		if (_rayCastRight.IsColliding())
		{
			Direction = -1;
			_sprite.FlipH = true;
		}
		else if (_rayCastLeft.IsColliding())
		{
			Direction = 1;
			_sprite.FlipH = false;
		}

		Position += new Vector2(
			(float)(Direction * Speed * delta),
			0.0f);
	}
}
