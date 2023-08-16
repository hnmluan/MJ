using UnityEngine;

[CreateAssetMenu(fileName = "DamageObject", menuName = "SO/DOSO")]
public class DamageObjectSO : ScriptableObject
{
    public DamageObjectCode damageObjectCode = DamageObjectCode.NoDamageObject;
    public DamageObjectType damageObjectType = DamageObjectType.NoType;
    public string keyName;
    public string keyDescription;
    public Sprite spriteInHand;
    public Sprite spriteInAttack;
    public float range;
    public int damage;
    public float speed;
    public float attackTime;
    public float attackRate;
}