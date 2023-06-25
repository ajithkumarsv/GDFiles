using Godot;
using System;
using System.Diagnostics;


public partial class ObjectCollider : CollisionShape3D
{
	public void OnCollide(){
		GD.Print("collided success");
	}
}
