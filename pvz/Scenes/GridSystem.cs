using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;

struct GridPosition
{

	public float XValue;
	public float ZValue;
	public GridPosition(float x, float z)
	{
		XValue = x;
		ZValue = z;
	}



}
public partial class GridSystem : Node3D
{
	Vector3 GridStartPosition;
	[Export] PackedScene TestPos;
	[Export] float offset = 5;
	[Export] float Row, Column;
	

	List<GridPosition> gridPositions = new List<GridPosition>();
	public override void _Ready()
	{
		GridStartPosition = Position;
		for (int i = 0; i < Row; i++)
		{
			for (int j = 0; j < Column; j++)
			{
				gridPositions.Add(new GridPosition(i * (offset) + GridStartPosition.X, j * (offset) + GridStartPosition.Z));
				var x = TestPos.Instantiate() as MeshInstance3D;
				AddChild(x);
				x.Position = new Vector3(i * (offset) + GridStartPosition.X, 0, j * (offset) + GridStartPosition.Z);

				// GD.Print($"row {i * (offset) + GridStartPosition.X} : column {j * (offset) + GridStartPosition.Z}");

			}
		}
		foreach (GridPosition i in gridPositions)
		{
			GD.Print($"row {i.XValue} : column {i.ZValue}");
		}

	}

	public override void _Process(double delta)
	{
		
		//GD.Print(GetViewport().GetMousePosition() + " is the position");
		 var camera3D = GetParent(). GetNode<Camera3D>("Camera3D");
		var mousePosition= GetViewport().GetMousePosition();
        var from = camera3D.ProjectRayOrigin(mousePosition);
        var to = from + camera3D.ProjectRayNormal(mousePosition) *100;

		var spaceState = GetWorld3D().DirectSpaceState;
        var query = PhysicsRayQueryParameters3D.Create(from, to);
		
        query.Exclude = new Godot.Collections.Array<Rid> { };
		query .CollideWithAreas =true;
		query.CollideWithBodies=false;
        Dictionary result = spaceState.IntersectRay(query);
		if(result.Count>0){
			//GD.Print ("hit");
			foreach(KeyValuePair<Variant,Variant> x  in result)
			{
				//x.Value
				GD.Print(x.Value.AsGodotObject());
				// var y= x.Value as Node3D;
				// GD.Print((y.Name));
			}
		}
	}
	public override void _Input(InputEvent @event)
	{

	}

	public void GetNearestOrNull()
	{



	}
}
