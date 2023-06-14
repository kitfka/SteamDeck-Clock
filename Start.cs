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
	[UniqueNode] private AudioStreamPlayer AudioStreamPlayer;

	private bool WorkLoop = false;
	private bool running = false;

	public override void _Ready()
	{
		this.SetupNodeTools();
	}

	private double counter = 0;
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		TimeLabel.Text = DateTime.Now.ToString("h:mm:ss tt"); // this is wierd?

		if (running)
		{
			counter += delta;
			if (counter > 1.0)
			{
				counter -= 1.0;

				SecondSlot.ChangeTheValue(-1);

				if (SecondSlot.Value == 0 && MinuteSlot.Value == 0 && HourSlot.Value == 0)
				{
					running = false;
					AudioStreamPlayer.Play();
					if (WorkLoop)
					{
						WorkLoop = false;
						MinuteSlot.Value = 5;
						running = true;
					}
				}
			}
		}
	}

	public void _on_button_pressed()
	{
		if (SecondSlot.Value != 0 || MinuteSlot.Value != 0 || HourSlot.Value != 0)
		{
			running = true;
		}
	}
	private void _on_button_2_pressed()
	{
		// Replace with function body.
		
		WorkLoop = true;
		SecondSlot.Value = 0;
		MinuteSlot.Value = 20;
		HourSlot.Value = 0;
		running = true;
	}
}


