using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vortex;

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
            Vector3 target1 = new Vector3(1, 1, 0).normalized;
            float target1Mag = Vector3.Magnitude(target1);
            Vector3 targetMag = target1 / target1Mag;
            Vector3 finalMag = target1 / Mathf.Pow(target1Mag, 2);
            Vector3 firstCross = Vector3.Cross(transform.forward, targetMag);
            Vector3 proj = Vector3.Cross(firstCross, finalMag);

            if (!x) axis.x = proj.x;
            if (!y) axis.y = proj.y;
            if (!z) axis.z = proj.z;

            axis.Normalize();

        }

        transform.localRotation = Quaternion.AngleAxis(angle, axis);
    }

    private float ComputeAngle(Vector3 ToParent, Vector3 ToChild)
    {
       
        return 0.0f;
    }
}
