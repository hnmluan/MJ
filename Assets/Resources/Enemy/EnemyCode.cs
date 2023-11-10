using System;
using UnityEngine;

public enum EnemyCode
{
    NoEnemy,
    GreenBamboo,
    YellowBamboo,
    BlueFlam,
    RedFlam,
    BrownMouse,
    BlackMouse,
    GreenCyclope,
    RedCyclope,
    GreenDragonKid,
    YellowDragonKid,
    GreenFish,
    RedFish,
    RedSkull,
    BlueSkull,
    RedSpirit,
    BlueSpirit,
}

public class EnemyCodeParser
{
    public static EnemyCode FromString(string enemyCode)
    {
        try
        {
            return (EnemyCode)System.Enum.Parse(typeof(EnemyCode), enemyCode);
        }
        catch (ArgumentException e)
        {
            Debug.LogError(e.ToString());
            return EnemyCode.NoEnemy;
        }
    }
}

