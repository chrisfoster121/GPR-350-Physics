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
       
        transform.position = physicsData.pos;
        transform.rotation = Quaternion.Euler(0,0,physicsData.facing * Mathf.Rad2Deg);
        physicsData = Integrator.Integrate(physicsData, Time.deltaTime);
    }

    ~Particle2D()
    {
        Debug.Log("destructor");
        ForceManager.deregisterPhysicsObject(gameObject);
    }

   

}
