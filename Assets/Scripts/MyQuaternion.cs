using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyQuaternion {
    // Properties:
    public float w, x, y, z;

    // Functions:
    public MyQuaternion() { w = 1; x = 0; y = 0; z = 0; }
    public MyQuaternion(float _w, float _x, float _y, float _z) { w = _w; x = _x; y = _y; z = _z; }
    public MyQuaternion(Quaternion _unityQ) {
        _unityQ = _unityQ.normalized;
        w = _unityQ.w; x = _unityQ.x; y = _unityQ.y; z = _unityQ.z;
    }
    ~MyQuaternion() { }

    MyQuaternion Normalize(MyQuaternion _q)
    {
        float magnitude = Mathf.Sqrt(Mathf.Pow(_q.x, 2) + Mathf.Pow(_q.y, 2) + Mathf.Pow(_q.z, 2));
        _q.w /= magnitude;
        _q.x /= magnitude;
        _q.y /= magnitude;
        _q.z /= magnitude;
        return _q;
    }

    public MyQuaternion Normalized() { return Normalize(this); }

    // Llobera hates overloading operators... appearently...
    /*public static MyQuaternion operator+(MyQuaternion _q1, MyQuaternion _q2){
        MyQuaternion _res = new MyQuaternion();
        _res.w = _q1.w + _q2.w;
        _res.x = _q1.x + _q2.x;
        _res.y = _q1.y + _q2.y;
        _res.z = _q1.z + _q2.z;
        _res = Normalize(_res);
        return _res;
    }*/

    public MyQuaternion Multiply(MyQuaternion _q1, MyQuaternion _q2)
    {
        MyQuaternion _res = new MyQuaternion();
        _res.w = _q1.w * _q2.w - _q1.x * _q2.x - _q1.y * _q2.y - _q1.z * _q2.z;
        _res.x = _q1.w * _q2.x + _q1.x * _q2.w + _q1.y * _q2.z - _q1.z * _q2.y;
        _res.y = _q1.w * _q2.y + _q1.y * _q2.w - _q1.x * _q2.z + _q1.z * _q2.x;
        _res.z = _q1.w * _q2.z + _q1.z * _q2.w + _q1.x * _q2.y - _q1.y * _q2.x;
        return Normalize(_res);
    }

    public MyQuaternion Inverse(MyQuaternion _q)
    {
        _q = Normalize(_q);
        _q.x *= -1;
        _q.y *= -1;
        _q.z *= -1;

        return _q;
    }

    public MyQuaternion AxisAngleToQuaternion(MyVector3 _axis, float _angle)
    {
        _axis = _axis.Normalized();
        MyQuaternion _q = new MyQuaternion();
        _q.x = _axis.x * Mathf.Sin(_angle / 2);
        _q.y = _axis.y * Mathf.Sin(_angle / 2);
        _q.z = _axis.z * Mathf.Sin(_angle / 2);
        _q.w = Mathf.Cos(_angle / 2);
        return _q;
    }

    public MyQuaternion AxisAngleToQuaternion(MyAxisAngle _axisAngle)
    {
        return AxisAngleToQuaternion(new MyVector3(_axisAngle.x, _axisAngle.y, _axisAngle.z), _axisAngle.angle);
    }

    public MyAxisAngle QuaternionToAxisAngle(Quaternion _q)
    {
        MyAxisAngle _axAng = new MyAxisAngle();
        _axAng.angle = 2 * Mathf.Acos(_q.w);
        _axAng.x = _q.x / Mathf.Sqrt(1 - _q.w * _q.w);
        _axAng.y = _q.y / Mathf.Sqrt(1 - _q.w * _q.w);
        _axAng.z = _q.z / Mathf.Sqrt(1 - _q.w * _q.w);
        return _axAng;
    }

    public Quaternion GetUnityQuaternion()
    {
        Quaternion _q;
        _q.w = w;
        _q.x = x;
        _q.y = y;
        _q.z = z;
        return _q.normalized;
    }
}
