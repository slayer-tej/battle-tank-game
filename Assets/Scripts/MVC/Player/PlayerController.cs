using Effects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour , IDamageable
{   
    private FixedJoystick Joystick;
    [SerializeField]
    private float speed = 15;
    [SerializeField]
    private float rotate = 200;
    [SerializeField]
    private int Health = 100;
  

    private Button FireButton;
    private Transform FireFrom;
    private Coroutine coroutine;

    private void Start()
    {
        Joystick = TankService.Instance.joystick.GetComponent<FixedJoystick>();
        FireButton = TankService.Instance.FireButton.GetComponent<Button>();
        FireButton.onClick.AddListener(FireBullets);
    }

    private void Update()
    {
        TankMovement();
        TankRotate();
    }

    private void FireBullets()
    {
        BulletService.Instance.FireBullet(FireFrom);
    }

    private void TankMovement()
    {
        float vertical = Joystick.Vertical;
        if (vertical > .3f || vertical < -.3f)
        {
            transform.position = transform.position + transform.forward * speed * vertical * Time.deltaTime;
        }
    }

    private void TankRotate()
    {
        float horizontal = Joystick.Horizontal;
        if (horizontal > .3f || horizontal < -.3f)
        {
            transform.Rotate(Vector3.up * rotate * Time.deltaTime * horizontal);
        }
    }


    public void TakeDamage(int Dmg)
    {
        Health -= Dmg;
        if (Health <= 0)
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
            }
            coroutine = StartCoroutine(DestroyTank());
        }
    }

    IEnumerator DestroyTank()
    {
        VFXController vfx = VFXService.Instance.SetEffect(ParticleEffect.TankExplosion);
        vfx.PlayEffect(this.transform.position);
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}

