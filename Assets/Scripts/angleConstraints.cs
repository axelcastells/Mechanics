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

            transform.rotation.ToAngleAxis(out angle, out axis);

            axis.x = Mathf.Clamp(axis.x, minAngle, maxAngle);
            axis.y = Mathf.Clamp(axis.y, minAngle, maxAngle);
            axis.z = Mathf.Clamp(axis.z, minAngle, maxAngle);

            transform.localRotation = Quaternion.AngleAxis(angle, axis);
        }
    }

    //add auxiliary functions, if needed, below




}
