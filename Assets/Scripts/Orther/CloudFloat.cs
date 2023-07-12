using UnityEngine;

public class CloudFloat : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float speed;
    public float amplitude;
    public float frequency;
    public AnimationCurve fadeCurve;
    public float waitTimeToStart = 2f; // Thời gian đợi trước khi bắt đầu di chuyển (giây)

    private float timeOffset;
    private float distanceTraveled;
    private bool isWaitingTimeToStart;

    private Renderer cloud;

    private void Start()
    {
        transform.parent.position = startPoint.position;
        distanceTraveled = 0f;
        isWaitingTimeToStart = true;
        StartCoroutine(WaitAndStartMoving());
        cloud = transform.parent.GetComponentInChildren<Renderer>();
    }

    private void Update()
    {
        if (isWaitingTimeToStart)
        {
            cloud.enabled = false;
            return;
        }

        cloud.enabled = true;
        Move();
        ApplyOscillation();
        UpdateFade();
        CheckArrival();
    }

    private void Move()
    {
        Vector3 direction = (endPoint.position - startPoint.position).normalized;
        transform.parent.position += direction * speed * Time.deltaTime;
        distanceTraveled += speed * Time.deltaTime;
    }

    private void ApplyOscillation()
    {
        timeOffset += Time.deltaTime * frequency;
        Vector3 oscillation = Mathf.Sin(timeOffset) * amplitude * transform.right;
        transform.parent.position += oscillation;
    }

    private void UpdateFade()
    {
        float t = distanceTraveled / Vector3.Distance(startPoint.position, endPoint.position);
        float fadeValue = fadeCurve.Evaluate(t);
        Color currentColor = cloud.material.color;
        Color fadedColor = new Color(currentColor.r, currentColor.g, currentColor.b, fadeValue);
        cloud.material.color = fadedColor;
    }

    private void CheckArrival()
    {
        if (distanceTraveled >= Vector3.Distance(startPoint.position, endPoint.position))
        {
            transform.parent.position = startPoint.position;
            distanceTraveled = 0f;
        }
    }

    private System.Collections.IEnumerator WaitAndStartMoving()
    {
        yield return new WaitForSeconds(waitTimeToStart);
        isWaitingTimeToStart = false;
    }
}
