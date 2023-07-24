using UnityEngine;

[CreateAssetMenu(fileName = "DamageObject", menuName = "ScriptableObjects/DamageObject")]
public class DamageObjectSO : ScriptableObject
{
    public string damageObjectName;

    public Sprite spriteInHand;

    public Sprite spriteInAttack;

    public float range;

    public float speed;

    public int damage;

    public string discription;

    public float fireRate;
}