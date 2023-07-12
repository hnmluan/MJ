using System.Collections.Generic;
using UnityEngine;

public class AutoMovement : InitMonoBehaviour
{
    public List<Transform> targets;

    public float movementSpeed = 5f;

    private int currentTargetIndex;

    private Transform currentTarget;

    private Transform t;

    protected override void Start()
    {
        currentTargetIndex = Random.Range(0, targets.Count);
        currentTarget = targets[currentTargetIndex];
    }

    protected override void LoadComponents()
    {
        this.LoadTagret();
        t = transform.Find("Targets");
    }

    protected virtual void LoadTagret()
    {
        if (this.targets.Count != 0) return;
        for (int i = 0; i < transform.Find("Targets").childCount; i++)
            targets.Add(transform.Find("Targets").GetChild(i));
        Debug.Log(transform.name + ": LoadTagrets", gameObject);
    }

    private void Update()
    {
        if (targets == null) return;

        Vector3 direction = (currentTarget.position - transform.position).normalized;

        Vector3 targetScale = direction.x >= 0 ? Vector3.one : new Vector3(-1f, 1f, 1f);
        transform.parent.localScale = targetScale;

        transform.parent.position += direction * movementSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, currentTarget.position) < 0.1f)
        {
            currentTargetIndex = Random.Range(0, targets.Count);
            currentTarget = targets[currentTargetIndex];
        }
    }
}
