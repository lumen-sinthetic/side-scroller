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
		HandleCursorMove(delta);
	}



	private void HandleCursorMove(double delta)
	{
		var targetPos = Target.Position;
		var cursorPos = GetLocalMousePosition();

		GD.Print(cursorPos);

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


		float speed = _cameraSpeed * (float)delta;


		if (Target is CharacterBody2D character)
		{
			Position = Position.Lerp(targetPos, character.Velocity == Vector2.Zero ? speed : speed * 2);
		}
		else
		{
			Position = Position.Lerp(targetPos, speed);
		}
	}
}
