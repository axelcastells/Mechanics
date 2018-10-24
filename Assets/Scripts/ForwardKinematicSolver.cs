﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardKinematicSolver : MonoBehaviour {

    public List<FKNode> nodes;
	// Use this for initialization
	void Start () {

        RunFK();
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void RunFK()
    {
        foreach(FKNode n in nodes)
        {
            n.transform.Rotate(n.axis, n.angle);           
        }
    }
}
