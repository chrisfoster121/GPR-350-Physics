using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ParticleLink : MonoBehaviour
{
    public GameObject pair;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void CreateContacts();

    protected float GetLength()
    {
        return Vector2.Distance(GetComponent<Particle2D>().physicsData.pos, pair.GetComponent<Particle2D>().physicsData.pos);
    }
}
