using Godot;
using System;
using System.Collections.Generic;


public delegate void Damage();

public delegate void Move();
public partial class Plant : Area3D
{
	[Export] PackedScene Bullet;
	[Export] PackedScene pea;
	[Export] RayCast3D hit;
	[Export] Marker3D ShootPos;
	public event Damage OnDamage;
	public event Move OnMove;

	public double ShootingTime = 0;
	public double ShootWaitingTime = 2;

	// public static List<Pea> peas = new List<Pea>();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		OnDamage += OnDamageFn;

	}

	public override void _ExitTree()
	{
		GD.Print("Destructor");
		OnDamage -= OnDamageFn;
	}
	public void OnDamageFn()
	{
		
	}
	public override void _Process(double delta)
	{
		ShootingTime += delta;
		if (ShootingTime > ShootWaitingTime)
		{
			if (hit.IsColliding())
			{
				var x = hit.GetCollider();
				if (x is Zombie)
				{
					// Zombie objectCollider = hit.GetCollider() as Zombie;

					// objectCollider.OnCollide();
					Shoot();
					ShootingTime = 0;
				}
			}
		}
		if (Input.IsActionJustPressed("Fire"))
		{

			// QueueFree();
			// var x = Bullet.Instantiate<Bullet>();
			// AddChild(x);
			// GD.Print("input working");
			// OnDamage?.Invoke();
		}
	}
	public void Shoot()
	{
		GD.Print("OnFires");
		Pea p = pea.Instantiate<Pea>();
		p.Position =ShootPos.Position;
		GetTree().Root.AddChild(p);

	}
}
