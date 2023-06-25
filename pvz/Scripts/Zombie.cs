using Godot;
using System;

public partial class Zombie : Area3D
{
	public void OnCollide(){
		GD.Print("Area collided");
	}
}
