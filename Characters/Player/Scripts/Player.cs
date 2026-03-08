using System;
using Godot;

public partial class Player : CharacterBody2D
{
  private const float _speed = 300.0f;
  private const float _jumpVelocity = -400.0f;
  private const float _wallJumpVelocity = 300f;
  private const float _acceleration = 1000f;


  public override void _PhysicsProcess(double delta)
  {
    Vector2 velocity = Velocity;


    // Add the gravity.
    HandleGravity(ref velocity, (float)delta);


    // Get the input direction and handle the movement/deceleration.
    // As good practice, you should replace UI actions with custom gameplay actions.
    HandleMovement(ref velocity);

    // Handle Jump.
    HandleJump(ref velocity, (float)delta);

    Velocity = velocity;

    MoveAndSlide();
  }


  public override void _Input(InputEvent @event)
  {
    if (@event.IsActionPressed("ui_select"))
    {
    }
  }

  public override void _Process(double delta)
  {
  }


  private void HandleGravity(ref Vector2 velocity, float delta)
  {
    if (!IsOnFloor())
    {
      var gravity = GetGravity();
      velocity += gravity * (float)delta;
    }
  }


  private void HandleJump(ref Vector2 velocity, float delta)
  {
    if (!(Input.IsActionJustPressed("ui_select") || Input.IsActionJustPressed("ui_up"))) return;

    if (IsOnWall())
    {


      velocity.Y = _jumpVelocity;
      velocity.X += _wallJumpVelocity * Math.Sign(GetWallNormal().X);
      // velocity.X = velocity.X = Mathf.Lerp(velocity.X, _wallJumpVelocity, delta);
      return;
    }

    if (IsOnFloor()) velocity.Y = _jumpVelocity;
  }

  private void HandleMovement(ref Vector2 velocity)
  {
    float direction = Input.GetAxis("ui_left", "ui_right");

    if (direction != 0)
      velocity.X = direction * _speed;
    else
      velocity.X = Mathf.MoveToward(direction, 0, _speed);
  }
}
