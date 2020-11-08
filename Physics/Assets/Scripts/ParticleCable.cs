using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCable : ParticleLink
{
    public float maxLength;
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
       if(GetLength() < maxLength)
       {
            return;
       }

        Vector2 normal = pair.GetComponent<Particle2D>().physicsData.pos - GetComponent<Particle2D>().physicsData.pos;

        normal.Normalize();
        float penetration = GetLength() - maxLength;
        penetration /= penetrationDampener;
        ContactResolver.particleContacts.Add(new ParticleContact(gameObject, pair, restitution, penetration, normal));
    }


}
