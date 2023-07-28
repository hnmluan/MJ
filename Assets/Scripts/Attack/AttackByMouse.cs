using UnityEngine;

public class AttackByMouse : Attack2
{
    protected override Quaternion GetRotation() => GetQuaternionToMouse();

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

    protected override bool IsAttacking()
    {
        this.isAttacking = Input.GetAxis("Fire1") == 1;
        return this.isAttacking;
    }
}
