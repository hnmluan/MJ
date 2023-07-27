using System.Collections;
using UnityEngine;

public class DOSlash : DOMovement
{
    public float rotationAngle = 90f;
    bool isMove = true;

    protected override void OnEnable()
    {
        base.OnEnable();
        isMove = true;
    }

    protected override void Move()
    {
        if (isMove) PlaySlash();
    }

    private void PlaySlash() => StartCoroutine(Slash());

    private IEnumerator Slash()
    {
        float elapsedTime = 0f;
        Quaternion startRotation = transform.parent.rotation * Quaternion.Euler(0f, 0f, rotationAngle / 2);
        Quaternion targetRotation = transform.parent.rotation * Quaternion.Euler(0f, 0f, -rotationAngle / 2);
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
