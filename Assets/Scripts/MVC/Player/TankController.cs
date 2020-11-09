using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankController : MonoBehaviour
{   
    private FixedJoystick Joystick;
    private float speed = 10;
    private float rotate = 700;
    private int health = 100;
    private int damage = 10;


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
        if(horizontal > .3f || horizontal < -.3f)
        transform.Rotate(Vector3.up * rotate * Time.deltaTime * horizontal);
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

