using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyVector3 {
    // Properties:
    public float x, y, z;

    // Functions:
    public MyVector3(float _x, float _y, float _z) { x = _x; y = _y; z = _z; }
    public MyVector3() { }
    public MyVector3(float _val) { x = y = z = _val; }
    ~MyVector3() { }

    MyVector3 Normalize(MyVector3 _v)
    {
        float mod = Mathf.Sqrt(Mathf.Pow(_v.x, 2) + Mathf.Pow(_v.y, 2) + Mathf.Pow(_v.z, 2));
        _v.x /= mod;
        _v.y /= mod;
        _v.z /= mod;
        return _v;
    }

    public MyVector3 Normalized() { return Normalize(this); }
}
