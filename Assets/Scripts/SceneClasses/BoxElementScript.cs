using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxElementScript : MonoBehaviour
{
    public float TimerLimit = 5.0f;

    float TimeSinceEnabled = 0.0f;

    Rigidbody RB;

    private void Awake()
    {
        RB = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        TimeSinceEnabled = 0.0f;
    }

    void Update()
    {
        TimeSinceEnabled += Time.deltaTime;

        if (TimeSinceEnabled > TimerLimit)
        {
            ObjectPool<Rigidbody>.ReturnToPool(RB);
        }
    }
}
