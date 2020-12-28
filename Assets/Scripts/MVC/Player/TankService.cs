using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankService : MonoSingletonGeneric<TankService>
{

    [SerializeField]
    private GameObject TankPrefab;
    [SerializeField]
    private List<Vector3> spawnPoints = new List<Vector3>();
    [SerializeField]
    private TankScriptableObjectList tanks;
    [SerializeField]
    private Button SpawnEnemyButton;
    private EnemyController enemyController;

    [HideInInspector]
    public PlayerController playerController;

    public Button FireButton;
    public FixedJoystick joystick;

    private void Start()
    {
       playerController = SpawnPlayerTank();
       Button EnemySpawn = SpawnEnemyButton.GetComponent<Button>();
       EnemySpawn.onClick.AddListener(GenerateRandomEnemySpawn);
    }

    private void GenerateRandomEnemySpawn()
    {
        int random = UnityEngine.Random.Range(0, tanks.EnemyTankList.Length);
        int randomspawnpoint = UnityEngine.Random.Range(0, spawnPoints.Count);
        enemyController = SpawnEnemyTank(TankPrefab, random, randomspawnpoint);
    }

    public PlayerController SpawnPlayerTank()
    {
        GameObject playerTank = Instantiate(TankPrefab);
        PlayerController tankController = playerTank.AddComponent<PlayerController>();
        return tankController;
    }

    public EnemyController SpawnEnemyTank(GameObject EnemyTankPrefab, int index, int randompoint)
    {
        Debug.Log("Enemy Spawned");
        GameObject enemyTank = Instantiate(EnemyTankPrefab, spawnPoints[randompoint], Quaternion.identity);
        enemyTank.AddComponent<EnemyController>().SetEnemyCharacteristics(tanks.EnemyTankList[index]);
        EnemyController enemyController = enemyTank.GetComponent<EnemyController>();
        return enemyController;
    }

   
}

