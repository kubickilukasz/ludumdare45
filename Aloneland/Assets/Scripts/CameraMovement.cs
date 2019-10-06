using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField]
    Transform playerTransform;

    Camera camera;

    private void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewport = camera.WorldToViewportPoint(playerTransform.position);

        float x = 0.5f;
        float y = 0.5f;
        
        if(viewport.x < 0)
        {

            x = -0.5f;

        }else if(viewport.x > 1){

            x = 1.5f;

        }

        if (viewport.y < 0)
        {
            y = -0.5f;
        }
        else if (viewport.y > 1)
        {
            y = 1.5f;
        }

        

        if(x != 0.5f || y != 0.5f)
            ChangePosition(x, y);


    }

    private void ChangePosition(float x, float y)
    {

        Vector3 position = camera.ViewportToWorldPoint(new Vector3(x , y , 0));

        transform.position = position;

    }
    

}
