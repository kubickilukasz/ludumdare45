using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField]
    Item [] items;

    public Item GetItem(int id)
    {
        foreach(Item item in items)
        {
            if(item.IdItem == id)
            {
                return item;
            }

        }

        return null;
    }



   

}
