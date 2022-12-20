using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKSample : MonoBehaviour
{
    public IKSolver ikController;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        ikController.Run(target);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
