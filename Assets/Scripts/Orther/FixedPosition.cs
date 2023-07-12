using UnityEngine;

public class FixedPosition : InitMonoBehaviour
{
    [SerializeField] private Vector3 initPosition;

    protected override void Start() => initPosition = transform.position;

    protected override void Reset() => initPosition = transform.position;

    private void LateUpdate() => transform.position = initPosition;
}
