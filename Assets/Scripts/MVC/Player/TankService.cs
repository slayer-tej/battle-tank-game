using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoSingletonGeneric<TankService>
{
    public GameObject PlayerTank;
    public GameObject EnemyTank;
    public FixedJoystick joystick;
    public TankScriptableObjectList tanks;

    private void Start()
    {
       SpawnPlayerTank();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Debug.Log("Enemy TAnk");
            int random = UnityEngine.Random.Range(0, tanks.EnemyTankList.Length);
            SpawnEnemyTank(EnemyTank, random);
        }
    }

    private TankController SpawnPlayerTank()
    {
        GameObject Tank = Instantiate(PlayerTank);
        TankController tankController = Tank.AddComponent<TankController>();
        return tankController;
    }

    public void SpawnEnemyTank(GameObject EnemyTankPrefab, int index)
    {
        Debug.Log("Enemy created");
        GameObject EnemyTank = Instantiate(EnemyTankPrefab, Vector3.zero, Quaternion.identity);
        EnemyTank.AddComponent<EnemyController>().SetEnemyCharacteristics(tanks.EnemyTankList[index]);
    }
}

