using Godot;
using System;
using System.Security.Cryptography.X509Certificates;


public partial class Globals : Node
{
    public static class Scenes
    {
        public const string MainMenu = "res://Scenes/main_menu.tscn";
        public const string map_1 = "res://Scenes/node_2d.tscn";
    }

    public Node CurrentScene { get; set; }
	
	public override void _Ready()
	{
		Viewport root = GetTree().Root;
		this.CurrentScene = root.GetChild(-1);
	}

	public void GoToScene(string path)
	{
		CallDeferred(MethodName.DefferedGotoScene, path);
	}

	public void DefferedGotoScene(string path)
	{
		this.CurrentScene.Free();

		PackedScene nextScene = GD.Load<PackedScene>(path);

		this.CurrentScene = nextScene.Instantiate();

		GetTree().Root.AddChild(this.CurrentScene);

		GetTree().CurrentScene = this.CurrentScene;
	}
}
