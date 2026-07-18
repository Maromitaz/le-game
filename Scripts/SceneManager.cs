using Godot;
using System;

public partial class SceneManager : Node
{
	[Export]
	public short CurrentScene = 0;

	PackedScene[] Scenes =
    {
        GD.Load<PackedScene>("res://Scenes/node_2d.tscn"),
    };
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		var instance = Scenes[this.CurrentScene].Instantiate();
		AddChild(instance);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		GD.Print(this.GetChild(0));
		//this.GetChild(0).QueueFree();
    }
}
