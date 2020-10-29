using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayerScript : MonoBehaviour
{
    public Transform PlayerT;

    Vector3 CameraPlayer;
    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 1f;


    void Start()
    {
        CameraPlayer = transform.position - PlayerT.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = PlayerT.position + CameraPlayer;

        transform.position = Vector3.Slerp(transform.position, pos, SmoothFactor);
    }
}
