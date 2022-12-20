using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKSolver : MonoBehaviour
{
    // Array to hold all the joints
    // index 0 - root
    // index END - End Effector
    public List<Transform> joints;
    // The target for the IK system
    Transform targ;

    // The sine component for each joint

    private float[] _sin, _cos, _theta;

    // To store the position of the target
    private Vector3 tpos;





    [Header("Debug")]
    // To check if the target is reached at any point
    bool reachedTarget = false;


    // Max number of tries before the system gives up (Maybe 10 is too high?)
    [SerializeField]
    private int maxTries = 10;
    // The number of tries the system is at now
    [SerializeField]
    private int currentTries = 0;

    // the range within which the target will be assumed to be reached
    private float distanceToAssumeTargetReached = 0.1f;


    bool active = false;

    // Initializing the variables
    void Start()
    {
        
    }

    private void Setup(Transform target)
    {
        _theta = new float[joints.Count];
        _sin = new float[joints.Count];
        _cos = new float[joints.Count];

        targ = target;
        tpos = targ.transform.position;

        currentTries = 0;
        reachedTarget = false;
    }

    public void SetJoints(List<Transform> newJoints)
    {
        joints.Clear();
        foreach (var item in newJoints)
        {
            joints.Add(item);
        }
    }
    public void Run(Transform target)
    {
        Setup(target);
        active = true;
    }

    public void Stop()
    {
        active = false;
    }

    // Running the solver - all the joints are iterated through once every frame
    void Update()
    {
        if(active)
            ComputeIK();
    }

    private void ComputeIK()
    {
        // if the target hasn't been reached
        if (!reachedTarget)
        {
            // if the Max number of tries hasn't been reached
            if (currentTries <= maxTries)
            {
                // starting from the second last joint (the last being the end effector)
                // going back up to the root
                for (int i = joints.Count - 2; i >= 0; i--)
                {
                    // The vector from the ith joint to the end effector
                    Vector3 r1 = joints[joints.Count - 1].transform.position - joints[i].transform.position;
                    // The vector from the ith joint to the target
                    Vector3 r2 = targ.transform.position - joints[i].transform.position;

                    // to avoid dividing by tiny numbers
                    if (r1.magnitude * r2.magnitude <= 0.001f)
                    {
                        // cos component will be 1 and sin will be 0
                        _cos[i] = 1;
                        _sin[i] = 0;
                    }
                    else
                    {
                        // find the components using dot and cross product
                        _cos[i] = Vector3.Dot(r1, r2) / (r1.magnitude * r2.magnitude);
                        _sin[i] = (Vector3.Cross(r1, r2)).magnitude / (r1.magnitude * r2.magnitude);

                    }

                    // The axis of rotation is basically the 
                    // unit vector along the cross product 
                    Vector3 axis = (Vector3.Cross(r1, r2)) / (r1.magnitude * r2.magnitude);

                    // find the angle between r1 and r2 (and clamp values of cos to avoid errors)
                    _theta[i] = Mathf.Acos(Mathf.Max(-1, Mathf.Min(1, _cos[i])));
                    // invert angle if sin component is negative
                    if (_sin[i] < 0.0f)
                        _theta[i] = -_theta[i];
                    // obtain an angle value between -pi and pi, and then convert to degrees
                    _theta[i] = (float)SimpleAngle(_theta[i]) * Mathf.Rad2Deg;
                    // rotate the ith joint along the axis by theta degrees in the world space.
                    joints[i].transform.Rotate(axis, _theta[i], Space.World);

                }

                // increment tries
                currentTries++;
            }
        }

        // find the difference in the positions of the end effector and the target
        // (there's obviously a more beautiful and DRY way to do this)
        float x = Mathf.Abs(joints[joints.Count - 1].transform.position.x - targ.transform.position.x);
        float y = Mathf.Abs(joints[joints.Count - 1].transform.position.y - targ.transform.position.y);
        float z = Mathf.Abs(joints[joints.Count - 1].transform.position.z - targ.transform.position.z);

        // if target is within reach (within epsilon) then the process is done
        if (x < distanceToAssumeTargetReached && y < distanceToAssumeTargetReached && z < distanceToAssumeTargetReached)
        {
            reachedTarget = true;
        }
        // if it isn't, then the process should be repeated
        else
        {
            reachedTarget = false;
        }

        // the target has moved, reset tries to 0 and change tpos
        if (targ.transform.position != tpos)
        {
            currentTries = 0;
            tpos = targ.position;
        }
    }

    // function to convert an angle to its simplest form (between -pi to pi radians)
    double SimpleAngle(double theta)
    {
        theta = theta % (2.0 * Mathf.PI);
        if (theta < -Mathf.PI)
            theta += 2.0 * Mathf.PI;
        else if (theta > Mathf.PI)
            theta -= 2.0 * Mathf.PI;
        return theta;
    }
}
