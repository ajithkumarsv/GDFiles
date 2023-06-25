using Godot;
using System;

public partial class GridSystem : Node3D
{
	Vector3 GridStartPosition;
	[Export] float offset=5;
	[Export] float Row,Column;
	 public override void _Ready(){
		GridStartPosition = Position;
		for(int i = 0; i < Row;i++){
			for(int j = 0;j<Column;j++){
				GD.Print($"row {Row*offset} : column {Column*offset}");
			}
		}

	}
}
