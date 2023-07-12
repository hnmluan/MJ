using UnityEngine;

public class CloudFloat : MonoBehaviour
{
    public Transform startPoint;

    public Transform endPoint;

    public float speed;

    private void Start()
    {
        transform.parent.position = startPoint.position;
    }

    private void Update()
    {
        Vector3 direction = (endPoint.position - startPoint.position).normalized;

        transform.parent.position += direction * speed * Time.deltaTime;

        if (Vector3.Distance(transform.parent.position, endPoint.position) < 0.1f)
        {
            transform.parent.position = startPoint.position;
        }
    }

}
