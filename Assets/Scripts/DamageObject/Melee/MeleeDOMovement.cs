using System.Collections;
using UnityEngine;

public class MeleeDOMovement : MonoBehaviour
{
    public float rotationAngle = 90f;
    public float timeMove = 0.5f;

    private void OnEnable() => StartCoroutine(RotateAndDestroyObject());

    private IEnumerator RotateAndDestroyObject()
    {
        float elapsedTime = 0f;
        Quaternion startRotation = transform.parent.rotation * Quaternion.Euler(0f, 0f, rotationAngle / 2);
        Quaternion targetRotation = transform.parent.rotation * Quaternion.Euler(0f, 0f, -rotationAngle / 2);

        while (elapsedTime < timeMove)
        {
            float t = elapsedTime / timeMove;
            transform.parent.rotation = Quaternion.Slerp(startRotation, targetRotation, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
