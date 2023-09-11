using System.Collections;
using UnityEngine;

public class DOSlash : DOMovement
{
    public float rotationSlash = 90f;

    bool isMove = true;

    protected override void OnEnable()
    {
        base.OnEnable();
        isMove = true;
    }

    protected override void Update()
    {
        base.Update();
        //transform.parent.position = damageObjectCtrl.Attacker.transform.position;
    }

    protected override void Move()
    {
        if (isMove) PlaySlash();
    }

    private void PlaySlash() => StartCoroutine(Slash());

    private IEnumerator Slash()
    {
        float elapsedTime = 0f;
        Quaternion startRotation = transform.parent.rotation * Quaternion.Euler(0f, 0f, rotationSlash / 2);
        Quaternion targetRotation = transform.parent.rotation * Quaternion.Euler(0f, 0f, -rotationSlash / 2);
        isMove = false;

        while (elapsedTime < timeMovement)
        {
            float t = elapsedTime / timeMovement;
            transform.parent.rotation = Quaternion.Slerp(startRotation, targetRotation, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
