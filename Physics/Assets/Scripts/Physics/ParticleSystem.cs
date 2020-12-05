using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystem : MonoBehaviour
{

    public GameObject particlePrefab;

    public int partsPerSecond;
    public float particleLifetime;
    public float facing;
    public float angle;
    public float speed;

    float timeBetween;
    float timeElapsed;

    private VectorField[] vfs;


    // Start is called before the first frame update
    void Start()
    {
        timeBetween = 1.0f / partsPerSecond;

        vfs = GetComponents<VectorField>();

        
        
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

       while (timeElapsed > timeBetween)
       {
            timeElapsed -= timeBetween;
            GameObject particle = Instantiate(particlePrefab);
            particle.GetComponent<Particle2D>().physicsData.pos = transform.position;
            particle.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));

            float theta = facing + (Random.Range(-1.0f, 1.0f) * angle);

            Vector2 direction = new Vector2(Mathf.Cos(theta * Mathf.Deg2Rad), Mathf.Sin(theta * Mathf.Deg2Rad));
            direction *= speed;

            particle.GetComponent<Particle2D>().physicsData.vel += direction;

            
            foreach(VectorField vf in vfs)
            {
                vf.RegisterParticle(particle.GetComponent<Particle2D>());
            }

            StartCoroutine(DeleteParticle(particle));
       }
    }

    IEnumerator DeleteParticle(GameObject obj)
    {
        yield return new WaitForSeconds(particleLifetime);

        foreach (VectorField vf in vfs)
        {
            vf.DeregisterParticle(obj.GetComponent<Particle2D>());
        }
        
        Destroy(obj);
    }
}
