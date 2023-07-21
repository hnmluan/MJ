using System.Collections;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] protected float fireRate = 0.2f;

    protected bool canFire = true;

    //[SerializeField] protected int numProjectiles = 8;

    public string DOName;

    private void Update()
    {
        if (canFire)
            if (Input.GetMouseButton(0))
            {
                Attack(DOName);
                StartCoroutine(FireCoolDown());
            }
    }

    private IEnumerator FireCoolDown()
    {
        canFire = false;
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }

    private void SpawnDO(string projectileName, Vector3 positon, Quaternion quaternion)
    {
        Transform projectile = RangedDOSpawner.Instance.Spawn(projectileName, positon, quaternion);
        if (projectile == null) return;
        projectile.gameObject.SetActive(true);

        DamageSender damageReceiver = projectile.GetComponentInChildren<DamageSender>();
        damageReceiver.isDameFromPlayer = true;

        AudioController.Instance.PlayVFX("sfx_acttack_melee");
    }

    private void Attack(string projectileName) => SpawnDO(projectileName, transform.position, GetQuaternionToMouse());

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

    //private void FireBurstAroundPlayer(string projectileName, int numProjectiles)
    //{
    //    float angleStep = 360f / numProjectiles;
    //    float currentAngle = 0f;

    //    for (int i = 0; i < numProjectiles; i++)
    //    {
    //        Quaternion projectileRotation = Quaternion.AngleAxis(currentAngle, Vector3.forward);
    //        SpawnDO(projectileName, transform.position, projectileRotation);
    //        currentAngle += angleStep;
    //    }
    //}
}
