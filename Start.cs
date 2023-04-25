using Godot;
using System;
using GodotCSToolbox;

public partial class Start : Control
{
	// Called when the node enters the scene tree for the first time.
	[UniqueNode] private Label TimeLabel;
	[UniqueNode] private time_slot HourSlot;
	[UniqueNode] private time_slot MinuteSlot;
	[UniqueNode] private time_slot SecondSlot;


	public override void _Ready()
	{
		this.SetupNodeTools();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		TimeLabel.Text = DateTime.Now.ToString("h:mm:ss tt"); // this is wierd?
	}

	public void _on_button_pressed()
	{
		
	}
}
