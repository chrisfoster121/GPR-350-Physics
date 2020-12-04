using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystem : MonoBehaviour
{

    public GameObject particlePrefab;

    public int partsPerSecond;
    float timeBetween;
    float timeElapsed;


    // Start is called before the first frame update
    void Start()
    {
        timeBetween = 1 / partsPerSecond;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

       while (timeElapsed > timeBetween)
       {
            timeElapsed -= timeBetween;
            //Instantiate(particlePrefab);

       }
    }
}
