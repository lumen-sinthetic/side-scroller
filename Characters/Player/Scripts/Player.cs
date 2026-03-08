using Godot;
using System;

public partial class Player : CharacterBody2D
{
  public const float Speed = 300.0f;
  public const float JumpVelocity = -400.0f;

  public override void _PhysicsProcess(double delta)
  {
    Vector2 velocity = Velocity;


    // Add the gravity.
    if (!IsOnFloor())
    {
      velocity += GetGravity() * (float)delta;
    }


    // Handle Jump.
    if (IsOnFloor()) HandleJump(ref velocity);

    // Get the input direction and handle the movement/deceleration.
    // As good practice, you should replace UI actions with custom gameplay actions.
    HandleMovement(ref velocity);

    Velocity = velocity;

    MoveAndSlide();


    // GD.Print("IsOnFloor: ", IsOnFloor());
    // GD.Print("IsOnWall: ", IsOnWall());
  }


  private void HandleJump(ref Vector2 velocity)
  {
    if (Input.IsActionJustPressed("ui_select") || Input.IsActionJustPressed("ui_up"))
    {
      velocity.Y = JumpVelocity;
    }
  }

  private void HandleMovement(ref Vector2 velocity)
  {
    float direction = Input.GetAxis("ui_left", "ui_right");

    if (direction != 0)
      velocity.X = direction * Speed;
    else
      velocity.X = Mathf.MoveToward(direction, 0, Speed);

  }
}
