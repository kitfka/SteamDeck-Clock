using Godot;
using System;
using GodotCSToolbox;

public partial class time_slot : Control
{
	// Called when the node enters the scene tree for the first time.
	private int myVar;
	public int Value
	{
		get { return myVar; }
		set 
		{ 
			myVar = value; 
			thing();	
		}
	}

	[Signal]
	public delegate void ValueChangedEventHandler(int newValue);


	[UniqueNode]
	private Label Label;

	public override void _Ready()
	{
		this.SetupNodeTools();
	}

	private void thing()
	{
		Label.Text = Value.ToString("D2");
		EmitSignal(SignalName.ValueChanged);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) { }

	
	public void _on_up_button_button_down()
	{
		Value += 1;
	}

	public void _on_down_button_button_down()
	{
		Value -= 1;
	}
}
