using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f; // speed of the player

    public static bool canMove = true;

    Rigidbody2D rb2d; // rigidbody 2d of the gameObject(Player)


    public float Velocity
    {
        get
        {
            return rb2d.velocity.sqrMagnitude;
        }
    }

    public float DirectionX
    {
        get
        {
            return rb2d.velocity.x;    
        }
    }


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        if (!canMove)
            return;

        Vector2 direction = new Vector3(Input.GetAxis("Horizontal") , Input.GetAxis("Vertical"));

        rb2d.AddForce(direction * speed);

    }

}
