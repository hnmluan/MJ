using Pathfinding;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Seeker))]
public class MoveToTagert : InitMonoBehaviour
{
    [SerializeField] protected Transform target;

    [SerializeField] protected Seeker seeker;

    [SerializeField] protected Path currentPath;

    [SerializeField] protected int currentWaypointIndex;

    [SerializeField] protected bool isMoving;

    [SerializeField] protected float offsetTarget = 1;

    [SerializeField] protected Vector3 direction;

    [SerializeField] protected Vector3 targetPosition;

    [SerializeField] protected float offsetNodePath = 0.1f;

    [SerializeField] protected bool isTouchPlayer;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSeeker();
    }

    protected virtual void LoadSeeker()
    {
        if (this.seeker != null) return;
        this.seeker = transform.GetComponent<Seeker>();
        Debug.Log(transform.name + ": LoadSeeker", gameObject);
    }

    protected override void OnEnable()
    {
        isMoving = false;
        StartCoroutine(MoveToPlayerRoutine());
    }

    private IEnumerator MoveToPlayerRoutine()
    {
        while (true)
        {
            if (target != null) MoveTo(target.position);

            yield return new WaitUntil(() => !isMoving);
        }
    }

    private void MoveTo(Vector3 destination)
    {
        seeker.StartPath(transform.position, destination, OnPathComplete);
        isMoving = true;
    }

    private void OnPathComplete(Path path)
    {
        if (!path.error)
        {
            currentPath = path;
            currentWaypointIndex = 0;
            isMoving = true;
        }
        else
        {
            Debug.LogError("Pathfinding error: " + path.errorLog);
            isMoving = false;
        }
    }

    protected virtual void Update()
    {
        if (isMoving && currentPath != null)
        {
            if (currentWaypointIndex >= currentPath.vectorPath.Count || Vector3.Distance(transform.parent.position, target.transform.position) <= offsetTarget)
            {
                isTouchPlayer = true;

                isMoving = false;

                return;
            }

            targetPosition = currentPath.vectorPath[currentWaypointIndex];

            direction = (targetPosition - transform.parent.position).normalized;

            transform.parent.position += direction * 5f * Time.deltaTime;

            if (Vector3.Distance(transform.parent.position, targetPosition) < offsetNodePath)
            {
                currentWaypointIndex++;
            }
        }
    }
}
