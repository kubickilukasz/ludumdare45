using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldItemManager : MonoBehaviour
{
    [SerializeField]
    GameObject prefabEmptyItem;

    public void CreateItemWithTrow(Item item , Vector3 startPosition, int multiplier = 1)
    {

        var createdObject = Instantiate(prefabEmptyItem, startPosition , Quaternion.identity , transform) as GameObject;

        createdObject.GetComponent<ItemHandler>().SetItem(item);

        createdObject.GetComponent<ThrowSimulation>().SetStartPosition(startPosition , multiplier);


    }

    public void CreateItem(Item item, Vector3 startPosition)
    {

        var createdObject = Instantiate(prefabEmptyItem, startPosition, Quaternion.identity, transform) as GameObject;

        createdObject.GetComponent<ItemHandler>().SetItem(item);

        createdObject.GetComponent<ThrowSimulation>().DestroyComponent();

    }

}
