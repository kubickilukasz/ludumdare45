using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerAnimations : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    PlayerMovement player;

    public void None()
    {

        animator.SetTrigger("none");

    }

    public void Take()
    {

        animator.SetTrigger("take");

    }


    public void Eat()
    {

        animator.SetTrigger("eat");

    }


    public void Wakeup()
    {

        animator.SetTrigger("wakeup");

    }



    private void Start()
    {
        player = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetFloat("velocity", player.Velocity / 5);

        float border = 0.1f;

        if(transform.localScale.x > border && player.DirectionX < -border)
        {
            transform.localScale = new Vector3(-  Mathf.Abs(transform.localScale.x) , transform.localScale.y, transform.localScale.z);

        }else if (transform.localScale.x < -border && player.DirectionX > border)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }      

        
    }
}
