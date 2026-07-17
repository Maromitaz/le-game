using Godot;

public partial class NewScript : CharacterBody2D
{
    [Export]
    float speed { get; set; } = 400.0f;

    public void GetInput()
    {
        var inputDirection = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
        Velocity = inputDirection * speed;
    }

    public override void _PhysicsProcess(double delta)
    {
        this.GetInput();
        var collision = MoveAndCollide(Velocity * (float)delta);
        if (collision != null)
        {
            Velocity = Velocity.Slide(collision.GetNormal());
        }
        //MoveAndSlide();
    }
}
