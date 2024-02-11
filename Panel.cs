using Godot;
using System;


public partial class Panel : Godot.Panel
{
	// Called when the node enters the scene tree for the first time.
				private Label mylabel;
	public override void _Ready()
	{
		mylabel = GetNode<Label>("Vector");
		mylabel.Text = "meme";
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		mylabel.Text = Player2.inputVector.ToString();
		
	}
}
