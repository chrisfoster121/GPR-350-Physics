using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsManager : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        ContactResolver.iterations = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ContactResolver.particleContacts.Count);
    }

    void FixedUpdate()
    {
        ForceManager.updateAllForceGenerators(Time.deltaTime);
        ContactResolver.ResolveContacts(Time.deltaTime);
    }
}
