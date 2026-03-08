using Godot;
using System;
using System.Threading.Tasks;

public partial class Main : Node
{
  [Export]
  public MainMenu Menu = null!;

  private const string _gameScenePath = "res://Systems/Game/Game.tscn";

  // Called when the node enters the scene tree for the first time.
  public override void _Ready()
  {
    // var camera = GetTree().GetFirstNodeInGroup("player_camera") as Camera2D;
    // GD.Print(camera);
    // camera?.MakeCurrent();
    // var camera = FindChild("ViewCam", true, false) as Camera2D;

    // GD.Print(camera, camera?.IsCurrent());
    Menu.PlayGame += OnGameStart;
  }

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(double delta)
  {
  }


  private void OnGameStart()
  {
    var packed = ResourceLoader.Load<PackedScene>(_gameScenePath);

    if (packed is null)
    {
      OS.Crash("Failed to load main game scene");
      return;
    }

    AddChild(packed.Instantiate());
    Menu.QueueFree();


    // var scene = packed.Instantiate();


    // if (ResourceLoader.HasCached(path))
    // {
    //   return;
    // }

    // var a = ResourceLoader.LoadThreadedRequest(path);
    // var loader = ResourceLoader.LoadThreadedGet(path);
    // loader.GetLocalScene()




    // loader.Load
    // loader.


    // loader.


    // loader.Get
    // loader.

    // while (!loader.IsComplete())
    // {
    //   loader.Poll(); // Подгружаем порциями
    //   await Task.Delay(10); // Ждём кадр
    // }

    // var scene = loader.GetResource<PackedScene>();
    // if (scene != null)
    // {
    //   Node instance = scene.Instantiate();
    //   AddChild(instance);
    // }
  }
}
