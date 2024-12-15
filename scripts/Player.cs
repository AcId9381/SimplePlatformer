using Godot;

public partial class Player : CharacterBody2D
{
	private AnimatedSprite2D _sprite;

	public const float Speed = 130.0f;
	public const float JumpVelocity = -300.0f;

    public override void _Ready()
    {
        base._Ready();
		_sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    }

    public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("move_left", "move_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

        FlipSprite(direction);
        PlayAnimations(direction);

        Velocity = velocity;
		MoveAndSlide();
	}

	private void FlipSprite(Vector2 direction)
	{
        if (direction.X < 0)
        {
            _sprite.FlipH = true;
        }
        else if (direction.X > 0)
        {
            _sprite.FlipH = false;
        }
    }

	private void PlayAnimations(Vector2 direction)
	{
		if (IsOnFloor())
		{
			if (direction.X == 0)
			{
				_sprite.Play("idle");
			}
			else

			{
				_sprite.Play("run");
			}
		}
		else
		{
			_sprite.Play("jump");
		}
	}
}
