using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angleConstraints : MonoBehaviour
{
    public bool active;

    [Range(0.0f, 180.0f)]
    public float maxAngle;

    [Range(0.0f, 180.0f)]
    public float minAngle;

    public Transform parent;
    public Transform child;

    void Start()
    {
    }

    void Update()
    {
        if (active)
        {
           //solve your exercise here
            
        }
    }

    //add auxiliary functions, if needed, below




}
