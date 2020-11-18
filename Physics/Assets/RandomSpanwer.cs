using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpanwer : MonoBehaviour
{

    public GameObject prefab;

    public float maxXOffset = 0;
    [Range(0, 1)]
    public float spawnChance = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Random.Range(0.0f,1.0f) < spawnChance)
        {
            float offset = Random.Range(-maxXOffset, maxXOffset);
            Vector2 loc = new Vector2(transform.position.x + offset, transform.position.y);
            GameObject obj = Instantiate(prefab);
            Particle2D particle = obj.GetComponent<Particle2D>();
            particle.physicsData.pos = loc;
            particle.physicsData.scale = new Vector2(0.5f, 0.5f);
        }
       
    }
}
