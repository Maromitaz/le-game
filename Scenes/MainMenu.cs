using Godot;
using System;

public partial class MainMenu : Control
{
    public void _on_start_game_pressed()
    {
        Globals Globals = GetNode<Globals>("/root/Globals");
        Globals.GoToScene(Globals.Scenes.map_1);
    }

    public void _on_quit_pressed()
    {
        GetTree().Quit();
    }
}
