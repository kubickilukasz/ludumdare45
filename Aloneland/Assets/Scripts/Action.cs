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
    PlayerItem playerItem;


    public void ShowActionWindow(ItemHandler itemHandler)
    {

        currentItemHandler = itemHandler;

        itemName.text = itemHandler.Handler.NameItem;

        GenerateInfoOf(itemHandler.Handler);
        
    }

    public void HideActionWindow(ItemHandler itemHandler)
    {

        if (currentItemHandler != itemHandler)
            return;

        itemName.text = "";

        currentItemHandler = null;

    }

    private void Start()
    {

        playerItem = GetComponent<PlayerItem>();

    }

    private void Update()
    {
        if (!PlayerMovement.canMove)
            return;

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
            }

        }

    }

   

    private void GenerateInfoOf(Item item)
    {

       /* if (item.Useable)
        {
            if(useable == null)
                useable = Instantiate(infoOf, windowAction.transform);

            useable.GetComponent<Text>().text = "Q - to use";
        }
        else
        {
            Destroy(useable);
        }


        if (item.Pickable)
        {
            if (pickable == null)
                pickable = Instantiate(infoOf, windowAction.transform);

            pickable.GetComponent<Text>().text = "F - to pick";
        }
        else
        {
            Destroy(pickable);
        }


        if (eatable == null)
            eatable = Instantiate(infoOf, windowAction.transform);

        eatable.GetComponent<Text>().text = "E - to try eat";


        if (item.Talkable)
        {
            if (talkable == null)
                talkable = Instantiate(infoOf, windowAction.transform);

            talkable.GetComponent<Text>().text = "R - to talk";
        }
        else
        {
            Destroy(talkable);
        }*/

    }

}
