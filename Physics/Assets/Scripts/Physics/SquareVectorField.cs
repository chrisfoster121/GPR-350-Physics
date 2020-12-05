using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareVectorField : VectorField
{
    public override Vector2 calcForce(Particle2D part)
    {
        Vector2 diff = part.physicsData.pos - new Vector2(transform.position.x, transform.position.y);
        diff.Normalize();
        diff *= -1;
        diff *= forceMultiplier;
        
        return diff;
    }
}
