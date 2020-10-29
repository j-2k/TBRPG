using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyBSHealth2 : MonoBehaviour
{
    public int healthenemy;
    public int currenthealthenemy;
    public Text healthtextenemy;
    private Rigidbody myrbe;
    public AttackingScript2 ChangingTurnsEnemy2;
    public EnemyShootingScript enemygun;
    public GameObject PlayerObject;
    public bool enemyturn;
    float Randomgun;
    float timer;
    float timer2;
    float timer3;
    public GameObject enemyturncanvas;
    public Text enemyturntext;

    void Start()
    {
        PlayerObject = GameObject.FindGameObjectWithTag("Player1BS");
        ChangingTurnsEnemy2 = PlayerObject.GetComponent<AttackingScript2>();
        myrbe = GetComponent<Rigidbody>();
        healthenemy = 20;
        currenthealthenemy = healthenemy;
        enemyturncanvas.SetActive(false);
    }

    void Update()
    {

        healthtextenemy.text = "Health: " + currenthealthenemy;
        enemyturntext.text = "Enemy's Turn";

        if (enemyturn == true)
        {
            Debug.Log("Enemy Turn Now");
            enemyturncanvas.SetActive(true);
            timer3 += Time.deltaTime;
            if (timer3 >= 2f)
            {
                Debug.Log("Timer3 ticking");
                timer2 += Time.deltaTime;
                if (timer2 >= 1f)
                {
                    Debug.Log("enemyshotnow");
                    enemygun.enemyguntrigger = true;
                }
                timer += Time.deltaTime;
                if (timer >= 1.1f)
                {
                    Debug.Log("enemyfinishedshooting");
                    enemygun.enemyguntrigger = false;
                    enemyturn = false;
                    ChangingTurnsEnemy2.playerturn = true;
                    enemyturncanvas.SetActive(false);
                    timer = 0;
                    timer3 = 0;
                }
            }
        }
        
        if (currenthealthenemy <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(5);
        }
    }

    public void DamageEnemy1BS(int damage)
    {
        currenthealthenemy -= damage;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PB1")
        {
            currenthealthenemy -= 1;
        }
        if (other.gameObject.tag == "PB2")
        {
            currenthealthenemy -= 3;
        }
        if (other.gameObject.tag == "PB3")
        {
            currenthealthenemy -= 5;
        }
    }
}
