using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteOrder : MonoBehaviour
{

    SpriteRenderer [] spriteRenderers;
    int[] startSortingOrder;

    void Awake()
    {

        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

        startSortingOrder = new int[spriteRenderers.Length];

        for (int i =0 ; i < spriteRenderers.Length; i++)
        {
            startSortingOrder[i] = spriteRenderers[i].sortingOrder;
        }

    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            spriteRenderers[i].sortingOrder = startSortingOrder[i] + (int)((transform.position.y - (gameObject.tag == "Player" ? 1 : 0)) * -10);
        }

    }
}
