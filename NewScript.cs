using Godot;
using System;
using System.Numerics;

public partial class NewScript : Sprite2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        GD.Print("Sugi pula");
        //this.Position = new Vector2(0.f, 0.f);
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
    float speed = 50.0f;
    public override void _Process(double delta)
    {
        if (Input.IsActionPressed(action: "ui_right"))
        {
            this.Position = this.Position + new Godot.Vector2((float)delta * speed, .0f);
        }
        if (Input.IsActionPressed(action: "ui_left"))
        {
            this.Position = this.Position - new Godot.Vector2((float)delta * speed, .0f);
        }
        if (Input.IsActionPressed(action: "ui_up"))
        {
            this.Position = this.Position - new Godot.Vector2(.0f, (float)delta * speed);
        }
        if (Input.IsActionPressed(action: "ui_down"))
        {
            this.Position = this.Position + new Godot.Vector2(.0f, (float)delta * speed);
        }
    }
}
