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
            Vector3 axis;
            float angle;

            transform.localRotation.ToAngleAxis(out angle, out axis);

            angle = Mathf.Clamp(angle, minAngle, maxAngle);

            transform.localRotation = Quaternion.AngleAxis(angle, axis);

        }
    }

    private float ComputeAngle(Vector3 ToParent, Vector3 ToChild)
    {
       
        return 0.0f;
    }
}
