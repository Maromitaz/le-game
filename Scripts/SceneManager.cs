using Godot;
using Godot.Collections;
using System;

public partial class SceneManager : Node
{
    [Export]
    public String CurrentScene { get; set; } = "";

    PackedScene Player = GD.Load<PackedScene>("res://Scenes/player.tscn");

    static private PackedScene SceneLoader(String path)
    {
        return GD.Load<PackedScene>(path);
    }

    private void killAllChildren()
    {
        foreach (var scene in this.GetChildren())
        {
            scene.QueueFree();
        }
    }

    Dictionary Playable = new Dictionary
    {
        {"map_1", true},
    };

    Dictionary Scenes = new Dictionary
    {
        { "MainMenu", "res://Scenes/main_menu.tscn" },
        { "map_1", "res://Scenes/map_1.tscn" },
    };

    public PackedScene GetScene(String name)
    {
        return SceneLoader(Scenes[name].As<String>());
    }

    //public void LoadFirstScene()
    //{
    //    this.killAllChildren();

    //    CharacterBody2D PlayerInstance = (CharacterBody2D)(Player.Instantiate());
    //    this.CurrentScene = "map_1";
    //    PackedScene currentInstance = GetScene(this.CurrentScene);
    //    Node instance = currentInstance.Instantiate();

    //    PlayerInstance.Position = new Vector2(400, 300);

    //    AddChild(instance);
    //    AddChild(PlayerInstance);
    //}

    //private void LoadMainMenu()
    //{
    //    this.killAllChildren();
    //    this.CurrentScene = "MainMenu";
    //    PackedScene MainMenu = GetScene(this.CurrentScene);
    //    Node MenuInstance = MainMenu.Instantiate();

    //    AddChild(MenuInstance);
    //}

    private bool IsScenePlayable(String name)
    {
        try
        {
            return Playable[name].As<bool>();
        }
        catch
        { 
            return false; 
        }

    }

    [Signal]
    public delegate void ChangeSceneEventHandler(String name);

    private async void ChangeSceneFunc(String name)
    {
        this.killAllChildren();

        await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);

        this.CurrentScene = name;
        PackedScene MainMenu = GetScene(this.CurrentScene);
        Node MenuInstance = MainMenu.Instantiate();
        AddChild(MenuInstance);
        if (IsScenePlayable(name))
        {
            CharacterBody2D PlayerInstance = (CharacterBody2D)(Player.Instantiate());
            PlayerInstance.Position = new Vector2(400, 300);
            AddChild(PlayerInstance);
        }
    }


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        //Connect(ChangeSceneEventHandler, Callable.From<String>(ChangeSceneFunc));
        ChangeScene += this.ChangeSceneFunc;
        EmitSignal("ChangeScene", "MainMenu");
        //LoadMainMenu();
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//GD.Print(this.GetChild(0));
		//this.GetChild(0).QueueFree();
    }
}
