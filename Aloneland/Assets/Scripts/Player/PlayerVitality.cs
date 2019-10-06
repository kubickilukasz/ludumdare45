using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVitality : MonoBehaviour
{

    public enum Status
    {
        Healthy,
        Tired,
        Sick,
        Exhausted,
        Dead
    }

    [SerializeField]
    Sprite[] heads;

    [SerializeField]
    Sprite[] bodies;

    [SerializeField]
    Sprite[] legs;

    [SerializeField]
    Sprite[] arms;

    [Space()]

    [SerializeField]
    float vitality = 1;

    [SerializeField]
    DayManager dayManager;

    [Space()]

    [SerializeField]
    SpriteRenderer head;

    [SerializeField]
    SpriteRenderer body;

    [SerializeField]
    SpriteRenderer armLeft;

    [SerializeField]
    SpriteRenderer armRight;

    [SerializeField]
    SpriteRenderer legLeft;

    [SerializeField]
    SpriteRenderer legRight;

    PlayerMovement playerMovement;

    public Status status = Status.Healthy;

    public void AddVitality(float vitality)
    {
        this.vitality += vitality;
    }

    public void Sleep()
    {
        if(vitality < 1 && vitality >= 0.5)
        {
            status = ChangeStatus(1);

        }
        else if(vitality < 0.5 && vitality >= 0.3)
        {

            status = ChangeStatus(2);

        }
        else if (vitality < 0.3 && vitality > 0)
        {
            status = ChangeStatus(3);
        }
        else if(vitality <= 0)
        {
            status = ChangeStatus(4);
        }

        if(status == Status.Dead)
        {
            Debug.Log("END");
            ScenesManager.ReloadScene();
        }

        dayManager.StartNewDay(Refresh);

        //Refresh();
    }

    public void Refresh()
    {
        vitality = 1f;

        switch (status)
        {
            case Status.Healthy:
                ChangeSkin(0);
                break;
            case Status.Tired:
                ChangeSkin(1);
                break;
            case Status.Sick:
                ChangeSkin(2);
                break;
            case Status.Exhausted:
                ChangeSkin(3);
                break;
            case Status.Dead:
                ChangeSkin(3);
                break;
        }



    }

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Start()
    {

        dayManager.StartNewDay(Refresh);
    }

    private void ChangeSkin(int i = 0)
    {

        head.sprite = heads[i];
        body.sprite = bodies[i];
        armLeft.sprite = arms[i];
        armRight.sprite = arms[i];
        legLeft.sprite = legs[i];
        legRight.sprite = legs[i];

    }


    Status ChangeStatus(int i)
    {
        switch (status)
        {
            case Status.Healthy:
                if(i == 1)
                {
                    return Status.Tired;
                }
                else if(i == 2)
                {
                    return Status.Sick;
                }else if(i == 3)
                {
                    return Status.Exhausted;
                }else if(i >= 4)
                {
                    return Status.Dead;
                }
                break;
            case Status.Tired:
                if (i == 1)
                {
                    return Status.Sick;
                }
                else if (i == 2)
                {
                    return Status.Exhausted;
                }
                else if (i >= 3)
                {
                    return Status.Dead;
                }
                break;
            case Status.Sick:
                if (i == 1)
                {
                    return Status.Exhausted;
                }
                else if (i >= 2)
                {
                    return Status.Dead;
                }
                break;

        }

        return Status.Dead;

    }


}
