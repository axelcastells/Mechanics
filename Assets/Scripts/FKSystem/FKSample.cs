using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FKSample : MonoBehaviour
{
    public FKSolver fkSolver;
    // Start is called before the first frame update
    void Start()
    {
        fkSolver.Run();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
