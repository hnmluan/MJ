using UnityEngine;

public class PlayerActtack : PlayerAbstract
{
    public Quaternion test;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Quaternion bulletRotation = Quaternion.LookRotation(Vector3.forward, new Vector2(playerCtrl.Animator.GetFloat("X"), playerCtrl.Animator.GetFloat("Y")));
            Transform damageSender = DamgeSenderSpawner.Instance.Spawn("Darts", transform.position, bulletRotation);
            if (damageSender == null) return;
            damageSender.gameObject.SetActive(true);
        }
    }
}
