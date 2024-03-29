﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointForceGenerator : ForceGenerator2D
{
    public float range = 1000;
    public float strength;


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
        if (physicsData.ignoreForces)
            return physicsData;

        Vector2 diff = new Vector2(transform.position.x, transform.position.y) - physicsData.pos;

        float rangeSQ = range * range;
        float distSQ = diff.magnitude * diff.magnitude;

        if (distSQ < rangeSQ)
        {
            float dist = diff.magnitude;
            float proportionAway = dist / range;
            proportionAway = 1 - proportionAway;
            diff.Normalize();
            physicsData.accumulatedForces += diff * proportionAway * strength;
        }

        return physicsData;

    }
}
