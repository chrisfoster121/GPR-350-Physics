using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradiantVectorField : VectorField
{
    public override Vector2 calcForce(Particle2D part)
    {
        Vector2 diff = part.physicsData.pos - new Vector2(transform.position.x, transform.position.y);


        Vector2 diff2 = new Vector2(diff.x, -diff.y);

        diff2 *= forceMultiplier;

        return diff2;
    }
}
