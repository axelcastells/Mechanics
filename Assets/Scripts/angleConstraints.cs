using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angleConstraints : MonoBehaviour
{
    public bool isAngleConstraint;
    public bool isAxisConstraint;

    [Range(0.0f, 180.0f)]
    public float minAngle;

    [Range(0.0f, 180.0f)]
    public float maxAngle;

    [Space(10)]
    [Header("Axis Constraints")]
    public bool x;
    public bool y;
    public bool z;

    int debugAxisConstraints;



    //public Transform parent;
    //public Transform child;

    void Start()
    {
        if (isAxisConstraint)
        {
            if (x) debugAxisConstraints++;
            if (y) debugAxisConstraints++;
            if (z) debugAxisConstraints++;

            if (debugAxisConstraints <= 0)
            {
                Debug.Log("[AXIS CONSTRAINT ERROR] Select an axis.");
                isAxisConstraint = false;
            }

            if (debugAxisConstraints > 1)
            {
                Debug.Log("[AXIS CONSTRAINT ERROR] You can only select one axis.");
                isAxisConstraint = false;
            }
        }

    }

    void Update()
    {

        Vector3 axis;
        float angle;

        transform.localRotation.ToAngleAxis(out angle, out axis);

        if (isAngleConstraint)
        {
            angle = Mathf.Clamp(angle, minAngle, maxAngle);
        }

        if (isAxisConstraint)
        {
            if (!x) axis.x = 0;
            if (!y) axis.y = 0;
            if (!z) axis.z = 0;

            axis.Normalize();
        }

        transform.localRotation = Quaternion.AngleAxis(angle, axis);
    }

    private float ComputeAngle(Vector3 ToParent, Vector3 ToChild)
    {
       
        return 0.0f;
    }
}
