using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class ForceManager
{
    static Dictionary<ForceGenerator2D, List<GameObject>> forceGenerators;
    //static List<ForceGenerator2D> forceGenerators;

    static ForceManager()
    {
       // objects = new List<GameObject>();
        forceGenerators = new Dictionary<ForceGenerator2D, List<GameObject>>();
    }

    public static void updateAllForceGenerators(float deltaTime)
    {

        foreach(KeyValuePair<ForceGenerator2D, List<GameObject>> entry in forceGenerators)
        {
            foreach(GameObject obj in entry.Value)
            {
                obj.GetComponent<Particle2D>().physicsData = entry.Key.UpdateForce(obj.GetComponent<Particle2D>().physicsData, deltaTime);
            }
        }

    }

    public static void registerPhysicsObject(GameObject obj, ForceGenerator2D forceGen)
    {
        foreach(KeyValuePair<ForceGenerator2D,List<GameObject>> entry in forceGenerators)
        {
            if(forceGen == entry.Key)
            {
                entry.Value.Add(obj);
            }
        }

        

    }

    public static void registerPhysicsObject(GameObject obj)
    {

        foreach (KeyValuePair<ForceGenerator2D, List<GameObject>> entry in forceGenerators)
        {
            string str = entry.Key.GetType().ToString();
            if (str == "PointForceGenerator")
                entry.Value.Add(obj);
        }

    }

    public static void registerForceGenerators(ForceGenerator2D forceGen)
    {
        forceGenerators.Add(forceGen, new List<GameObject>());
    }

    public static void deregisterPhysicsObject( GameObject obj)
    {
        foreach (KeyValuePair<ForceGenerator2D, List<GameObject>> entry in forceGenerators)
        {
            entry.Value.Remove(obj);
        }

    }

    public static void PrintMapKeys()
    {
        foreach (KeyValuePair<ForceGenerator2D, List<GameObject>> entry in forceGenerators)
        {
           // Debug.Log(entry.Key.GetType().ToString() + " count: " + entry.Value.Count);
        }

    }
}
