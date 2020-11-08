using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ForceGenerator2D : MonoBehaviour
{
    [SerializeField] public bool autoRegister;

    public void RegisterForceGenerator()
    {
        ForceManager.registerForceGenerators(this);
        
    }
    public abstract PhysicsData UpdateForce(PhysicsData physicsData, float deltaTime);
}
