using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerScript : MonoBehaviour
{
    public float PlayerSpeed;
    NavMeshAgent NavMeshPlayer;
    bool StopCasting;
    private Rigidbody MyRigidbody;

    GameObject FadeScriptScene;

    void Start()
    {
        PlayerSpeed = 5;
        NavMeshPlayer = GetComponent<NavMeshAgent>();
        MyRigidbody = GetComponent<Rigidbody>();
        //FadeScriptScene = GameObject.FindWithTag("FadeTag").GetComponent<FadingScript>;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StopCasting = false;
            Clicktomove();
        }
    }

    void Clicktomove()
    {
        if (StopCasting == false)
        {
            Ray raycastcheck = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(raycastcheck, out hit, 100))
            {
                NavMeshPlayer.destination = hit.point;
            }
        }
        else
        {
            Debug.Log("raycast has been stopped");
        }
    }
}
