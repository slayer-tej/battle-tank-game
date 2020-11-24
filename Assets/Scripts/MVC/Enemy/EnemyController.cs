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
    private Coroutine coroutine;

    private void OnCollisionEnter(Collision collision)
    {   if (collision.gameObject.GetComponent<TankController>() != null)
        {
            foreach (ContactPoint contact in collision.contacts)
                TankService.Instance.KillPlayerTank(contact.point);
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

    public void TakeDamage(int Dmg, Vector3 point)
    {
        if (Health > 0)
        {
            Health -= Dmg;
            Debug.Log("Health : " + Health);
        }
        else
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
            }

           coroutine = StartCoroutine(EnemyDeath(point));
        }
    }
    IEnumerator EnemyDeath(Vector3 point)
    {
        ParticleSystemsController.Instance.TankExplosion(point);
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}