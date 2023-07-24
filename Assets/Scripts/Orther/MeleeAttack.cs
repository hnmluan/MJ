using System.Collections;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] protected float fireRate = 0.2f;

    protected bool canFire = true;

    public string damageObjectName;

    private void Update()
    {
        if (canFire)
            if (Input.GetMouseButton(0))
            {
                Attack(damageObjectName);
                StartCoroutine(FireCoolDown());
            }
    }

    private IEnumerator FireCoolDown()
    {
        canFire = false;
        yield return new WaitForSeconds(fireRate);
        canFire = true;
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

    private void Attack(string projectileName) => SpawnDamageObject(projectileName, transform.position, GetQuaternionToMouse());

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
}
