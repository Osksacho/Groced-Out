using Godot;
using System;

public partial class player : CharacterBody3D
{
	public const float Speed = 5.0f;
    public const float RotationSpeed = 10.0f;

    private AnimationPlayer animPlayer;
    private Node3D model;

    public override void _Ready()
    {
        animPlayer = GetNode<AnimationPlayer>("model/AnimationPlayer");
        model = GetNode<Node3D>("model");
    }

    public override void _PhysicsProcess(double delta)
	{
		Vector3 velocity = Velocity;

        Vector2 inputDir = Input.GetVector("move_left", "move_right", "move_forward", "move_backward");
        Vector3 direction = new Vector3(inputDir.X, 0, inputDir.Y).Normalized();


        Velocity = direction * Speed;

        if (animPlayer != null)
        {
            if (Velocity.Length() != 0 && animPlayer.CurrentAnimation != "run")
                animPlayer.Play("run");
            if (Velocity.Length() == 0 && animPlayer.CurrentAnimation != "Idle")
                animPlayer.Play("Idle");
        }

        MoveAndSlide();

        if (velocity.Length() > 0)
        {
            
            Vector3 currentRotation = model.Rotation;

            float targetRotationY = Mathf.Atan2(velocity.X, velocity.Z)- Mathf.Pi;
            float newYRotation = Mathf.LerpAngle(currentRotation.Y, targetRotationY, RotationSpeed * (float)delta);

            Vector3 newRotation = new Vector3(currentRotation.X, newYRotation, currentRotation.Z);
            model.Rotation = newRotation;
        }

    }
}
