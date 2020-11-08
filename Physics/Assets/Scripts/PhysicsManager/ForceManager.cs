using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class ForceManager
{
    static List<GameObject> objects;
    static List<ForceGenerator2D> forceGenerators;

    static ForceManager()
    {
        objects = new List<GameObject>();
        forceGenerators = new List<ForceGenerator2D>();
    }

    public static void updateAllForceGenerators(float deltaTime)
    {

        for(int i = 0; i<forceGenerators.Count; i++)
        {
            for(int j = 0; j<objects.Count; j++)
            {

                objects[j].GetComponent<Particle2D>().physicsData = forceGenerators[i].UpdateForce(objects[j].GetComponent<Particle2D>().physicsData, deltaTime);

            }
        }

    }

    public static void registerPhysicsObject(GameObject obj)
    {

        objects.Add(obj);

    }

    public static void registerForceGenerators(ForceGenerator2D forceGen)
    {
        forceGenerators.Add(forceGen);
    }

    public static void deregisterPhysicsObject( GameObject obj)
    {
        objects.Remove(obj);
        //Debug.Log(objects.Contains(obj));

    }
}
