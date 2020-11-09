using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private bool isQuitting = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        if(!isQuitting)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().AddScore();
            GameObject.Find("GameManager").GetComponent<GameManager>().SpawnNewTarget();
        }
        
    }

    void OnApplicationQuit()
    {
        isQuitting = true;
    }
}
