using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deadenemyscript : MonoBehaviour
{
    public GameObject PlayerOverworld;
    public GameObject EnemyOverworld;
    public GameObject deadtextcanvas;
    public Text deadtext;

    void Start()
    {
        
    }

    void Update()
    {
        if (Vector3.Distance(PlayerOverworld.transform.position, EnemyOverworld.transform.position) < 4)
        {
            deadtextcanvas.SetActive(true);
        }
        else
        {
            deadtextcanvas.SetActive(false);
        }
    }
}
