using Pathfinding;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Seeker))]
public class ObjMoveToTagert : InitMonoBehaviour
{
    [SerializeField] protected Transform target;

    protected Seeker seeker;

    protected Path currentPath;

    protected int currentWaypointIndex;

    protected bool isMoving;

    protected bool isTouchTagret;

    [SerializeField] protected float offsetTarget = 1;

    protected Vector3 direction;

    protected Vector3 targetPosition;

    protected float offsetNodePath = 0.1f;

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
        StartCoroutine(MoveToTagretRoutine());
    }

    private IEnumerator MoveToTagretRoutine()
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
            if (currentWaypointIndex >= currentPath.vectorPath.Count || Vector3.Distance(transform.position, target.transform.position) <= offsetTarget)
            {
                isTouchTagret = true;
                isMoving = false;
                return;
            }

            Vector3 targetPosition = currentPath.vectorPath[currentWaypointIndex];

            direction = (targetPosition - transform.position).normalized;

            transform.parent.position += direction * 5f * Time.deltaTime;

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                currentWaypointIndex++;
            }
        }
    }
}
