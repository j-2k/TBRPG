using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public float enemybulletSpeed;

    void Update()
    {
        transform.Translate(Vector3.forward * enemybulletSpeed * Time.deltaTime);
        Destroy(gameObject, 3);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player1BS")
        {
            Destroy(gameObject);
        }
    }
}
