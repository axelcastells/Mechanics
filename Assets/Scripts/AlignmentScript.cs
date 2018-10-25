using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignmentScript : MonoBehaviour
{

    public Transform target1;
    public Transform target2;
    private Quaternion savedOffset;
	public int exercise = 1;
	
	
    // Use this for initialization
    void Start ()
    {
        savedOffset = target1.rotation * Quaternion.Inverse(transform.rotation);
    }

    void Update()
    {
        switch(exercise)
        {
            case 1:
            {

                    float angleX = -Mathf.Acos(Vector3.Dot(transform.right, target1.right)) * Mathf.Rad2Deg;
                    Vector3 axisX = Vector3.Cross(transform.right, target1.right).normalized;

                    target1.Rotate(axisX, angleX, Space.World);


                    float angleY = -Mathf.Acos(Vector3.Dot(transform.up, target1.up)) * Mathf.Rad2Deg;
                    Vector3 axisY = Vector3.Cross(transform.up, target1.up).normalized;

                    target1.Rotate(axisY, angleY, Space.World);


                }
                break;

          

            case 2:
            {
                    target1.rotation = Quaternion.Slerp(target1.rotation, transform.rotation, 0.01f);
            } break;

            case 3:
            {
                    target1.rotation = transform.rotation * savedOffset;
            } break;

            case 4:
            {
                    target1.rotation = transform.rotation * savedOffset;
                    target2.rotation = target1.rotation * Quaternion.Inverse(savedOffset);
            } break;
        }
    }
}
