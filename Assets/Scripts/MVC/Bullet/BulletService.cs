using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BulletService : MonoSingletonGeneric <BulletService>
{
    public GameObject Shell;
    
    public void FireBullet(Transform FireTransform)
    {
        Debug.Log("Bullet Spawned");
        GameObject bullet = Instantiate(Shell,FireTransform.position,FireTransform.rotation);
        bullet.AddComponent<BulletController>();
        bullet.AddComponent<Rigidbody>();
    }
}
