using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemsController : MonoSingletonGeneric <ParticleSystemsController>
{
    public GameObject TankExplosionPrefab;
    public GameObject BulletCollisionPrefab;

    internal void TankExplosion()
    {
        GameObject Explode = Instantiate(TankExplosionPrefab);
        Explode.GetComponent<ParticleSystem>().Play();
    }

    internal void WallCollision(Vector3 ContactPoint)
    {
        GameObject Explode = Instantiate(BulletCollisionPrefab,ContactPoint,Quaternion.identity);
        Explode.GetComponent<ParticleSystem>().Play();

    }

    
}
