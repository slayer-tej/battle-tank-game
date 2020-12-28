using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TankScriptableObject" , menuName = "ScriptableObject/NewTankScriptableObject")]
public class TankScriptableObject : ScriptableObject{

    public TankType TankType;
    public int  speed;
    public int rotation;
    public int health;
    public Color TankColor;
}

[CreateAssetMenu(fileName = "TankScriptableObjectList", menuName = "ScriptableObject/NewTankScriptableObjectList")]
public class TankScriptableObjectList : ScriptableObject
{
    public TankScriptableObject[] EnemyTankList;
}