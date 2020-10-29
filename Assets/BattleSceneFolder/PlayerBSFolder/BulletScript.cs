using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed;

    void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        Destroy(gameObject, 3);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy1BS")
        {
            Destroy(gameObject);
        }
    }
}