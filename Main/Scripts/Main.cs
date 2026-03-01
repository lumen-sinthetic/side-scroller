using Godot;
using System;

public partial class Main : Node
{
  // Called when the node enters the scene tree for the first time.
  public override void _Ready()
  {
    // var camera = GetTree().GetFirstNodeInGroup("player_camera") as Camera2D;
    // GD.Print(camera);
    // camera?.MakeCurrent();
    // var camera = FindChild("ViewCam", true, false) as Camera2D;

    // GD.Print(camera, camera?.IsCurrent());

  }

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(double delta)
  {
  }
}
