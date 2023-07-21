using System.Collections;
using UnityEngine;

public class MeleeMovement : MonoBehaviour
{
    public float rotationAngle = 90f; // Góc quay
    public float rotationTime = 5f; // Thời gian quay (giây)

    private void OnEnable() => StartCoroutine(RotateAndDestroyObject());


    private IEnumerator RotateAndDestroyObject()
    {
        float elapsedTime = 0f;
        Quaternion startRotation = transform.parent.rotation * Quaternion.Euler(0f, 0f, rotationAngle / 2);
        Quaternion targetRotation = transform.parent.rotation * Quaternion.Euler(0f, 0f, -rotationAngle / 2);

        while (elapsedTime < rotationTime)
        {
            float t = elapsedTime / rotationTime;
            transform.parent.rotation = Quaternion.Slerp(startRotation, targetRotation, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Khi hoàn thành quay, hủy đối tượng
        //Destroy(transform.parent.gameObject);
    }
}
