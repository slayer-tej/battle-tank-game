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
        if (collision.gameObject.GetComponent<BoxCollider>() != null)
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                ParticleSystemsController.Instance.ShellExlposionOnMetal(contact.point);
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.GetComponent<MeshCollider>() != null)
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                ParticleSystemsController.Instance.ShellExlposionOnSand(contact.point);
                Destroy(gameObject);
            }
        }
            if (collision.gameObject.GetComponent<EnemyController>() != null)
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                ParticleSystemsController.Instance.ShellExlposionOnMetal(contact.point);
                BulletService.Instance.DamageEnemyTank(contact.point);
                Destroy(gameObject);
            }
        }
    }
}
