using UnityEngine;

public class PlayerActtack : PlayerAbstract
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Quaternion bulletRotation = Quaternion.LookRotation(Vector3.forward, new Vector2(playerCtrl.Animator.GetFloat("X"), playerCtrl.Animator.GetFloat("Y")));
            Transform damageSender = DOSpawner.Instance.Spawn("Darts", transform.position, bulletRotation);
            if (damageSender == null) return;
            damageSender.gameObject.SetActive(true);
        }
    }
}
