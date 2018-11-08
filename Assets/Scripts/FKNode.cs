using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FKNode : MonoBehaviour
{

    public float angle;

    [SerializeField]
    private Vector3 axis;
    public Vector3 Axis
    {
        get
        {
            return axis;
        }
        set
        {
            axis = value.normalized;
        }
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
