using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BulletService : MonoSingletonGeneric <BulletService>
{
    [SerializeField] private GameObject Shell;
    private Transform fireTransform;

    private void Start()
    {
        fireTransform = TankService.Instance.playerController.transform.GetChild(1).GetComponent<Transform>();
    }
    public void FireBullet(Transform FireTransform)
    {
        Debug.Log("Bullet Spawned");
        GameObject bullet = Instantiate(Shell,fireTransform.position,fireTransform.rotation);
        bullet.AddComponent<BulletController>();
        bullet.AddComponent<Rigidbody>();
        bullet.AddComponent<BoxCollider>();
    }
}
