using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankService : MonoSingletonGeneric<TankService>
{
    public GameObject PlayerTank;
    public GameObject EnemyTank;
    public FixedJoystick joystick;
    public TankScriptableObjectList tanks;
    public Transform FireTransform;
    public Button FireButton;



    private void Start()
    {
       SpawnPlayerTank();
       Button button = FireButton.GetComponent<Button>();
       button.onClick.AddListener(FireBullets);
    }
   
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Debug.Log("Enemy Tank");
            int random = UnityEngine.Random.Range(0, tanks.EnemyTankList.Length);
            SpawnEnemyTank(EnemyTank, random);
        }
    }

    private void FireBullets()
    {
        BulletService.Instance.FireBullet(FireTransform);
    }

    public void SpawnPlayerTank()
    {
        GameObject Tank = Instantiate(PlayerTank);
        FireTransform.transform.parent = Tank.transform;
        TankController tankController = Tank.AddComponent<TankController>();
        //return tankController;
    }

    public void SpawnEnemyTank(GameObject EnemyTankPrefab, int index)
    {
        Debug.Log("Enemy created");
        GameObject EnemyTank = Instantiate(EnemyTankPrefab, Vector3.zero, Quaternion.identity);
        EnemyTank.AddComponent<EnemyController>().SetEnemyCharacteristics(tanks.EnemyTankList[index]);
    }
}

