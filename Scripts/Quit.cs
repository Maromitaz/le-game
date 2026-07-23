using Godot;
using System;

public partial class Quit : Button
{
	public override void _Ready()
	{
		this.Pressed += () =>
		{
			GetTree().Quit();
		};
	}
}
