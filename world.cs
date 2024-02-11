using Godot;
using System;

public partial class world : Node2D
{
		private Label mylabel;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		mylabel = GetNode<Label>("Vector");
		mylabel.Text = "meme";
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
