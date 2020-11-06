using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle2D : MonoBehaviour
{

    public PhysicsData physicsData;
    // Start is called before the first frame update
    void Start()
    {
        ForceManager.registerPhysicsObject(gameObject);
    }
   

    // Update is called once per frame
    void Update()
    {
        //PhysicsEngin.Integrate(physicsData);
    }

    private void FixedUpdate()
    {
        gameObject.transform.position = physicsData.pos;
        physicsData = Integrator.Integrate(physicsData, Time.deltaTime);
    }

}
