using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int PlayerHP;
    public int RealTimeHP;
    public Text healthtext;

    void Start()
    {
        PlayerHP = 20;
        RealTimeHP = PlayerHP;
    }

    void Update()
    {
        healthtext.text = "Health: " + RealTimeHP;

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    PlayerRealTimeHP--;
        //}

        if (RealTimeHP <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void PlayerTakingDamage(int damage)
    {
        RealTimeHP -= damage;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "E1B1")
        {
            RealTimeHP -= 1;
        }
        if (other.gameObject.tag == "E1B2")
        {
            RealTimeHP -= 2;
        }
        if (other.gameObject.tag == "E1B3")
        {
            RealTimeHP -= 3;
        }
    }
}
