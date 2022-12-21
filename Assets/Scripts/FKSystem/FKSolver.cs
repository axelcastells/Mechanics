using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FKSolver : MonoBehaviour
{

    public List<FKNode> nodes;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Run()
    {
        foreach (FKNode n in nodes)
        {
            n.transform.Rotate(n.Axis, n.angle);
            //n.transform.rotation = new Quaternion(n.Axis.x, n.Axis.y, n.Axis.z, n.angle);
        }
    }
}
