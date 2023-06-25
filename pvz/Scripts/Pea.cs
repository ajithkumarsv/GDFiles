using Godot;
using System;

public partial class Pea : MeshInstance3D
{
	[Export] float speed;
	public override void _Process(double delta)
	{
		Translate(Vector3.Right * speed);
	}
	public void OnAreaEntered(Area3D area)
	{
		GD.Print("Area name" + area.Name);
	}
}
