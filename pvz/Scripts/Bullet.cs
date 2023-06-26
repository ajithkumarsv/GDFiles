using Godot;
using System;

public partial class Bullet : RigidBody3D
{
    public void OnCollide(){

        GD.PrintT("Collission success 2 ");
    }
	
}
