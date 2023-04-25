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
			if (value >= 60)
			{
				EmitSignal(SignalName.IntOverflow);
			}
			if (value < 0)
			{
				myVar = 59;
				EmitSignal(SignalName.IntUnderflow);
			}

			myVar = value switch
			{
				60 => 0,
				-1 => 59,
				_ => value,
			};

			thing();
		}
	}
	private bool IsPressed = false;
	private double pressIndex = -0.3;

	private int Direction = 0;

	[Export] private double RePressSpeed = 0.1;
	

	[Signal] public delegate void ValueChangedEventHandler(int newValue);
	[Signal] public delegate void IntOverflowEventHandler();
	[Signal] public delegate void IntUnderflowEventHandler();


	[UniqueNode] private Label Label;

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
	public override void _Process(double delta) 
	{ 
		if (IsPressed)
		{
			pressIndex += delta;
			if (pressIndex > RePressSpeed)
			{
				pressIndex -= RePressSpeed;
				Value += Direction;
			}
		}
	}

	public void ChangeTheValue(int value)
	{
		Value += value;
	}

	
	public void _on_up_button_button_down()
	{
		Value += 1;
		IsPressed = true;
		Direction = 1;
	}

	public void _on_down_button_button_down()
	{
		Value -= 1;
		IsPressed = true;
		Direction = -1;
	}

	public void _on_button_up()
	{
		IsPressed = false;
		Direction = 0;
		pressIndex = -0.3;
	}
}
