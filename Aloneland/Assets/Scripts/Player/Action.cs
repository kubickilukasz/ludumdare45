using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Action : MonoBehaviour
{

    //[SerializeField]
    //Canvas windowAction;

    [SerializeField]
    Text itemName;

    [SerializeField]
    GameObject infoOf;

    ItemHandler currentItemHandler = null;
    ItemHandler[] currentItemHandlers = new ItemHandler[0];
    PlayerItem playerItem;


    public void ShowActionWindow(ItemHandler itemHandler)
    {

        ItemHandler[] tempCurrentItemHandlers = new ItemHandler[currentItemHandlers.Length + 1];

        for (int i = 0; i < currentItemHandlers.Length; i++)
        {
            tempCurrentItemHandlers[i] = currentItemHandlers[i];
        }

        tempCurrentItemHandlers[currentItemHandlers.Length] = itemHandler;

        currentItemHandlers = tempCurrentItemHandlers;

    }

    public void HideActionWindow(ItemHandler itemHandler)
    {

        if(currentItemHandlers.Length == 0)
        {
            currentItemHandlers = new ItemHandler[0];
            return;
        }

        ItemHandler[] tempCurrentItemHandlers = new ItemHandler[currentItemHandlers.Length - 1];

        int j = 0;

        for (int i = 0; i < tempCurrentItemHandlers.Length; i++)
        {
            if (itemHandler == currentItemHandlers[j])
                j++;

            tempCurrentItemHandlers[i] = currentItemHandlers[j];

            j++;
        }

        currentItemHandlers = tempCurrentItemHandlers;

        /*if (currentItemHandler != itemHandler)
            return;

        itemName.text = "";

        currentItemHandler = null;*/

    }

    private void Start()
    {

        playerItem = GetComponent<PlayerItem>();

    }

    private void Update()
    {
        if (!PlayerMovement.canMove)
            return;

        float distance = 100f;
        ItemHandler nearestItemHandler = null;

        foreach(ItemHandler itemH in currentItemHandlers)
        {
            float newDistance = Vector3.Distance(itemH.transform.position, transform.position);
            if (distance > newDistance)
            {
                distance = newDistance;
                nearestItemHandler = itemH;
            }

        }

        if(nearestItemHandler != null)
        {
            currentItemHandler = nearestItemHandler;

            itemName.text = nearestItemHandler.Handler.NameItem;
        }
        else
        {
            itemName.text = "";

            currentItemHandler = null;
        }


        if (currentItemHandler != null)
        {


            if (Input.GetKeyDown(KeyCode.Q))
            {

                playerItem.Use(currentItemHandler);

            }
            else if (Input.GetKeyDown(KeyCode.F))
            {

                playerItem.Take(currentItemHandler);

            }else if (Input.GetKeyDown(KeyCode.E))
            {
                playerItem.Eat(null);
            }

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.F))
            {

                playerItem.ThrowItem();

            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                playerItem.Eat(null);

            }else if (Input.GetKeyDown(KeyCode.Q))
            {

                playerItem.Use(null);

            }

        }

    }

  

}
