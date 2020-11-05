using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TankScriptableObject" , menuName = "ScriptableObject/NewTankScriptableObject")]
public class TankScriptableObject : ScriptableObject{

    public TankType TankType;
    public int  Speed;
    public int Rotation;
    public int health;
    public int damage;
}

[CreateAssetMenu(fileName = "TankScriptableObjectList", menuName = "ScriptableObject/NewTankScriptableObjectList")]
public class TankScriptableObjectList : ScriptableObject
{
    public TankScriptableObject[] EnemyTankList;
}