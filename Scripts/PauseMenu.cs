using Godot;
using System;

public partial class PauseMenu : Control
{
/////////////////////////////////////////////////////////////////////////////////////////////////////
    public void Pause()
	{
		GetTree().Paused = true;
        this.Visible = true;
        this.GetChild<AnimationPlayer>(-1).Play("pause");
	}

	public void Resume()
	{
		GetTree().Paused = false;
        this.GetChild<AnimationPlayer>(-1).PlayBackwards("pause");
        this.Visible = false;
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
    public void _on_options_pressed()
    {
        Control pauseContainer = this.GetNode<Control>("Pause Container");
        pauseContainer.Visible = false;

        Control optionsContainer = this.GetNode<Control>("Options Container");
        optionsContainer.Visible = true;
    }

    public void _on_main_menu_pressed()
    {
        Globals Globals = GetNode<Globals>("/root/Globals");
        Globals.GoToScene(Globals.Scenes.MainMenu);
        GetTree().Paused = false;
    }

    public void _on_quit_game_pressed()
    {
		GetTree().Quit();
    }

/////////////////////////////////////////////////////////////////////////////////////////////////////

    public void _on_back_pressed()
    {
        Control pauseContainer = this.GetNode<Control>("Pause Container");
        pauseContainer.Visible = true;

        Control optionsContainer = this.GetNode<Control>("Options Container");
        optionsContainer.Visible = false;
    }

    public void _on_full_screen_pressed()
    {
        if (DisplayServer.WindowGetSize().X == 1152)
        {
            DisplayServer.WindowSetSize(new Vector2I(800, 640));
        }
        if (DisplayServer.WindowGetSize().X == 800)
        {
            DisplayServer.WindowSetSize(new Vector2I(1152, 648));
        }
    }

/////////////////////////////////////////////////////////////////////////////////////////////////////
    public override void _Ready()
    {
        Control optionsContainer = this.GetNode<Control>("Options Container");
        optionsContainer.Visible = false;
        this.Visible = false;
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		IsEscPressed();
    }
}
