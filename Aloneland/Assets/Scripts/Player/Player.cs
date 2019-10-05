using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f; // speed of the player


    Rigidbody2D rb2d; // rigidbody 2d of the gameObject(Player)


    public float Velocity
    {
        get
        {
            return rb2d.velocity.magnitude;
        }
    }

    public float DirectionX
    {
        get
        {
            return rb2d.velocity.x < 0 ? -1 : 1;    
        }
    }


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        Vector2 direction = new Vector3(Input.GetAxis("Horizontal") , Input.GetAxis("Vertical"));

        Debug.Log(direction);

        rb2d.AddForce(direction * speed);

    }

}
