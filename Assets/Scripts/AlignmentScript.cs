using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignmentScript : MonoBehaviour
{
    public Transform target1;
    public Transform target2;
	public int exercise = 1;
    float angleX, angleY;
    Vector3 axisX, axisY;
    Quaternion q2;
    MyQuaternion mq2 = new MyQuaternion();

    // Use this for initialization
    void Start ()
    {
        //ex 1
        /* angleX = Mathf.Acos(Vector3.Dot(transform.right, target1.right)) * Mathf.Rad2Deg;
         axisX = Vector3.Cross(target1.right, target2.right).normalized;

         axisY = Vector3.Cross(target1.up, target2.up).normalized;
         angleY = Mathf.Acos(Vector3.Dot(transform.up, target1.up)) * Mathf.Rad2Deg;*/
        q2 = target1.rotation * Quaternion.Inverse(transform.rotation);
        mq2 = mq2.Multiply(new MyQuaternion(target1.rotation), mq2.Inverse(new MyQuaternion(transform.rotation)));
        target2.transform.rotation = transform.rotation;
    }

    void Update()
    {
        switch(exercise)
        {
            case 1:
            {
                    /*target1.Rotate(axisX, -angleX, Space.World);
                    target1.Rotate(axisY, -angleY, Space.World);*/

                    angleX = -Mathf.Acos(Vector3.Dot(transform.right, target1.right)) * Mathf.Rad2Deg;
                    axisX = Vector3.Cross(target1.right, target2.right).normalized;
                    target1.Rotate(axisX, angleX, Space.World);

                    axisY = Vector3.Cross(target1.up, target2.up).normalized;
                    angleY = -Mathf.Acos(Vector3.Dot(transform.up, target1.up)) * Mathf.Rad2Deg;
                    target1.Rotate(axisY, angleY, Space.World);
                } break;

            case 2:
            {
                    //Quaternion q2 = transform.rotation * Quaternion.Inverse(transform.rotation);
                    target1.rotation = Quaternion.Slerp(target1.rotation, transform.rotation, 0.01f);
                } break;

            case 3:
            {
                    //target1.rotation = Quaternion.Slerp(target1.rotation, Quaternion.Inverse(transform.rotation), 0.01f);
                    target1.rotation = transform.rotation * q2;
                    
            } break;

            case 4:
            {
                    target1.rotation = transform.rotation * q2;
                    target2.rotation = target1.rotation * Quaternion.Inverse(q2);
            } break;

            case 5:
                {
                    MyQuaternion t1Rot = new MyQuaternion();
                    MyQuaternion t2Rot = new MyQuaternion();

                    t1Rot = mq2.Multiply(new MyQuaternion(transform.rotation), mq2);
                    target1.rotation = t1Rot.GetUnityQuaternion();

                    t2Rot = mq2.Multiply(new MyQuaternion(target1.rotation), mq2.Inverse(mq2));
                    target2.rotation = t2Rot.GetUnityQuaternion();
                    
                    //target1.rotation = transform.rotation * q2;
                    //target2.rotation = target1.rotation * Quaternion.Inverse(q2);
                }
                break;
        }
    }
}
