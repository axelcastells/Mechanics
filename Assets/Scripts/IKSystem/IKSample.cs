using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKSample : MonoBehaviour
{
    public List<IKSolver> ikControllers;
    public List<Transform> targets;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < ikControllers.Count; i++)
        {
            if(targets.Count > i)
                ikControllers[i].Run(targets[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
