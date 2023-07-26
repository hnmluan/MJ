using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "SO/EnemyProfile")]
public class EnemyProfileSO : ScriptableObject
{
    public EnemyCode itemCode = EnemyCode.NoEnemy;
    public EnemyType itemType = EnemyType.NoType;
    public string enemyName = "no-name";
    public int hpMax = 2;
    public List<DropRate> dropListItem;
    public string discription;
}
