using UnityEngine;

public class FixedPosition : MonoBehaviour
{
    [SerializeField]
    private Vector3 initPosition;

    private void Start()
    {
        initPosition = transform.position;
    }

    private void LateUpdate()
    {
        transform.position = initPosition;
    }
}
