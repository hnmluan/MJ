using Pathfinding;
using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform target;

    public float moveSpeed = 2f;
    public float nextWayPointDistance = 2f;
    public float repeatTimeUpdatePath = 0.5f;
    public Animator animator;
    public bool allowMoving;
    public float range;

    Path path;
    public Seeker seeker;

    Coroutine moveCoroutine;

    private void Start()
    {
        seeker = GetComponent<Seeker>();

        InvokeRepeating("CalculatePath", 0f, repeatTimeUpdatePath);
    }

    void CalculatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(transform.position, target.position, OnPathCompleted);
    }

    void OnPathCompleted(Path p)
    {
        if (!p.error)
        {
            path = p;
            if (allowMoving) MoveToTarget();
        }
    }

    void MoveToTarget()
    {
        if (moveCoroutine != null) StopCoroutine(moveCoroutine);
        moveCoroutine = StartCoroutine(MoveToTargetCoroutine());
    }

    private void SetAnimation()
    {
        animator.SetFloat("X", (transform.position - target.position).x);
        animator.SetFloat("Y", (transform.position - target.position).y);
        animator.SetBool("isWalking", this.allowMoving);
    }

    IEnumerator MoveToTargetCoroutine()
    {
        int currentWP = 0;

        while (currentWP < path.vectorPath.Count && allowMoving)
        {
            Vector2 direction = ((Vector2)path.vectorPath[currentWP] - (Vector2)transform.position).normalized;
            Vector2 force = direction * moveSpeed * Time.deltaTime;
            transform.parent.position += (Vector3)force;

            float distance = Vector2.Distance(transform.position, path.vectorPath[currentWP]);
            if (distance < nextWayPointDistance)
                currentWP++;

            yield return null;
        }
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        allowMoving = distance < range;
        if (allowMoving) SetAnimation();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}