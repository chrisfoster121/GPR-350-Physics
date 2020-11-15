using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CollisionDetector 
{
    static List<KeyValuePair<Collider, Collider>> ignoredCollisions = new List<KeyValuePair<Collider, Collider>>();

    public static bool DetectCollision(Collider colliderOne, Collider colliderTwo)
    {
        CheckForInvalidIgnoredCollisions();

        foreach(KeyValuePair<Collider, Collider> pair in ignoredCollisions)
        {

            if (pair.Key == colliderOne && pair.Value == colliderTwo || pair.Key == colliderTwo && pair.Value == colliderOne)
                return false;
        }

        if(colliderOne.type == ColliderType.Circle && colliderTwo.type == ColliderType.Circle)
        {
            Vector3 vector = colliderOne.transform.position - colliderTwo.transform.position;
            if(vector.magnitude < ((CircleCollider)colliderOne).radius + ((CircleCollider)colliderTwo).radius)
            {
                return true;
            }
        }

        return false;
    }

    public static void CheckForInvalidIgnoredCollisions()
    {
        List<KeyValuePair<Collider, Collider>> invalidCollisions = new List<KeyValuePair<Collider, Collider>>();

        Debug.Log(ignoredCollisions.Count);

        foreach (KeyValuePair<Collider, Collider> pair in ignoredCollisions)
        {
            if (pair.Key == null || pair.Value == null)
                invalidCollisions.Add(pair);
        }

        foreach (KeyValuePair<Collider, Collider> pair in invalidCollisions)
            ignoredCollisions.Remove(pair);



    }

    public static void AddIgnoredCollision(Collider colliderOne, Collider colliderTwo)
    {
        ignoredCollisions.Add(new KeyValuePair<Collider, Collider>(colliderOne, colliderTwo));
    }
}
