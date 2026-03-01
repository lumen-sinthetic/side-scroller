using Godot;
using System;

public partial class MainMenu : Control
{
  [ExportGroup("MenuOptions")]
  [Export] public Button PlayButton = null!;
  [Export] public Button OptionsButton = null!;
  [Export] public Button ExitButton = null!;


  [Signal]
  public delegate void PlayGameEventHandler();




  // Called when the node enters the scene tree for the first time.
  public override void _Ready()
  {
    PlayButton.ButtonUp += HandlePlayGame;
    OptionsButton.ButtonUp += HandleOptionsOpen;
    ExitButton.ButtonUp += HanleExitGame;
  }

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(double delta)
  {
  }

  private void HandlePlayGame() => EmitSignal("play_game");

  private void HandleOptionsOpen() { }

  private void HanleExitGame() => OS.Kill(0);
}
