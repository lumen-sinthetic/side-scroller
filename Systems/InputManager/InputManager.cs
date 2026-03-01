using Godot;
using System;

public partial class InputManager : Node
{
  // Called when the node enters the scene tree for the first time.
  public override void _Ready()
  {
  }

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(double delta)
  {
  }

  public override void _Input(InputEvent @event)
  {
    HandleToggleFullscreen(@event);
  }


  private void HandleToggleFullscreen(InputEvent inputEvent)
  {
    if (!inputEvent.IsActionPressed("toggle_fullscreen")) return;

    var currentMode = DisplayServer.WindowGetMode();
    bool isCurrentlyFullscreen = currentMode == DisplayServer.WindowMode.Fullscreen;

    DisplayServer.WindowSetMode(isCurrentlyFullscreen ? DisplayServer.WindowMode.Windowed : DisplayServer.WindowMode.Fullscreen);
  }
}
