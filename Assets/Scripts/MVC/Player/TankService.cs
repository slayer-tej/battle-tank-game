using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankService : MonoSingletonGeneric<TankService>
{
    private TankController tankController;

    [SerializeField]
    private GameObject PlayerTank;
    [SerializeField]
    private Transform FireTransform;
    [SerializeField]
    private BoxCollider BoxCollider;
    [SerializeField]
    private Button FireButton;
 

    public FixedJoystick joystick;

    private void Start()
    {
        tankController = SpawnPlayerTank();
        Button Firebutton = FireButton.GetComponent<Button>();
        Firebutton.onClick.AddListener(FireBullets);
    }

    private void FireBullets()
    {
        BulletService.Instance.FireBullet(FireTransform);
    }

    public void DamageEnemy(Vector3 point)
    {
        EnemyService.Instance.TakeDamage(tankController.GetDamage,point);
    }
    public void KillPlayerTank(Vector3 point)
    {
        tankController.DestroyPlayerTank(point);
    }

    public TankController SpawnPlayerTank()
    {
        GameObject Tank = Instantiate(PlayerTank);
        FireTransform.transform.parent = Tank.transform;
        BoxCollider.transform.parent = Tank.transform;
        TankController tankController = Tank.AddComponent<TankController>();
        Tank.AddComponent<Rigidbody>();
        return tankController;
    }
}

