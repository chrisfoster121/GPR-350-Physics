using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VectorField : MonoBehaviour
{
    List<Particle2D> registeredParticles;

    public float forceMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        registeredParticles = new List<Particle2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateParticles();
    }

    public void RegisterParticle(Particle2D part)
    {
        registeredParticles.Add(part);
    }

    public void DeregisterParticle(Particle2D part)
    {
        registeredParticles.Remove(part);
    }

    public abstract Vector2 calcForce(Particle2D part);
    
    private void UpdateParticles()
    {
        for(int i = 0; i<registeredParticles.Count; i++)
        {

            registeredParticles[i].physicsData.accumulatedForces += calcForce(registeredParticles[i]);

        }
    }
}
