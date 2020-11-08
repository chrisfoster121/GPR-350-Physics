using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleContact //: MonoBehaviour
{
    GameObject objOne;
    GameObject objTwo;
    float coefficientOfRestitution;
    float penetration;
    Vector2 contactNormal;
    Vector2 moveOne;
    Vector2 moveTwo;


    public float GetPenetration() { return penetration; }
    public void SetPen(float _pen) { penetration = _pen; }
    public GameObject GetOBJOne() { return objOne; }
    public GameObject GetOBJTwo() { return objTwo; }
    public Vector2 GetMoveOne() { return moveOne; }
    public Vector2 GetMoveTwo() { return moveTwo; }
    public Vector2 GetContactNormal() { return contactNormal; }

    public ParticleContact(GameObject _objOne, GameObject _objTwo, float _coefRest, float _pen, Vector2 _contactNormal)
    {
        objOne = _objOne;
        objTwo = _objTwo;
        coefficientOfRestitution = _coefRest;
        penetration = _pen;
        contactNormal = _contactNormal;
    }

    public float CalculateSeparatingVel()
    {
        Vector2 relVel = objOne.GetComponent<Particle2D>().physicsData.vel;

        if (objTwo)
        {
            relVel -= objTwo.GetComponent<Particle2D>().physicsData.vel;
        }
        return Vector2.Dot(relVel, contactNormal);
    }

    void ResolveVelocity(float dt)
    {
        float sepVel = CalculateSeparatingVel();

        if(sepVel > 0.0f)
        {
            return;
        }

        float newSepVel = -sepVel * coefficientOfRestitution;

        Vector2 velFromACC = objOne.GetComponent<Particle2D>().physicsData.acc;

        if (objTwo)
        {
            velFromACC -= objTwo.GetComponent<Particle2D>().physicsData.acc;
        }

        float accCauseSepVel = Vector2.Dot(velFromACC, contactNormal) * dt;

        if (accCauseSepVel < 0.0f)
        {
            newSepVel += coefficientOfRestitution * accCauseSepVel;
            if(newSepVel < 0.0f)
            {
                newSepVel = 0.0f;
            }
        }

        float deltaVel = newSepVel - sepVel;

        float totalInverseMass = objOne.GetComponent<Particle2D>().physicsData.GetInverseMass();
        if (objTwo)
        {
            totalInverseMass += objTwo.GetComponent<Particle2D>().physicsData.GetInverseMass();
        }

        if(totalInverseMass < 0)
        {
            return;
        }

        float impulse = deltaVel / totalInverseMass;

        Vector2 impulsePerImass = contactNormal * impulse;

        Vector2 newVel = objOne.GetComponent<Particle2D>().physicsData.vel + impulsePerImass * objOne.GetComponent<Particle2D>().physicsData.GetInverseMass();
        objOne.GetComponent<Particle2D>().physicsData.vel = newVel;

        if (objTwo)
        {
            newVel = objTwo.GetComponent<Particle2D>().physicsData.vel + impulsePerImass * -objTwo.GetComponent<Particle2D>().physicsData.GetInverseMass();
            objTwo.GetComponent<Particle2D>().physicsData.vel = newVel;
        }

    }

    void ResolveInterPenetration(float dt)
    {
        if(penetration < 0.0f)
        {
            return;
        }

        float totalInverseMass = objOne.GetComponent<Particle2D>().physicsData.GetInverseMass();
        if (objTwo)
        {
            totalInverseMass += objTwo.GetComponent<Particle2D>().physicsData.GetInverseMass();
        }

        if (totalInverseMass < 0)
        {
            return;
        }

        Vector2 movePerImass = contactNormal * (penetration / totalInverseMass);

        moveOne = movePerImass * objOne.GetComponent<Particle2D>().physicsData.GetInverseMass();

        if (objTwo)
        {
            moveTwo = movePerImass * -objTwo.GetComponent<Particle2D>().physicsData.GetInverseMass();
        }
        else
        {
            moveTwo = Vector2.zero;
        }
        Vector2 newPos = objOne.GetComponent<Particle2D>().physicsData.pos + moveOne;
        objOne.GetComponent<Particle2D>().physicsData.pos = newPos;

        if (objTwo)
        {
            newPos = objTwo.GetComponent<Particle2D>().physicsData.pos + moveTwo;
            objTwo.GetComponent<Particle2D>().physicsData.pos = newPos;
        }

    }

    public void Resolve(float dt)
    {
        ResolveVelocity(dt);
        ResolveInterPenetration(dt);
    }
}
