using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    //References the CharacterController2D script by making a variable to use in this script
    public CharacterController2D controller;

    //A variable to set the speed of the paddle.
    public float paddleSpeed = 40f;

    //The direction of movement of the paddles.
    float paddleMove = 0f;

    // Update is called once per frame
    void Update()
    {
        //Grabs player input, with w key or up arrow key = to 1  and s key or down arrow key = -1
        //Multiplying paddleMove by Input and paddleSpeed gives paddleMove both a direction and speed. 
        //So paddleMove repesents the paddle's velocity.
        paddleMove = Input.GetAxisRaw("Vertical") * paddleSpeed;
    }

    void FixedUpdate()
    {
        //This moves our character according to the paddle move variable
        //The Move() function is a function of the CharacterController2D script which I shamelessly downloaded online.
        //In reading the script, I found that the Move() function requires three inputs as follows.
        //Move(float move, bool crouch, bool jump)
        //Since we aren't going to make the paddles jump or crouch, we will set the values to false.

        //From the documentation (https://docs.unity3d.com/ScriptReference/Time-deltaTime.html):
        //Use Time.deltaTime to move a GameObject in the y direction, at n units per second. Multiply n by Time.deltaTime and add to the y component.
        //If we don't incorporate the Time.fixedDeltaTime, movement could be affected by changes in framerate.

        controller.Move((paddleMove * Time.fixedDeltaTime), false, false);
    }
}
