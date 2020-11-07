using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private int Speed;
    private int Rotation;
    private int Health;
    private int Damage;
    private Color TankColor;
    private  Renderer Renderer;

    public void SetEnemyCharacteristics(TankScriptableObject enemytank)
    {
        Speed = enemytank.speed;
        Rotation = enemytank.rotation;
        Health = enemytank.health;
        Damage = enemytank.damage;
        TankColor = enemytank.TankColor;
    }   

    private void Awake()
    {
        //Renderer = gameObject.GetComponent<Renderer>();
    }

    private void Start()
    {
        //Renderer.GetComponent<Material>().color = TankColor;
    }


}
