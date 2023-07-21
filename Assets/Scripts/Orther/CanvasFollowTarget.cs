using UnityEngine;
using UnityEngine.UI;

public class CanvasFollowTarget : MonoBehaviour
{
    public Slider healthSlider;
    public Transform target;

    void Update()
    {
        Vector3 targetPosition = Camera.main.WorldToScreenPoint(target.position);
        healthSlider.transform.position = targetPosition;
    }
}
