using Pathfinding;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Seeker))]
public class MoveFree : InitMonoBehaviour
{
    [SerializeField] protected Collider2D movementArea;
    [SerializeField] protected Seeker seeker;
    [SerializeField] protected Path currentPath;
    [SerializeField] protected int currentWaypointIndex;
    [SerializeField] protected bool isMoving;
    [SerializeField] protected Vector3 moveDirection;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSeeker();
        this.LoadMovementArea();
    }

    private void LoadMovementArea()
    {
        if (this.movementArea != null) return;
        this.movementArea = transform.GetComponentInChildren<Collider2D>();
        Debug.Log(transform.name + ": LoadMovementArea", gameObject);
    }

    protected virtual void LoadSeeker()
    {
        if (this.seeker != null) return;
        this.seeker = transform.GetComponent<Seeker>();
        Debug.Log(transform.name + ": LoadSeeker", gameObject);
    }

    protected override void Start()
    {
        seeker = GetComponent<Seeker>();
        isMoving = false;

        StartCoroutine(MoveToRandomPointRoutine());
    }

    private IEnumerator MoveToRandomPointRoutine()
    {
        while (true)
        {
            Vector3 randomPoint = GetRandomPointInCollider(movementArea);
            MoveTo(randomPoint);

            yield return new WaitUntil(() => !isMoving);
            yield return new WaitForSeconds(2f);
        }
    }

    private Vector3 GetRandomPointInCollider(Collider2D collider)
    {
        Vector3 center = collider.bounds.center;
        Vector3 size = collider.bounds.size;

        Vector3 randomPoint = center + new Vector3(
            (Random.value - 0.5f) * size.x,
            (Random.value - 0.5f) * size.y,
            (Random.value - 0.5f) * size.z
        );

        return randomPoint;
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
            if (currentWaypointIndex >= currentPath.vectorPath.Count)
            {
                isMoving = false;
                return;
            }

            Vector3 targetPosition = currentPath.vectorPath[currentWaypointIndex];

            moveDirection = (targetPosition - transform.position).normalized;

            float moveSpeed = 5f * Time.deltaTime;

            transform.parent.position += moveDirection * moveSpeed;

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                currentWaypointIndex++;
            }
        }
    }
}