using Godot;
using System;

public partial class StartGame : Button
{
	public override void _Ready()
	{
		this.Pressed += ()=> 
		{
			Globals Globals = GetNode<Globals>("/root/Globals");
			Globals.GoToScene(Globals.Scenes.map_1);
			// SceneManager sceneManager = (SceneManager)this.FindParent("SceneManager");
			// sceneManager.EmitSignal("ChangeScene", "map_1");
		};
	}
}
