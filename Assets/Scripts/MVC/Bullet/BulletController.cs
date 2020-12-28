using Effects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float BulletSpeed=28;
    private int BulletDamage = 10;

    private void Start()
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * BulletSpeed;
    }

    private void OnCollisionEnter(Collision other)
    {
        VFXController vfx;
        IDamageable damageableObject = other.gameObject.GetComponent<IDamageable>();
        if(other.gameObject.GetComponent<IDamageable>() != null)
        {
            vfx = VFXService.Instance.SetEffect(ParticleEffect.ShellExplosionOnTank);
            vfx.PlayEffect(transform.position);
            damageableObject.TakeDamage(BulletDamage);
        }
        else
        {
            vfx = VFXService.Instance.SetEffect(ParticleEffect.ShellExplosionOnGround);
            vfx.PlayEffect(transform.position);
            Destroy(this.gameObject);
        }
    }
}
