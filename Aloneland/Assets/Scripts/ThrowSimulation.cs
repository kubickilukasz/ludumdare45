using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSimulation : MonoBehaviour
{

    [SerializeField]
    AnimationCurve throwCurveHeight;

    [SerializeField]
    AnimationCurve throwCurveDistance;

    [SerializeField]
    float time;

    [SerializeField]
    Vector3 startPosition;

    float timer = 0;

    float multiplier = 1;

    public void SetStartPosition(Vector3 pos , int multiplier = 1)
    {
        startPosition = pos;

        this.multiplier = multiplier;

        timer = 0;
    }

    public void DestroyComponent()
    {
        Destroy(this);
    }

    public float GetTimer()
    {
        return timer / time;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        transform.position = new Vector3(startPosition.x + throwCurveDistance.Evaluate(timer/ time) * multiplier, startPosition.y + throwCurveHeight.Evaluate(timer / time), transform.position.z);

        if (timer > time)
        {
  
            Destroy(this);

        }

    }


}
