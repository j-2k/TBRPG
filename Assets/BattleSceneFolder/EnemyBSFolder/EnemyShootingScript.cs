using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingScript : MonoBehaviour
{
    public bool enemyguntrigger;
    public Transform EnemyBulletLocation;
    public EnemyBulletScript EnemyBullet;
    public EnemyBulletScript EnemyBullet2;
    public EnemyBulletScript EnemyBullet3;
    int bulletspeed = 10;
    float Shots;
    float Shotstimer;
    int bulletdamage;
    float Randomgun;

    void Start()
    {
        bulletdamage = 1;
        Shotstimer = 5f;
    }

    void Update()
    {
        if (enemyguntrigger == true)
        {
            Debug.Log("enemy shooting gun1");
            Randomgun = Random.Range(1, 4);
            if (Randomgun == 1)
            {
                Shots -= Time.deltaTime;
                if (Shots <= 0)
                {
                    Shots = Shotstimer;
                    EnemyBulletScript enemybullet = Instantiate(EnemyBullet, EnemyBulletLocation.position, EnemyBulletLocation.rotation) as EnemyBulletScript;
                    enemybullet.enemybulletSpeed = bulletspeed;
                }
            }
            if (Randomgun == 2)
            {
                Shots -= Time.deltaTime;
                if (Shots <= 0)
                {
                    Shots = Shotstimer;
                    EnemyBulletScript enemybullet2 = Instantiate(EnemyBullet2, EnemyBulletLocation.position, EnemyBulletLocation.rotation) as EnemyBulletScript;
                    enemybullet2.enemybulletSpeed = bulletspeed;
                }
            }
            if (Randomgun == 3)
            {
                Shots -= Time.deltaTime;
                if (Shots <= 0)
                {
                    Shots = Shotstimer;
                    EnemyBulletScript enemybullet3 = Instantiate(EnemyBullet3, EnemyBulletLocation.position, EnemyBulletLocation.rotation) as EnemyBulletScript;
                    enemybullet3.enemybulletSpeed = bulletspeed;
                }
            }
        }
        else
        {
                Shots = 0;
        }
        //if (enemygun3trigger == true)
        //{
        //    Debug.Log("enemy shooting gun3");
        //    Shots -= Time.deltaTime;
        //    if (Shots <= 0)
        //    {
        //        Shots = Shotstimer;
        //        EnemyBulletScript enemybullet = Instantiate(EnemyBullet, EnemyBulletLocation.position, EnemyBulletLocation.rotation) as EnemyBulletScript;
        //        enemybullet.enemybulletSpeed = bulletspeed;
        //    }
        //}
        //else
        //{
        //    Shots = 0;
        //}
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player1BS")
        {
            other.gameObject.GetComponent<PlayerHealth>().PlayerTakingDamage(bulletdamage);
            Destroy(gameObject);
        }
    }
}
