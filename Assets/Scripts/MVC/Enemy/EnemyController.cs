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
    private Renderer Renderer;

    public void SetEnemyCharacteristics(TankScriptableObject enemytank)
    {
        Speed = enemytank.speed;
        Rotation = enemytank.rotation;
        Health = enemytank.health;
        Damage = enemytank.damage;
        TankColor = enemytank.TankColor;
    }

    public void TakeDamage(int Dmg)
    {
        if (Health > 0)
        {
            Health -= Dmg;
            Debug.Log("Health : " + Health);
        }
        else
        {
            ParticleSystemsController.Instance.TankExplosion();
            Destroy(gameObject);
        }
    }
}