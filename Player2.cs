using Godot;
using Godot.NativeInterop;
using System;

public partial class Player2 : CharacterBody2D
{
	const float MOV_SPEED = 100.0F;

	AnimationPlayer animateWalk = null;
	Sprite2D characterSprite = null;
	AnimationTree animationT = null;
	public static  Vector2 inputVector = Vector2.Zero;


	//Kinda hacky, this is the variable for the Statemachine playback
	//GDOT Why do you do this
	AnimationNodeStateMachinePlayback animationStateMachine = null;
    public override void _Ready()
    {
        animateWalk = GetNode<AnimationPlayer>("AnimationPlayer");
		characterSprite = GetNode<Sprite2D>("Sprite");
		animationT = GetNode<AnimationTree>("AnimationTree");
		animationStateMachine = (AnimationNodeStateMachinePlayback)(GetNode<AnimationTree>("AnimationTree").Get("parameters/playback"));
    }	
    public override void _PhysicsProcess(double delta)
	{
		inputVector = Vector2.Zero;
		
		inputVector.X = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");
		inputVector.Y = Input.GetActionStrength("ui_down") - Input.GetActionStrength("ui_up");
		inputVector = inputVector.Normalized();	
		if(inputVector != Vector2.Zero){
			GD.Print(inputVector.X +" - ",inputVector.Y);
			if(inputVector.X  == 1){
				characterSprite.FlipH = true;
			}
			else{
				characterSprite.FlipH = false;
			}
			animationT.Set("parameters/Idle/blend_position", inputVector);
			animationT.Set("parameters/Walk/blend_position", inputVector);
			animationStateMachine.Travel("Walk");		
		}
		else{
			animationStateMachine.Travel("Idle"); 
			Velocity = Vector2.Zero;
		}
		Velocity = inputVector * MOV_SPEED;
		MoveAndSlide();		

	}
}
