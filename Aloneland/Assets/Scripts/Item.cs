using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(menuName = "Aloneland/Item" , fileName = "Item")]
public class Item : ScriptableObject
{

    [SerializeField]
    public int idItem = 0; // id of Item

    [SerializeField]
    private string nameItem = "item"; // name of the item

    [SerializeField]
    private Sprite spriteItem; // sprite of the item

    [SerializeField]
    private bool pickable = true; // can i pick it to inventory

    [SerializeField]
    private bool useable = true; // can i use it with other item

    [SerializeField]
    private float eatable = 0; // percent how good for player's stomach it is

    [SerializeField]
    private bool talkable = false; // can i talk with it


    public int IdItem
    {
        get
        {
            return idItem;
        }
    }

    public string NameItem
    {
        get
        {
            return nameItem;
        }
    }

    public Sprite SpriteItem
    {
        get
        {
            return spriteItem;
        }
    }

    public bool Pickable
    {
        get
        {
            return pickable;
        }
    }

    public bool Useable
    {
        get
        {
            return useable;
        }
    }

    public float Eatable
    {
        get
        {
            return eatable;
        }
    }

    public bool Talkable
    {
        get
        {
            return talkable;
        }
    }

}



