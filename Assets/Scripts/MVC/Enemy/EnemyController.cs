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

    private void OnCollisionEnter(Collision collision)
    {   if (collision.gameObject.GetComponent<TankController>() != null)
        {
            TankService.Instance.KillPlayerTank();
        }
        
    }

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

        if (Health == 0)
        {
            ParticleSystemsController.Instance.TankExplosion();
            Destroy(gameObject,2f);
        }
    }

}