using Godot;
using System;

public partial class floor : MeshInstance3D
{
    private static Random random = new Random(10);

    public override void _Ready()
    {
        StandardMaterial3D material = (StandardMaterial3D)GetSurfaceOverrideMaterial(0);

        if (material != null)
        {

            material.Uv1Offset = new Vector3(random.Next(2) * 0.5f, random.Next(2) * 0.5f, 0);
            MaterialOverride = material;
        }
    }

}
