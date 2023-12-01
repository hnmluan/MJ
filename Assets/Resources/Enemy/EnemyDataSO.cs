using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObject/Enemy")]
public class EnemyDataSO : ScriptableObject
{
    public EnemyCode enemyCode = EnemyCode.NoEnemy;

    public EnemyType enemyType = EnemyType.NoType;

    public string keyName = "no-name";

    public string keyDescription = "no-keyDiscription";

    public Sprite portrait;

    public Sprite visual;

    public RuntimeAnimatorController animator;

    public int hpMax;

    public List<ItemDropRate> dropListItem;

    public float trackRange = 5.0f;

    public float acttackRange = 2.0f;

    public float nonMoveableRange = 1.0f;

    public float speed = 1.0f;

    public static EnemyDataSO FindByItemCode(EnemyCode enemyCode)
    {
        var profiles = Resources.LoadAll("Enemy/ScriptableObject", typeof(EnemyDataSO));
        foreach (EnemyDataSO profile in profiles)
        {
            if (profile.enemyCode != enemyCode) continue;
            return profile;
        }
        return null;
    }

    public static EnemyDataSO FindByName(string name)
    {
        EnemyCode enemyCode;
        Enum.TryParse(name, out enemyCode);
        return FindByItemCode(enemyCode);
    }

    public static List<EnemyDataSO> GetAllSO() => new List<EnemyDataSO>(Resources.LoadAll<EnemyDataSO>("Enemy/ScriptableObject"));
}
