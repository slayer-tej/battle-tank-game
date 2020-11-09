using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankService : MonoSingletonGeneric<TankService>
{
    private EnemyController enemyController;
    private TankController tankController;

    public GameObject PlayerTank;
    public GameObject EnemyTank;
    public FixedJoystick joystick;
    public TankScriptableObjectList tanks;
    public Transform FireTransform;
    public Button FireButton;

    private void Start()
    {
       tankController = SpawnPlayerTank();
       Button button = FireButton.GetComponent<Button>();
       button.onClick.AddListener(FireBullets);
    }
   
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Debug.Log("Enemy Tank Spawned");
            int random = UnityEngine.Random.Range(0, tanks.EnemyTankList.Length);
            enemyController = SpawnEnemyTank(EnemyTank, random);
        }
    }

    private void FireBullets()
    {
        BulletService.Instance.FireBullet(FireTransform);
    }

    public void TakeDamage()
    {
        enemyController.TakeDamage(tankController.GetDamage);
    }

    public TankController SpawnPlayerTank()
    {
        GameObject Tank = Instantiate(PlayerTank);
        FireTransform.transform.parent = Tank.transform;
        TankController tankController = Tank.AddComponent<TankController>();
        Tank.AddComponent<BoxCollider>();
        Tank.AddComponent<Rigidbody>();
        return tankController;
    }

    public EnemyController SpawnEnemyTank(GameObject EnemyTankPrefab, int index)
    {
        Debug.Log("Enemy created");
        GameObject EnemyTank = Instantiate(EnemyTankPrefab, Vector3.zero, Quaternion.identity);
        EnemyTank.AddComponent<EnemyController>().SetEnemyCharacteristics(tanks.EnemyTankList[index]);
        EnemyController enemyController = EnemyTank.GetComponent<EnemyController>();
        EnemyTank.AddComponent<BoxCollider>();
        return enemyController;
    }
}

