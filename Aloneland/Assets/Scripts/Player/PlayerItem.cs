using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerItem : MonoBehaviour
{

    [SerializeField]
    Item pickedItem;

    [SerializeField]
    Items items;

    [SerializeField]
    SpriteRenderer spriteRendererPickedItem;

    [SerializeField]
    WorldItemManager worldItemManager;

    PlayerAnimations playerAnimations;

    PlayerVitality playerVitality;


  
    public void Take(ItemHandler itemHandler)
    {

        if (!itemHandler.Handler.Pickable)
        {
            playerAnimations.None();

        }
        else
        {

            TakeItem(itemHandler.Handler);

            Destroy(itemHandler.gameObject);
           
        }

    }

    public void ThrowItem()
    {
        if (pickedItem == null)
            return;

        worldItemManager.CreateItemWithTrow(pickedItem, transform.position , transform.localScale.x > 0 ? 1 : -1);

        spriteRendererPickedItem.sprite = null;

        pickedItem = null;

    }

    public void Use(ItemHandler itemHandler)
    {

        RecipeCraft recipe = new RecipeCraft();

        Result result = recipe.GetIdItem(pickedItem ? pickedItem.IdItem : 0, itemHandler.Handler.IdItem);

        int new_id = result.id;

        if(new_id == 0)
        {
            playerAnimations.None();

        }else if(new_id == -1)
        {
            playerAnimations.None();

            pickedItem = null;

            spriteRendererPickedItem.sprite = null;
        }
        else if(new_id == -2)
        {
            playerAnimations.None();

            Destroy(itemHandler.gameObject);

        }else if (new_id == -3)
        {
            playerAnimations.None();

            pickedItem = null;

            spriteRendererPickedItem.sprite = null;

            Destroy(itemHandler.gameObject);

        }else if (new_id <= -4)
        {
            //use sleeping bag

            playerVitality.AddVitality(-0.2f);

            playerVitality.Sleep();

        }
        else
        {

            worldItemManager.CreateItemWithTrow(items.GetItem(new_id), transform.position , transform.localScale.x > 0 ? 1 : -1);

            switch (result.way)
            {

                case 1:
                    pickedItem = null;

                    spriteRendererPickedItem.sprite = null;
             
                    break;
                case 2:

                    Destroy(itemHandler.gameObject);
                    break;
                case 3:
                    pickedItem = null;

                    spriteRendererPickedItem.sprite = null;

                    Destroy(itemHandler.gameObject);
                    break;
                default:
                    break;

            }


        }

    }

    public void Eat(ItemHandler itemHandler)
    {

        if (itemHandler != null)
        {
            Take(itemHandler);
        }

        if (pickedItem == null)
        {
            playerAnimations.None();
            return;
        }

        playerAnimations.Eat();

        StartCoroutine(DeleteItemAfterEat(pickedItem));

        pickedItem = null;
    }


    private void Start()
    {

        playerAnimations = GetComponent<PlayerAnimations>();
        playerVitality = GetComponent<PlayerVitality>();

    }

    void TakeItem(Item item)
    {

        if(item == null)
        {
            playerAnimations.None();
            return;
        }

        if (pickedItem != null)
        {
            ThrowItem();
        }

        playerAnimations.Take();

        pickedItem = item;

        spriteRendererPickedItem.sprite = item.SpriteItem;
    }


    IEnumerator DeleteItemAfterEat(Item item)
    {

        yield return new WaitForSeconds(0.7f);

        spriteRendererPickedItem.sprite = null;

        if(item.Eatable == -1)
        {
            worldItemManager.CreateItemWithTrow(item , transform.position, transform.localScale.x > 0 ? 1 : -1);

        }else
        {
            playerVitality.AddVitality(item.Eatable);
        }    
    
    }



}
