using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankController : MonoBehaviour
{   
    private FixedJoystick Joystick;
    [SerializeField]
    private float speed = 15;
    [SerializeField]
    private float rotate = 200;
    [SerializeField]
    private int health = 100;
    [SerializeField]
    private int damage = 10;
    private EnemyController enemyController;



    private void Start()
    {
        Joystick = TankService.Instance.joystick.GetComponent<FixedJoystick>();
    }

    private void Update()
    {
        TankMovement();
        TankRotate();
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

    public void DestroyPlayerTank(Vector3 point)
    {
        StartCoroutine(DestroyTank(point));
    }
    IEnumerator DestroyTank(Vector3 point)
    {
        ParticleSystemsController.Instance.TankExplosion(point);
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    public int GetDamage
    {
        get { return damage;}
    }
    public int GetHealth
    {
        get { return health;}
    }
}

