using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    PISTOL,
    MAX_WEAPON
}

public class Shooting : MonoBehaviour
{
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
             FireWeapon();
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
        }
    }

    void FirePistol()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = transform.position;
        Particle2D particle = bullet.GetComponent<Particle2D>();
        particle.physicsData.vel = gameObject.GetComponent<Particle2D>().physicsData.GetHeadingVector() * 10;
        particle.physicsData.pos = new Vector2(transform.position.x, transform.position.y);


    }
}
