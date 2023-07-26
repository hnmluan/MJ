using UnityEngine;

public abstract class DamageObjectSO : ScriptableObject
{
    public string damageObjectName;

    public Sprite spriteInHand;

    public Sprite spriteInAttack;

    public float range;

    public int damage;

    public string discription;
}