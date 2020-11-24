using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyService : MonoSingletonGeneric <EnemyService>
{
    [SerializeField]
    private List<Vector3> spawnPoints = new List<Vector3>();
    [SerializeField]
    private GameObject EnemyTank;
    [SerializeField]
    private TankScriptableObjectList tanks;
    [SerializeField]
    private Button SpawnEnemyButton;

    private EnemyController enemyController;

    private void Start()
    {
        Button EnemySpawn = SpawnEnemyButton.GetComponent<Button>();
        EnemySpawn.onClick.AddListener(GenerateRandomEnemySpawn);
    }

    public EnemyController SpawnEnemyTank(GameObject EnemyTankPrefab, int index ,int randompoint )
    {
        Debug.Log("Enemy Spawned");
        GameObject EnemyTank = Instantiate(EnemyTankPrefab, spawnPoints[randompoint], Quaternion.identity);
        EnemyTank.AddComponent<EnemyController>().SetEnemyCharacteristics(tanks.EnemyTankList[index]);
        EnemyController enemyController = EnemyTank.GetComponent<EnemyController>();
        EnemyTank.AddComponent<BoxCollider>();
        return enemyController;
    }

    private void GenerateRandomEnemySpawn()
    {
        int random = UnityEngine.Random.Range(0, tanks.EnemyTankList.Length);
        int randomspawnpoint = UnityEngine.Random.Range(0, spawnPoints.Count);
        enemyController = SpawnEnemyTank(EnemyTank, random,randomspawnpoint);
    }

    internal void TakeDamage(int getDamage, Vector3 point)
    {
        enemyController.TakeDamage(getDamage,point);
    }
};
