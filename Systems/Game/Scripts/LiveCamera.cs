using Godot;
using System;

public partial class Camera : Camera2D
{
  [Export]
  public Node2D Target = null!;

  private const float _cameraSpeed = 1.5f;
  private const float _verticalTreshold = 125f;
  private const float _horizontalTreshold = 400f;
  private const float _maxHorizontalCameraOffset = 210f;
  private const float _maxVerticalCameraOffset = 120f;


  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(double delta)
  {
    if (Target is CharacterBody2D character)
      HandleCursorMove(character, (float)delta);
    else
      Position = Target.Position;

  }

  private void HandleCursorMove(CharacterBody2D target, float delta)
  {
    var targetPos = target.Position;
    var cursorPos = GetLocalMousePosition();

    if (Math.Abs(cursorPos.X) >= _horizontalTreshold)
    {

      float offset = Math.Min(_maxHorizontalCameraOffset, Math.Abs(cursorPos.X));
      targetPos.X += offset * Math.Sign(cursorPos.X);
    }

    if (cursorPos.Y < 0 && Math.Abs(cursorPos.Y) >= _verticalTreshold)
    {
      float offset = Math.Min(_maxVerticalCameraOffset, Math.Abs(cursorPos.Y));
      targetPos.Y += offset * Math.Sign(cursorPos.Y);
    }

    float speedMultiplier = target.Velocity == Vector2.Zero ? 1f : 2f;
    Position = Position.Lerp(targetPos, _cameraSpeed * delta * speedMultiplier);
  }
}
