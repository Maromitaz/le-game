using Godot;

public partial class NewScript : CharacterBody2D
{
    [Export]
    float speed { get; set; } = 400.0f;

    [Export]
    Vector2 CameraOffset { get; set; } = new Vector2(0, 0);

    public void GetInput()
    {
        float MaxVelocity = 1000.0f;
        var inputDirection = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
        var vel = inputDirection * speed;
        if(vel == Vector2.Zero) vel = Vector2.Zero;
        Velocity += vel;
        if(inputDirection.Length() == 0)
        {
            Velocity -= Velocity / 2.0f;
        }
        if (Velocity.Length() > MaxVelocity) Velocity = Velocity.Normalized() * MaxVelocity;
        CameraOffset = Velocity / 50.0f;
    }

    public override void _PhysicsProcess(double delta)
    {
        var map = GetNode<StaticBody2D>("../Map1");

        this.GetInput();
        Camera2D camera = GetNode<Camera2D>("Camera2D");
        float maxCameraOffset = 7.5f;
        if (CameraOffset.X > maxCameraOffset) CameraOffset = new Vector2(maxCameraOffset, CameraOffset.Y);
        if (CameraOffset.Y > maxCameraOffset) CameraOffset = new Vector2(CameraOffset.X, maxCameraOffset);
        if (CameraOffset.X < -maxCameraOffset) CameraOffset = new Vector2(-maxCameraOffset, CameraOffset.Y);
        if (CameraOffset.Y < -maxCameraOffset) CameraOffset = new Vector2(CameraOffset.X, -maxCameraOffset);
        camera.Offset = CameraOffset;
        var collision = MoveAndCollide(Velocity * (float)delta);
        if (collision != null)
        {
            Velocity = Velocity.Slide(collision.GetNormal());
        }
    }
}
