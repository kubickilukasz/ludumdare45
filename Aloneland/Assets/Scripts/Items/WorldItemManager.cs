using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldItemManager : MonoBehaviour
{
    [SerializeField]
    GameObject prefabEmptyItem;

    List<ItemHandler> items = new List<ItemHandler>(); // list items of world

    public void CreateItemWithTrow(Item item , Vector3 startPosition, int multiplier = 1)
    {

        var createdObject = Instantiate(prefabEmptyItem, startPosition , Quaternion.identity , transform) as GameObject;

        ItemHandler itemHandler = createdObject.GetComponent<ItemHandler>();

        itemHandler.SetItem(item);

        createdObject.GetComponent<ThrowSimulation>().SetStartPosition(startPosition , multiplier);

        items.Add(itemHandler);

    }

    public void CreateItem(Item item, Vector3 startPosition)
    {

        var createdObject = Instantiate(prefabEmptyItem, startPosition, Quaternion.identity, transform) as GameObject;

        ItemHandler itemHandler = createdObject.GetComponent<ItemHandler>();

        itemHandler.SetItem(item);

        createdObject.GetComponent<ThrowSimulation>().DestroyComponent();

        items.Add(itemHandler);

    }

}
