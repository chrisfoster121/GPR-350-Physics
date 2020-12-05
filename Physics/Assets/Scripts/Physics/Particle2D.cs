using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Particle2D : MonoBehaviour
{

    public PhysicsData physicsData;
    PhysicsManager physicsManager;
    // Start is called before the first frame update
    void Start()
    {
        physicsManager = GameObject.Find("PhysicsManager").GetComponent<PhysicsManager>();
        ForceManager.registerPhysicsObject(gameObject);
        physicsManager.objects.Add(this);
    }
   

    // Update is called once per frame
    void Update()
    {
        //PhysicsEngin.Integrate(physicsData);
    }

    private void FixedUpdate()
    {
        transform.localScale = physicsData.scale;
        transform.position = physicsData.pos;
        transform.rotation = Quaternion.Euler(0,0,physicsData.facing * Mathf.Rad2Deg);
        physicsData = Integrator.Integrate(physicsData, Time.deltaTime);
        //if (CheckCollision())
        //{
        //    physicsManager.objects.Remove(this);
        //    ForceManager.deregisterPhysicsObject(gameObject);
        //    Destroy(gameObject);
        //}
    }

    ~Particle2D()
    {

        ForceManager.deregisterPhysicsObject(gameObject);
       
    }

    bool CheckCollision()
    {
        return physicsManager.CheckCollision(this);
    }
   

}
