using Effects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable
{
    private int Speed;
    private int Rotation;
    private int Health;
    private Color TankColor;
    private Coroutine coroutine;

    public void SetEnemyCharacteristics(TankScriptableObject enemytank)
    {
        Speed = enemytank.speed;
        Rotation = enemytank.rotation;
        Health = enemytank.health;
        TankColor = enemytank.TankColor;
    }

    public void TakeDamage(int Dmg)
    {
        Health -= Dmg;
        Debug.Log("Health : " + Health);
        if(Health <= 0)
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
            }

           coroutine = StartCoroutine(EnemyDeath());
        }
    }

    IEnumerator EnemyDeath()
    {
        VFXController vfx =  VFXService.Instance.SetEffect(ParticleEffect.TankExplosion);
        vfx.PlayEffect(transform.position);
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

}