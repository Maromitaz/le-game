using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public struct SceneType
{
    public string name { get; }
    public bool isPlayable { get; }
	public SceneType(string name, bool isPlayable)
	{
		this.name = name; 
		this.isPlayable = isPlayable;
	}

	public static implicit operator string(SceneType scene)
	{
		return scene.name;
	}
}

public partial class Globals : Node
{
	public static class Scenes
    {
        public static readonly SceneType 
			MainMenu = new SceneType("res://Scenes/main_menu.tscn", false),
			map_1 = new SceneType("res://Scenes/map_1.tscn", true);
    }

    public Node CurrentScene { get; set; }
	public CharacterBody2D Player { get; set; }
	
	public override void _Ready()
	{
		Viewport root = GetTree().Root;
		this.CurrentScene = root.GetChild(-1);
	}

	public void GoToScene(SceneType scene)
	{
		CallDeferred(MethodName.DefferedGotoScene, scene.name, scene.isPlayable);
	}

	public void DefferedGotoScene(string path, bool isPlayable)
	{
		this.CurrentScene.Free();
		if(this.Player != null)
		{
            this.Player.Free();
			this.Player = null;
        }

        PackedScene nextScene = GD.Load<PackedScene>(path);

		this.CurrentScene = nextScene.Instantiate();

		if(isPlayable)
		{
			PackedScene plr = GD.Load<PackedScene>("res://Scenes/player.tscn");
			this.Player = plr.Instantiate<CharacterBody2D>();
			this.Player.Position = new Vector2(150, 150);
			GetTree().Root.AddChild(this.Player);
		}

		GetTree().Root.AddChild(this.CurrentScene);

		GetTree().CurrentScene = this.CurrentScene;
	}
}
