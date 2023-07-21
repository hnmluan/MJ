using Pathfinding;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Seeker))]
public class ChasePlayer : InitMonoBehaviour
{
    [SerializeField] protected GameObject player;
    [SerializeField] protected Seeker seeker;
    [SerializeField] protected Path currentPath;
    [SerializeField] protected int currentWaypointIndex;
    [SerializeField] protected bool isMoving;
    [SerializeField] protected float offsetPlayer = 1;
    [SerializeField] protected Vector3 direction;
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float offset = 0.1f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSeeker();
        this.LoadPlayer();
    }

    private void LoadPlayer()
    {
        if (this.player != null) return;
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(transform.name + ": LoadPlayer", gameObject);
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
            if (player != null) MoveTo(player.transform.position);

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
            if (currentWaypointIndex >= currentPath.vectorPath.Count || Vector3.Distance(transform.parent.position, player.transform.position) <= offsetPlayer)
            {
                isMoving = false;
                return;
            }

            targetPosition = currentPath.vectorPath[currentWaypointIndex];

            direction = (targetPosition - transform.parent.position).normalized;

            transform.parent.position += direction * 5f * Time.deltaTime;

            if (Vector3.Distance(transform.parent.position, targetPosition) < offset)
            {
                currentWaypointIndex++;
            }
        }
    }
}
