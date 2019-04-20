// __________________________________
// Babby's first Movement script 
// (for player paddle)
// __________________________________
// bhardy 4/19/19
//-----------------------------------
//
// LEGGO:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Declare class "PlayerControls", and a few other variables:
public class PlayerControls : MonoBehaviour
{
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public KeyCode startGame = KeyCode.Return;
    private KeyCode eEgg = KeyCode.Backslash;
    public float speed = 10.0f;
    public float boundY = 2.25f;
    private Rigidbody2D rb2d;

    // Start is a function that is called when game is launched:

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called *once per frame*. 
    // Here, we're using it to act on keypresses and to keep the paddle still if nothing is pressed.
    // Also, keeps the paddle between +boundY and -boundY, which are our Y axis bounds:
    void Update()
    {
        var vel = rb2d.velocity;
        if (Input.GetKey(moveUp))
        { // If W is pressed, then...
            vel.y = speed;         // ... velocity on Y axis is changed (move up).
        }
        else if (Input.GetKey(moveDown))
        {
            vel.y = -speed;
        }
        else
        {
            vel.y = 0;              // Otherwise, we ain't doin shit (no movement).
        }
        rb2d.velocity = vel;

        // Bounds checking:
        var pos = transform.position;
        if (pos.y > boundY)
        {       // If we're out of bounds...
            pos.y = boundY;         // ... then stay in yo' lane.
        }
        else if (pos.y < -boundY)
        {
            pos.y = -boundY;
        }
        transform.position = pos;
    }
}