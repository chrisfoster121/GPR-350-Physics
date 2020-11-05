using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

[Serializable]
struct PhysicsData
{
    //Vector2 pos;
    Vector2 vel;
    Vector2 acc;
    Vector2 accumulatedForces;
    float facing ;
    float rotVel;
    float rotAccel;
    float dampingConst;
    bool ignoreForces;
    bool isEffectedByGravity;

    public void MakeDefault()
    {
        //pos = Vector2.zero;
        vel = Vector2.zero;
        acc = Vector2.zero;
        accumulatedForces = Vector2.zero;
        facing = 0.0f;
        rotVel = 0.0f;
        rotAccel = 0.0f;
        dampingConst = 0.0f;
        ignoreForces = false;
        isEffectedByGravity = true;
    }
}
