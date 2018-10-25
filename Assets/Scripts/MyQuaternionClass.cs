using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MyQuaternionClass : MonoBehaviour {

    public MyQuaternionClass myQuat;

    public float x, y, z, w;

    //Quaternion coordinates
    public void quatCoord(float x, float y, float z, float w)
    {
        myQuat.x = x;
        myQuat.y = y;
        myQuat.z = z;
        myQuat.w = w;
    }

}
