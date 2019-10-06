using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{

    [SerializeField]
    Item[] items;

    [SerializeField]
    float[] precents;

    [SerializeField]
    WorldItemManager worldItemManager;

    public void Spawn()
    {
        float rand = Random.Range(0f, 100f) / 100f;

        float current_precent = 0;

        for(int i = 0; i < precents.Length; i++)
        {
            current_precent += precents[i];

            if(current_precent > rand)
            {

                Debug.Log(rand);

                if (items[i] == null)
                    return;

                worldItemManager.CreateItem(items[i] , transform.position);

                return;

            }


        }

    }


}
