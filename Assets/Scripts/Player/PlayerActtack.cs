using UnityEngine;

public class PlayerActtack : PlayerAbstract
{
    public string weaponName;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Quaternion bulletRotation = Quaternion.LookRotation(Vector3.forward, new Vector2(playerCtrl.Animator.GetFloat("X"), playerCtrl.Animator.GetFloat("Y")));
            Transform damageObject = RangedDOSpawner.Instance.Spawn(weaponName, transform.position, bulletRotation);
            if (damageObject == null) return;
            damageObject.gameObject.SetActive(true);

            DamageSender damageReceiver = damageObject.GetComponentInChildren<DamageSender>();
            damageReceiver.isDameFromPlayer = true;
        }
    }
}
