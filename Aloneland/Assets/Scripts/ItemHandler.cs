using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ItemHandler : MonoBehaviour
{

    [SerializeField]
    Item handler;

    SpriteRenderer spriteRenderer;

    ThrowSimulation throwSimulation;


    public Item Handler
    {
        get{
            return handler;
        }
    } 

    public void SetItem(Item item)
    {

        handler = item;

        SetHandlerAttributes();

    }


    private void Awake()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();

        throwSimulation = GetComponent<ThrowSimulation>();

        SetHandlerAttributes();

    }

    private void SetHandlerAttributes()
    {
        if (handler == null)
        {
            //Destroy(gameObject);
            spriteRenderer.sprite = null;
            gameObject.name = "???";
            return;
        }

        spriteRenderer.sprite = handler.SpriteItem;
        gameObject.name = handler.NameItem;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player" || handler == null ||  (throwSimulation != null && throwSimulation.GetTimer() < 0.3f))
            return;

        collision.GetComponent<Action>().ShowActionWindow(this);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != "Player" || handler == null)
            return;

        collision.GetComponent<Action>().HideActionWindow(this);

    }

}
