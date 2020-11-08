using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringForceGenerator : ForceGenerator2D
{
    public GameObject pair;
    public float springConst;
    public float restLength;
    public float dampener = 1;

    // Start is called before the first frame update
    void Start()
    {
        if (autoRegister)
        {
            RegisterForceGenerator();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override PhysicsData UpdateForce(PhysicsData physicsData, float deltaTime)
    {

        //if (GetComponent<SpringForceGenerator>() == null)
          // return physicsData;

        if (physicsData.ignoreForces)
            return physicsData;

        if (!pair)
            return physicsData;

        Vector2 diff = physicsData.pos - pair.GetComponent<Particle2D>().physicsData.pos;

        float dist = diff.magnitude;
        float magnitude = dist - restLength;
        magnitude /= dampener;
        magnitude *= springConst;
        diff.Normalize();
        diff *= -magnitude;

        physicsData.accumulatedForces += diff;
        pair.GetComponent<Particle2D>().physicsData.accumulatedForces += -diff;

        return physicsData;
    }

    public void RegisterPhysicsObjects()
    {
        ForceManager.registerPhysicsObject(gameObject, this);
    }
}
