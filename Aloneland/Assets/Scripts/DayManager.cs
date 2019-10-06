using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayManager : MonoBehaviour
{

    public delegate void StartDay();

    [SerializeField]
    float speed; // speed of fade

    [SerializeField]
    CanvasGroup dawn;

    [SerializeField]
    Text dayText;

    static int numberOfDay = 0;

    public static int NumberOfDay
    {
        get
        {
            return numberOfDay;
        }
    }

    public void StartNewDay(StartDay startDay)
    {

        PlayerMovement.canMove = false;

        numberOfDay++;

        dayText.text = "";

        StartCoroutine(ShowDawn(startDay));

    }

    private void Awake()
    {
        numberOfDay = 0;
    }

    IEnumerator ShowDawn(StartDay startDay)
    {

        while (dawn.alpha < 1)
        {
            dawn.alpha += Time.deltaTime * speed;
            yield return null;
        }

        dayText.text = "Day " + numberOfDay.ToString();

        yield return new WaitForSeconds(2f);

        StartCoroutine(HideDawn(startDay));

    }


    IEnumerator HideDawn(StartDay startDay)
    {
        startDay();

        ItemSpawner[] itemSpawners = (ItemSpawner[])GameObject.FindObjectsOfType(typeof(ItemSpawner));

        foreach (ItemSpawner itemSpawner in itemSpawners)
        {
            itemSpawner.Spawn();
        }

        while (dawn.alpha > 0)
        {
            dawn.alpha -= Time.deltaTime * speed;
            yield return null;
        }

        PlayerMovement.canMove = true;

    }



}
