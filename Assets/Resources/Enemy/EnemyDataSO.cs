using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObject/Enemy")]
public class EnemyDataSO : ScriptableObject
{
    public EnemyCode itemCode = EnemyCode.NoEnemy;
    public EnemyType itemType = EnemyType.NoType;
    public string keyName = "no-name";
    public string keyDescription = "no-keyDiscription";
    public Sprite sprite;
    public int hpMax = 2;
    public List<ItemDropRate> dropListItem;
    public string discription;
}
