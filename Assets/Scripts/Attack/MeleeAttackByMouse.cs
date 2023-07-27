using UnityEngine;

public class MeleeAttackByMouse : MeleeAttack
{
    [SerializeField] float timer = 0;

    protected override bool CanAttack()
    {
        if (Input.GetButton("Fire1"))
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = GetTimeAttack();
                return true;
            }
        }
        return false;
    }

    protected override Quaternion GetQuatanion() => GetQuaternionToMouse();

    private Quaternion GetQuaternionToMouse()
    {
        float angle = Mathf.Atan2(GetDirectionToMouse().y, GetDirectionToMouse().x) * Mathf.Rad2Deg;
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }

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
}
