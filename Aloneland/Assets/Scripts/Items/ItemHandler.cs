using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ItemHandler : MonoBehaviour
{

    [SerializeField]
    Item handler;

    [SerializeField]
    bool isSorting = true; // is it sort order automatically

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

    private void Update()
    {
        if(isSorting)
            spriteRenderer.sortingOrder = (int)(transform.position.y * -10);

    }

    private void SetHandlerAttributes()
    {
        if (handler == null)
        {
            spriteRenderer.sprite = null;
            gameObject.name = "???";
            return;
        }

        if(handler.AnimatorController != "")
        {
            var anim = gameObject.AddComponent<Animator>() as Animator;
            Debug.Log(handler.NameItem);
            anim.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load(handler.AnimatorController);
        }
        else
        {
            var anim = gameObject.GetComponent<Animator>() as Animator;

            if(anim != null)
            {
                Destroy(anim);
            }

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
