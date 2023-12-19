using UnityEngine;

public class ObjAttackByMouse : ObjAttack
{
    protected override Quaternion GetRotation() => GetQuaternionToMouse();

    protected virtual Quaternion GetQuaternionToMouse()
    {
        float angle = Mathf.Atan2(GetDirectionToMouse().y, GetDirectionToMouse().x) * Mathf.Rad2Deg;
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }

    protected override void Start() => SetWeapon(Armory.Instance.GetFocusEquippedWeapon().weapon);

    protected virtual Vector3 GetDirectionToMouse()
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
