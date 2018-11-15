using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RobotController;
public class MyBoxController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        MyRobotController r2d2 = new MyRobotController();
        Debug.Log(r2d2.Hi());
        Debug.Log("add PI to 3: " + r2d2.addPi(3.0f));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
