using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DamageObject", menuName = "SO/DOSO")]
public class WeaponProfileSO : ScriptableObject
{
    public WeaponCode damageObjectCode = WeaponCode.NoWeapon;

    public WeaponType damageObjectType = WeaponType.NoType;

    public string keyName;

    public string keyDescription;

    public Sprite spriteInHand;

    public Sprite spriteInAttack;

    public float range;

    public int damage;

    public float speed;

    public float attackTime;

    public float attackRate;

    public List<WeaponLevel> levels;
}