using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCollider : Collider
{
    public float radius;
    Particle2D particle;

    // Start is called before the first frame update
    void Start()
    {
        type = ColliderType.Circle;
        radius = gameObject.GetComponent<Particle2D>().physicsData.scale.x * 0.5f;
        particle = gameObject.GetComponent<Particle2D>();
    }

    // Update is called once per frame
    void Update()
    {
        radius =  particle.physicsData.scale.x* 0.5f;
        if(type == ColliderType.Circle)
        {
            particle.physicsData.scale.y = particle.physicsData.scale.x;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(gameObject.transform.position, radius);
    }
}
