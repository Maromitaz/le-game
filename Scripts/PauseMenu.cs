using Godot;
using System;

public partial class PauseMenu : Control
{
	public void Pause()
	{
		GetTree().Paused = true;
		this.GetChild<AnimationPlayer>(1).Play("pause");
	}

	public void Resume()
	{
		GetTree().Paused = false;
        this.GetChild<AnimationPlayer>(1).PlayBackwards("pause");
	}

	public void IsEscPressed()
	{
		if (Input.IsActionJustPressed("ui_cancel") && GetTree().Paused == false)
		{
			Pause();
		}
		else if(Input.IsActionJustPressed("ui_cancel") && GetTree().Paused)
		{
			Resume();
		}
	}

    public void _on_resume_game_pressed()
    {
		Resume();
    }

    public void _on_main_menu_pressed()
    {
        Globals Globals = GetNode<Globals>("/root/Globals");
        Globals.GoToScene(Globals.Scenes.MainMenu);
        GetTree().Paused = false;
        //SceneManager sceneManager = (SceneManager)this.FindParent("SceneManager");
        //sceneManager.EmitSignal("ChangeScene", "MainMenu");
    }

    public void _on_quit_game_pressed()
    {
		GetTree().Quit();
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		IsEscPressed();
    }
}
