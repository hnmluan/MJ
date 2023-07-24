using System.Collections;
using UnityEngine;

public class MeleeAttack : PlayerAbstract
{
    //[Header("------------Other Settings------------")][Space(10)]

    [SerializeField] protected string damageObjectName = "Bow";

    [SerializeField] protected bool canAttack = true;

    [SerializeField] protected DamageObjectSO damageObjectSO;

    [SerializeField] protected Transform leftWeaponInAttack;

    [SerializeField] protected Transform rightWeaponInAttack;

    [SerializeField] protected Transform upWeaponInAttack;

    [SerializeField] protected Transform downWeaponInAttack;


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
                Debug.LogWarning(DetermineDirection(GetQuaternionToMouse()).name);
                Attack(damageObjectName);
                StartCoroutine(AttackCoolDown());
            }
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

    private void Attack(string projectileName) => SpawnDamageObject(projectileName, DetermineDirection(GetQuaternionToMouse()).position, GetQuaternionToMouse());

    private Quaternion GetQuaternionToMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        Vector3 target = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 direction = target - transform.position;
        direction.z = 0;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private Transform DetermineDirection(Quaternion rotation)
    {
        // Extract the angle from the Quaternion using eulerAngles
        float angle = rotation.eulerAngles.z;
        Debug.LogWarning(angle);


        // Define the angle thresholds to determine directions
        float upThreshold = 45f;
        float downThreshold = 135f;
        float leftThreshold = -135f;
        float rightThreshold = -45f;

        // Wrap angle to [0, 360] range
        if (angle < 0f)
            angle += 360f;

        // Determine the direction based on the angle
        if (angle > -upThreshold && angle <= upThreshold)
            return upWeaponInAttack;
        else if (angle > upThreshold && angle <= downThreshold)
            return downWeaponInAttack;
        else if (angle > downThreshold || angle <= leftThreshold)
            return leftWeaponInAttack;
        else
            return rightWeaponInAttack;
    }

}
