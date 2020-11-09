using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    PISTOL,
    CHAIN_SHOT,
    ROD_SHOT,
    MAX_WEAPON
}

public class Shooting : MonoBehaviour
{
    [Range(0.1f,0.009f )]
    public float rotationSpeed;

    public float bulletSpeed;


    public WeaponType weaponType = WeaponType.PISTOL;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            ChangeWeapon();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
             FireWeapon();
        }

        if (Input.GetKey(KeyCode.Alpha1))
        {
            gameObject.GetComponent<Particle2D>().physicsData.facing += rotationSpeed;
            
            if(gameObject.GetComponent<Particle2D>().physicsData.facing > 1)
            {
               // gameObject.GetComponent<Particle2D>().physicsData.facing = 1;
            }

        
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            gameObject.GetComponent<Particle2D>().physicsData.facing -= rotationSpeed;

            if(gameObject.GetComponent<Particle2D>().physicsData.facing < -1) 
            {
                //gameObject.GetComponent<Particle2D>().physicsData.facing = -1;
            }
        }
        
    }

    void ChangeWeapon()
    {
        weaponType++;

        if(weaponType == WeaponType.MAX_WEAPON)
        {
            weaponType = WeaponType.PISTOL;
        }

    }
    
    void FireWeapon()
    {
        switch (weaponType)
        {
            case WeaponType.PISTOL:
                FirePistol();
                break;
            case WeaponType.CHAIN_SHOT:
                FireChainShot();
                break;
            case WeaponType.ROD_SHOT:
                FireRod();
                break;
        }
    }

    void FirePistol()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        //Destroy(bullet,10f);
        bullet.transform.position = transform.position;
        Particle2D particle = bullet.GetComponent<Particle2D>();
        particle.physicsData.vel = gameObject.GetComponent<Particle2D>().physicsData.GetHeadingVector() * bulletSpeed;
        particle.physicsData.pos = new Vector2(transform.position.x, transform.position.y);
        particle.physicsData.scale = new Vector2(0.5f, 0.5f);

        StartCoroutine(RemoveOBJFromForceManager(bullet));


    }
    
    void FireChainShot()
    {
        GameObject bulletOne = Instantiate(bulletPrefab);
        bulletOne.transform.position = transform.position;
        bulletOne.AddComponent<SpringForceGenerator>();

        Particle2D particleOne = bulletOne.GetComponent<Particle2D>();
        particleOne.physicsData.vel = gameObject.GetComponent<Particle2D>().physicsData.GetHeadingVector() * (bulletSpeed - 5f);
        particleOne.physicsData.pos = new Vector2(transform.position.x, transform.position.y);
        particleOne.physicsData.scale = new Vector2(0.5f, 0.5f);

        GameObject bulletTwo = Instantiate(bulletPrefab);
        bulletTwo.transform.position = transform.position;
        bulletOne.GetComponent<SpringForceGenerator>().pair = bulletTwo;
        bulletOne.GetComponent<SpringForceGenerator>().springConst = 40;
        bulletOne.GetComponent<SpringForceGenerator>().restLength = 2;
        bulletOne.GetComponent<SpringForceGenerator>().dampener = 5;

        Particle2D particleTwo = bulletTwo.GetComponent<Particle2D>();
        particleTwo.physicsData.vel = gameObject.GetComponent<Particle2D>().physicsData.GetHeadingVector() * 25;
        particleTwo.physicsData.pos = new Vector2(transform.position.x, transform.position.y + 1);
        particleTwo.physicsData.scale = new Vector2(0.5f, 0.5f);

        bulletOne.GetComponent<SpringForceGenerator>().RegisterForceGenerator();
        bulletOne.GetComponent<SpringForceGenerator>().RegisterPhysicsObjects();

        StartCoroutine(RemoveOBJFromForceManager(bulletOne));
        StartCoroutine(RemoveOBJFromForceManager(bulletTwo));
    }

    void FireRod()
    {
        GameObject bulletOne = Instantiate(bulletPrefab);
        bulletOne.transform.position = transform.position;
        bulletOne.AddComponent<ParticleRod>();

        Particle2D particleOne = bulletOne.GetComponent<Particle2D>();
        particleOne.physicsData.vel = gameObject.GetComponent<Particle2D>().physicsData.GetHeadingVector() * (bulletSpeed - 5f);
        particleOne.physicsData.pos = new Vector2(transform.position.x, transform.position.y);
        particleOne.physicsData.scale = new Vector2(0.5f, 0.5f);

        GameObject bulletTwo = Instantiate(bulletPrefab);
        bulletTwo.transform.position = transform.position;
        //bulletTwo.GetComponent<BouyancyForceGenerator>().enabled = false;

        bulletOne.GetComponent<ParticleRod>().pair = bulletTwo;
        bulletOne.GetComponent<ParticleRod>().restitution = .5f;
        bulletOne.GetComponent<ParticleRod>().length = 2;
        bulletOne.GetComponent<ParticleRod>().penetrationDampener = 100;

        Particle2D particleTwo = bulletTwo.GetComponent<Particle2D>();
        particleTwo.physicsData.vel = gameObject.GetComponent<Particle2D>().physicsData.GetHeadingVector() * 25;
        particleTwo.physicsData.pos = new Vector2(transform.position.x, transform.position.y + 1);
        particleTwo.physicsData.scale = new Vector2(0.5f, 0.5f);

        //bulletOne.GetComponent<SpringForceGenerator>().RegisterForceGenerator();
        //bulletOne.GetComponent<SpringForceGenerator>().RegisterPhysicsObjects();

        StartCoroutine(RemoveOBJFromForceManager(bulletOne));
        StartCoroutine(RemoveOBJFromForceManager(bulletTwo));
    }

    IEnumerator RemoveOBJFromForceManager(GameObject obj)
    {
        yield return new WaitForSeconds(10f);

        ForceManager.deregisterPhysicsObject(obj);
        GameObject.Find("PhysicsManager").GetComponent<PhysicsManager>().DeregisterParticle(obj.GetComponent<Particle2D>());

        Destroy(obj);

    }
}
