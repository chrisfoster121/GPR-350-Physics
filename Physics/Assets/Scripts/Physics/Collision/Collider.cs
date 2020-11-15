using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColliderType
{
    Default,
    Circle,
    Max
}

[RequireComponent(typeof(Particle2D))]
public class Collider : MonoBehaviour
{
    public ColliderType type = ColliderType.Default;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
