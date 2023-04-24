using Godot;
using System;
using GodotCSToolbox;

public partial class Start : Control
{
	// Called when the node enters the scene tree for the first time.
	[UniqueNode] private Label TimeLabel;
	public override void _Ready()
	{
		this.SetupNodeTools();

		TimeLabel.Text = "Hello World!";
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
}
