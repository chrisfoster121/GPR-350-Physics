using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouyancyForceGenerator : ForceGenerator2D
{
    public float height;
    public float submersionDepth;
    public float liquidDensity;
    public float volume;
    

    // Start is called before the first frame update
    void Start()
    {
        if (autoRegister)
        {
            RegisterForceGenerator();
            registerPhysicsObjects();
            //ForceManager.PrintMapKeys();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override PhysicsData UpdateForce(PhysicsData physicsData, float deltaTime)
    {
        //if (GetComponent<BouyancyForceGenerator>() == null)
           // return physicsData;

        if (physicsData.ignoreForces)
            return physicsData;

        float amountSubmerged = (-physicsData.pos.y - height - submersionDepth) / (2 * submersionDepth);
        Vector2 diff = new Vector2(0, 1);

        if (amountSubmerged >= 1)
            diff *= volume * liquidDensity;
        else if (amountSubmerged <= 0)
            diff = Vector2.zero;
        else
            diff *= volume * liquidDensity * amountSubmerged;

        physicsData.accumulatedForces += diff;
        return physicsData;
       
    }

    public void registerPhysicsObjects()
    {
        ForceManager.registerPhysicsObject(gameObject, this);
    }
}
