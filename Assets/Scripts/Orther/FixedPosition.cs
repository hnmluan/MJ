using UnityEngine;

public class FixedPosition : MonoBehaviour
{
    [SerializeField]
    private Vector3 initPosition;

    private void Awake()
    {
        initPosition = transform.position;
        transform.position = initPosition;
    }

    private void LateUpdate()
    {
        transform.position = initPosition;
    }
}
