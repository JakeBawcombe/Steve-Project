using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed = 3; // Controls how fast Steve moves
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>(); // References the animator in Unity
    }

    void Update()
    {
        ControllPlayer(); //Calls Method
    }

    void ControllPlayer()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal"); // Gets horizontal input
        float moveVertical = Input.GetAxisRaw("Vertical"); // Gets vertical input

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); // X,Y,Z.

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f); 
            anim.SetInteger("Walk", 1); // Allows animations to swap between idle and walk, Sets to walk to true so idle is false
        }
        else
        {
            anim.SetInteger("Walk", 0); // Allows animations to swap between idle and walk, Sets walk to false so idle is true
        }

        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World); // Allows my character to move around in a 3D environment

    }
}
