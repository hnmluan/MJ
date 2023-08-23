using System.Collections;
using UnityEngine;

public abstract class ObjFloat : InitMonoBehaviour
{
    public float floatSpeed = 0.5f; // Tốc độ lơ lững
    public float floatHeight = 0.5f; // Độ cao lơ lững

    private Vector3 startPos;

    public Transform obj;

    protected abstract void SetObj();

    protected override void Awake() => SetObj();

    protected override void OnEnable()
    {
        startPos = transform.position;
        StartCoroutine(Float());
    }

    private IEnumerator Float()
    {
        while (true)
        {
            Vector3 targetPosition = startPos + new Vector3(0f, floatHeight * Mathf.Sin(Time.time * floatSpeed), 0f);
            obj.transform.position = targetPosition;

            yield return null;
        }
    }

}
