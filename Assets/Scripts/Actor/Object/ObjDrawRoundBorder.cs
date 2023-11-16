using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ObjDrawRoundBorder : MonoBehaviour
{
    public float circleRadius = 2f;

    void Update() => DrawCircleAroundObject();

    void DrawCircleAroundObject()
    {
        Vector3 objectPosition = transform.position;
        objectPosition.y = 0f;


        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 100;

        float deltaTheta = (2f * Mathf.PI) / lineRenderer.positionCount;
        float theta = 0f;

        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            float x = objectPosition.x + circleRadius * Mathf.Cos(theta);
            float z = objectPosition.z + circleRadius * Mathf.Sin(theta);

            lineRenderer.SetPosition(i, new Vector3(x, objectPosition.y, z));

            theta += deltaTheta;
        }
    }
}
