using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemsController : MonoSingletonGeneric <ParticleSystemsController>
{   [SerializeField]
    private GameObject TankExplosionPrefab;
    [SerializeField]
    private GameObject BulletCollisionPrefab;
    [SerializeField]
    private GameObject BulletCollisionMetalPrefab;

    internal void TankExplosion(Vector3 point)
    {
        GameObject Explode = Instantiate(TankExplosionPrefab,point,Quaternion.identity);
        Explode.GetComponent<ParticleSystem>().Play();

    }

    internal void ShellExlposionOnSand(Vector3 ContactPoint)
    {
        GameObject Explode = Instantiate(BulletCollisionPrefab,ContactPoint,Quaternion.identity);
        Explode.GetComponent<ParticleSystem>().Play();
    }

    internal void ShellExlposionOnMetal(Vector3 point)
    {
        GameObject Explode = Instantiate(BulletCollisionMetalPrefab, point, Quaternion.identity);
        Explode.GetComponent<ParticleSystem>().Play();

    }
}
