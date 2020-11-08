﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsManager : MonoBehaviour
{
    public List<Particle2D> objects;

    // Start is called before the first frame update
    void Start()
    {
        ContactResolver.iterations = 10;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        ForceManager.updateAllForceGenerators(Time.deltaTime);
        ContactResolver.ResolveContacts(Time.deltaTime);
    }

    public bool CheckCollision(Particle2D particle)
    {
        if (particle.gameObject.name == "Player")
            return false;
        foreach(Particle2D temp in objects)
        {
            if(temp != particle  && temp.gameObject.name != "Player")
            {
                if(particle.physicsData.pos.x < temp.physicsData.pos.x + temp.physicsData.scale.x * .5 && particle.physicsData.pos.x > temp.physicsData.pos.x - temp.physicsData.scale.x * .5)
                {
                    if(particle.physicsData.pos.y < temp.physicsData.pos.y + temp.physicsData.scale.y * .5 && particle.physicsData.pos.y > temp.physicsData.pos.y - temp.physicsData.scale.x * .5)
                    {
                        objects.Remove(temp);
                        ForceManager.deregisterPhysicsObject(temp.gameObject);
                        Destroy(temp.gameObject);
                        return true;
                    }
                }
            }
        }
       
        return false;
    }
}