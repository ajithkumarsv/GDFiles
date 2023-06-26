using Godot;
using System;

public partial class Zombie : Area3D
{
	[Export ] float speed =1;
	public override void _Process(double delta){
 Position += Vector3.Left*speed;
	}
}
