using System.Collections;
using UnityEngine;

public class MeleeAttack : PlayerAbstract
{
    //[Header("------------Other Settings------------")][Space(10)]

    [SerializeField] protected string damageObjectName = "Bow";

    [SerializeField] protected bool canAttack = true;

    [SerializeField] protected DamageObjectSO damageObjectSO;

    [Header("------------Weapon In Hand------------")]
    [Space(10)]

    [SerializeField] protected Transform leftWeaponInHand;

    [SerializeField] protected Transform rightWeaponInHand;

    [SerializeField] protected Transform upWeaponInHand;

    [SerializeField] protected Transform downWeaponInHand;

    [SerializeField] protected Transform weaponInHand;

    [Header("------------Weapon In Attack------------")]
    [Space(10)]

    [SerializeField] protected float rotationSpeed = 200f;

    [SerializeField] protected float circleRadius = 0.5f;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageObjectSO();
    }

    protected virtual void LoadDamageObjectSO()
    {
        if (this.damageObjectSO != null) return;
        string resPath = "DamageObject/Ranged/" + damageObjectName;
        this.damageObjectSO = Resources.Load<DamageObjectSO>(resPath);
        Debug.LogWarning(transform.name + ": LoadDamageObjectSO " + resPath, gameObject);
    }

    private void Update()
    {
        LoadDamageObjectSO();

        if (canAttack)
            if (Input.GetMouseButton(0))
            {
                Attack(damageObjectName);
                StartCoroutine(AttackCoolDown());
            }

        if (Input.GetMouseButton(0))
            SetPositionWeaponInAttack();
        else
            SetPositionWeaponInHand();
    }

    private IEnumerator AttackCoolDown()
    {
        canAttack = false;
        yield return new WaitForSeconds(damageObjectSO.fireRate);
        canAttack = true;
    }

    private void SpawnDamageObject(string damageObjectName, Vector3 positon, Quaternion quaternion)
    {
        Transform damageObject = DamageObjectSpawner.Instance.Spawn(damageObjectName, positon, quaternion);
        if (damageObject == null) return;
        damageObject.gameObject.SetActive(true);

        DamageSender damageReceiver = damageObject.GetComponentInChildren<DamageSender>();
        damageReceiver.isDameFromPlayer = true;

        AudioController.Instance.PlayVFX("sfx_acttack_melee");
    }

    private void Attack(string projectileName) => SpawnDamageObject(projectileName, weaponInHand.position, GetQuaternionToMouse());

    public Vector3 GetDirectionToMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        Vector3 target = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 direction = target - transform.position;
        direction.z = 0;
        direction.Normalize();
        return direction;
    }

    private Quaternion GetQuaternionToMouse()
    {
        float angle = Mathf.Atan2(GetDirectionToMouse().y, GetDirectionToMouse().x) * Mathf.Rad2Deg;
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void SetPositionWeaponInAttack()
    {
        float angle = Mathf.Atan2(GetDirectionToMouse().y, GetDirectionToMouse().x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        weaponInHand.rotation = Quaternion.RotateTowards(weaponInHand.rotation, rotation, rotationSpeed * Time.deltaTime);
        weaponInHand.localScale = new Vector3(1, 1, 1);
        Vector3 circularPosition = transform.position + Quaternion.Euler(0, 0, angle) * Vector3.right * circleRadius;
        weaponInHand.position = circularPosition;
    }

    public Transform GetPositionWeaponInHand()
    {
        if (playerCtrl.Animator.GetFloat("X") == 1) return rightWeaponInHand;
        else if (playerCtrl.Animator.GetFloat("X") == -1) return leftWeaponInHand;
        else if (playerCtrl.Animator.GetFloat("Y") == 1) return upWeaponInHand;
        else return downWeaponInHand;
    }

    public void SetPositionWeaponInHand()
    {
        weaponInHand.position = GetPositionWeaponInHand().position;
        weaponInHand.rotation = Quaternion.Euler(0f, 0f, 0f);
        weaponInHand.localScale = new Vector3(1, 1, 1);
        if (playerCtrl.Animator.GetFloat("X") == -1) weaponInHand.localScale = new Vector3(-1, 1, 1);

    }
}
