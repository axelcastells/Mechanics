using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAxisAngle {
    // Properties:
    public float x, y, z, angle;

    // Functions:
    public MyAxisAngle() { x = y = z = angle = 0; }
    public MyAxisAngle(MyVector3 _axis, float _angle) {
        x = _axis.x; y = _axis.y; z = _axis.z; angle = _angle;
    }
    public MyAxisAngle(float _x, float _y, float _z, float _angle)
    {
        x = _x; y = _y; z = _z; angle = _angle;
    }
    ~MyAxisAngle() { }
}
