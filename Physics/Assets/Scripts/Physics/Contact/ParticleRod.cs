using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleRod : ParticleLink
{
    public float length;
    public float restitution;
    public float penetrationDampener;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        CreateContacts();
    }

    public override void CreateContacts()
    {
        if (GetLength() == length)
        {
            return;
        }

        Vector2 normal = pair.GetComponent<Particle2D>().physicsData.pos - GetComponent<Particle2D>().physicsData.pos;

        
        float penetration = GetLength() - length;
        penetration /= penetrationDampener;

        if (penetration < 0.0f) //calculate in other direction
        {
            penetration = length - GetLength();
            penetration /= penetrationDampener;

            normal = GetComponent<Particle2D>().physicsData.pos - pair.GetComponent<Particle2D>().physicsData.pos;
        }

        normal.Normalize();
      

        ContactResolver.particleContacts.Add(new ParticleContact(gameObject, pair, restitution, penetration, normal));
    }
}
