using Godot;
using System;

public partial class StartGame : Button
{
	public override void _Ready()
	{
		this.Pressed += ()=> 
		{
            SceneManager sceneManager = (SceneManager)this.FindParent("SceneManager");
			sceneManager.EmitSignal("ChangeScene", "map_1");
		};
	}
}
