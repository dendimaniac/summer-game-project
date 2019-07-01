using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;        //Allows us to use SceneManager

//Player inherits from MovingObject, our base class for objects that can move, Enemy also inherits from this.
public class PlayerMovement : MovingObject
{
    private Vector3 lastPosition;

    //Start overrides the Start function of MovingObject
    protected override void Start()
    {
        //Call the Start function of the MovingObject base class.
        base.Start();
    }

    // protected void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.CompareTag("Enemy"))
    //     {
    //         Restart();
    //     }
    // }

    private void Update()
    {
        //If it's not the player's turn, exit the function.
        if (!GameManager.instance.isPlayerTurn) return;

        SavePosition();

        CheckNextTrack();

        CheckMovement();
    }

    private void SavePosition()
    {
        if (transform.position != lastPosition)
        {
            lastPosition = transform.position;
            positionList.Add(transform.position);
        }
    }

    private void CheckNextTrack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            List<Vector3> clonePosList = new List<Vector3>(positionList);
            GameManager.instance.PassMoveRoute(clonePosList);
            positionList.Clear();
            positionList.Add(transform.position);
        }
    }

    private void CheckMovement()
    {
        int horizontal = 0;      //Used to store the horizontal move direction.
        int vertical = 0;        //Used to store the vertical move direction.

        //Get input from the input manager, round it to an integer and store in horizontal to set x axis move direction
        horizontal = (int)(Input.GetAxisRaw("Horizontal"));

        //Get input from the input manager, round it to an integer and store in vertical to set y axis move direction
        vertical = (int)(Input.GetAxisRaw("Vertical"));

        //Check if moving horizontally, if so set vertical to zero.
        if (horizontal != 0)
        {
            vertical = 0;
        }

        //Check if we have a non-zero value for horizontal or vertical
        if (horizontal != 0 || vertical != 0)
        {
            GameManager.instance.isPlayerTurn = false;
            AttemptMove(horizontal, vertical);
        }
    }

    //AttemptMove overrides the AttemptMove function in the base class MovingObject
    //AttemptMove takes a generic parameter T which for Player will be of the type Wall, it also takes integers for x and y direction to move in.
    protected override void AttemptMove(int xDir, int yDir)
    {
        //Call the AttemptMove method of the base class, passing in the component T (in this case Wall) and x and y direction to move.
        base.AttemptMove(xDir, yDir);
    }

    //OnCantMove overrides the abstract function OnCantMove in MovingObject.
    //It takes a generic parameter T which in the case of Player is a Wall which the player can attack and destroy.
    protected override void OnCantMove<T>(T component)
    {
    }

    //Restart reloads the scene when called.
    private void Restart()
    {
        //Load the last scene loaded, in this case Main, the only scene in the game.
        SceneManager.LoadScene(0);
    }
}