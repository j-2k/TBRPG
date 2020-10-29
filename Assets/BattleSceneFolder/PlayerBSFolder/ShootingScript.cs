using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{

    public bool GunTrigger;

    public BulletScript Bullet;
    public BulletScript Bullet2;
    public BulletScript Bullet3;
    public float BulletSpeed;

    public float Shotstimer;
    float Shots;

    public Transform BulletLocation;
    public int BulletDamage;
    float Randomgun;

    void Start()
    {
        BulletSpeed = 10;
        BulletDamage = 1;
        Shotstimer = 3f;
    }

    void Update()
    {
        //if (GunTrigger == true)
        //{
        //    Shots -= Time.deltaTime;
        //    if (Shots <= 0)
        //    {
        //        Shots = Shotstimer;
        //        BulletScript newBullet = Instantiate(Bullet, BulletLocation.position, BulletLocation.rotation) as BulletScript;
        //        newBullet.Speed = BulletSpeed;
        //    }
        //}
        //else
        //{
        //    Shots = 0;
        //}
        if (GunTrigger == true)
        {
            Debug.Log("enemy shooting gun1");
            Randomgun = Random.Range(1, 4);
            if (Randomgun == 1)
            {
                Shots -= Time.deltaTime;
                if (Shots <= 0)
                {
                    Shots = Shotstimer;
                    BulletScript newBullet = Instantiate(Bullet, BulletLocation.position, BulletLocation.rotation) as BulletScript;
                    newBullet.Speed = BulletSpeed;
                }
            }
            if (Randomgun == 2)
            {
                Debug.Log("enemy shooting gun2");
                Shots -= Time.deltaTime;
                if (Shots <= 0)
                {
                    Shots = Shotstimer;
                    BulletScript newBullet2 = Instantiate(Bullet2, BulletLocation.position, BulletLocation.rotation) as BulletScript;
                    newBullet2.Speed = BulletSpeed;
                }
            }
            if (Randomgun == 3)
            {
                Debug.Log("enemy shooting gun3");
                Shots -= Time.deltaTime;
                if (Shots <= 0)
                {
                    Shots = Shotstimer;
                    BulletScript newBullet3 = Instantiate(Bullet3, BulletLocation.position, BulletLocation.rotation) as BulletScript;
                    newBullet3.Speed = BulletSpeed;
                }
            }
        }
        else
        {
            Shots = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy1BS")
        {
            other.gameObject.GetComponent<EnemyBSHealth>().DamageEnemy1BS(BulletDamage);
            Destroy(gameObject);
        }
    }
}
