using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObject/Enemy")]
public class EnemyDataSO : ScriptableObject
{
    public EnemyCode itemCode = EnemyCode.NoEnemy;

    public EnemyType itemType = EnemyType.NoType;

    public string keyName = "no-name";

    public string keyDescription = "no-keyDiscription";

    public Sprite portrait;

    public int hpMax;

    public List<ItemDropRate> dropListItem;
}
