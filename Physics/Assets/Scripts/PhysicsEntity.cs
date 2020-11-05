using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEntity : MonoBehaviour
{

    PhysicsData physicsData;
    // Start is called before the first frame update
    void Start()
    {
        physicsData.MakeDefault();
    }
   

    // Update is called once per frame
    void Update()
    {
        //PhysicsEngin.Integrate(physicsData);
    }
}
