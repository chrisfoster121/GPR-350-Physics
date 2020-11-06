using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Integrator 
{


    public static PhysicsData Integrate(PhysicsData physicsData, float deltaTime)
    {
        physicsData.pos += physicsData.vel * deltaTime;

        Vector2 resultingAccel = physicsData.acc;


        if (!physicsData.ignoreForces)
        {
            resultingAccel += physicsData.accumulatedForces * (1/physicsData.mass);
        }

        physicsData.vel += resultingAccel * deltaTime;

        float damping = Mathf.Pow(physicsData.dampingConst, deltaTime);
        physicsData.vel *= damping;

        physicsData.accumulatedForces = Vector2.zero;

        return physicsData;
    }

}
