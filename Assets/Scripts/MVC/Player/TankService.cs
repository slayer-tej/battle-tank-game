using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoSingletonGeneric<TankService>
{
    public GameObject TankPrefab;
    public FixedJoystick joystick;

    private void Start()
    {
        SpawnPlayerTank();
    }

    private TankController SpawnPlayerTank()
    {
        Instantiate(TankPrefab);
        TankController tankController = gameObject.GetComponent<TankController>();
        tankController.joystick = joystick;
        return tankController;
    }

}