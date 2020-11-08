using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

[Serializable]
public struct PhysicsData
{

    public float mass;

    public Vector2 scale;
    public Vector2 pos;
    public Vector2 vel;
    public Vector2 acc;
    public Vector2 accumulatedForces;
    public float facing ;
    public float rotVel;
    public float rotAccel;
    public float dampingConst;
    public bool ignoreForces;
    public bool isEffectedByGravity;

    public void MakeDefault()
    {
        mass = 0;
        //pos = Vector2.zero;
        vel = Vector2.zero;
        acc = Vector2.zero;
        accumulatedForces = Vector2.zero;
        facing = 0.0f;
        rotVel = 0.0f;
        rotAccel = 0.0f;
        dampingConst = 99;
        ignoreForces = false;
        isEffectedByGravity = true;
    }

    public Vector2 GetHeadingVector()
    {
        return new Vector2(Mathf.Cos(facing), Mathf.Sin(facing));
    }

    public float GetInverseMass() { return 1 / mass; }
}
