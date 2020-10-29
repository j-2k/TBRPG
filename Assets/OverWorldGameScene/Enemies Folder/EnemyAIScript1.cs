using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyAIScript1 : MonoBehaviour
{
    public GameObject[] waypoints;
    int index = 0;
    public float switchWaypointAtDistance = 0.3f;
    Vector3 direction;
    bool inverse;
    float distance;
    public float speed;

    public Color ColorState;
    public Renderer rend;

    Rigidbody Enemy1RB;

    bool PlayerAlert = false;
    bool PlayerChase = false;
    bool PVE = false;

    public GameObject Enemy1POS;
    public GameObject PlayerPOS;

    void Start()
    {
        GameObject.FindGameObjectWithTag("Player");
        speed = 4;
        Enemy1RB = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        rend.material.color = ColorState;
    }

    void FixedUpdate()
    {
        if (PlayerAlert == false)
        {
            float distance = Vector3.Distance(transform.position, waypoints[index].transform.position);
            if (distance < switchWaypointAtDistance)
            {
                if (index >= waypoints.Length - 1)
                {
                    index = -1;
                }
                index++;
                //
                direction = (waypoints[index].transform.position - transform.position).normalized;
            }
            transform.position += direction * speed * Time.deltaTime;

            if (Vector3.Distance(PlayerPOS.transform.position, Enemy1POS.transform.position) < 8)
            {
                PlayerAlert = true;
                PlayerChase = true;
            }
        }
        if (PlayerChase == true)
        {
            transform.LookAt(PlayerPOS.transform.position);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            //if (Vector3.Distance(PlayerPOS.transform.position, Enemy1POS.transform.position) < 2)
            //{
            //    PVE = true;
            //    PlayerChase = false;
            //}
        }
        if (PVE == true)
        {
            ColorState.a = 255;
            ColorState.r = 0;
            ColorState.g = 0;
            ColorState.b = 0;
            rend.material.color = ColorState;
            transform.Translate(Vector3.zero);
            //PlayerPOS.GetComponent<PlayerScript>().enabled = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            PVE = true;
            PlayerChase = false;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
