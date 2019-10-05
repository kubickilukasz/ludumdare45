using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerAnimations : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    Player player;


    private void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetFloat("velocity", player.Velocity / 5);


        transform.localScale = new Vector3(player.DirectionX , transform.localScale.y , transform.localScale.z);

        
    }
}
