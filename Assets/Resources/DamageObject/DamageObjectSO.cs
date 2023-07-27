using UnityEngine;

[CreateAssetMenu(fileName = "DamageObject", menuName = "SO/DamageObjectSO")]
public class DamageObjectSO : ScriptableObject
{
    public DamageObjectCode damageObjectCode = DamageObjectCode.NoDamageObject;

    public DamageObjectType damageObjectType = DamageObjectType.NoType;

    public string damageObjectName;

    public Sprite spriteInHand;

    public Sprite spriteInAttack;

    public float range;

    public int damage;

    public string discription;

    public float speed;

    public float attackTime;

    public float attackRate;
}