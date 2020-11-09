using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private float BulletSpeed=800;
    private void Start()
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * BulletSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BoxCollider>() || collision.gameObject.GetComponent<Rigidbody>() != null)
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.GetComponent<EnemyController>() != null)
        {
            BulletService.Instance.DamageEnemyTank();
            Destroy(gameObject);
        }
    }
}
