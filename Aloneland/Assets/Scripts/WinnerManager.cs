using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinnerManager : MonoBehaviour
{

    [SerializeField]
    float speed = 0.6f;

    [SerializeField]
    CanvasGroup victoryScreen;

    [SerializeField]
    Text title;

    [SerializeField]
    Text desc;

    [SerializeField]
    GameObject esc;

    bool canMove = false;

    public void Win()
    {

        PlayerMovement.canMove = false;

        title.text = "YOU WON!";
        desc.text = "someone will come for you and save you!";

        StartCoroutine(ShowWidnow());

    }

    public void Lose()
    {
        PlayerMovement.canMove = false;

        title.text = "YOU LOST! :(";
        desc.text = "you starved to death!";

        StartCoroutine(ShowWidnow());
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        ScenesManager.BackToMenu();

    }

    public void TryAgain()
    {
        Time.timeScale = 1f;
        ScenesManager.ReloadScene();
    }

    public void Continue()
    {
        esc.SetActive(false);
        PlayerMovement.canMove = canMove;
        Time.timeScale = 1f;
    }

    private void Start()
    {
        esc.SetActive(false);
    }

    private void Update()
    {

        if (Input.GetButtonDown("Cancel"))
        {
            esc.SetActive(true);
            canMove = PlayerMovement.canMove;
            PlayerMovement.canMove = false;
            Time.timeScale = 0;

        }

    }

    IEnumerator ShowWidnow()
    {

        while (victoryScreen.alpha < 1)
        {
            victoryScreen.alpha += Time.deltaTime * speed;
            yield return null;
        }

    }


}
