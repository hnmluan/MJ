using Pathfinding;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Seeker))]
public class ObjMoveToTagert : MonoBehaviour
{
    public Transform target;

    public float moveSpeed = 2f;
    public float nextWayPointDistance = 2f;
    public float repeatTimeUpdatePath = 0.1f;
    public SpriteRenderer characterSR;
    public Animator animator;

    Path path;
    public Seeker seeker;
    public Rigidbody2D rb;

    Coroutine moveCoroutine;

    private void Start() => InvokeRepeating("CalculatePath", 0f, repeatTimeUpdatePath);

    void CalculatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathCompleted);
    }

    void OnPathCompleted(Path p)
    {
        if (!p.error)
        {
            path = p;
            MoveToTarget();
        }
    }

    void MoveToTarget()
    {
        if (Vector3.Distance(transform.position, target.position) <= 4) return;
        if (moveCoroutine != null) StopCoroutine(moveCoroutine);
        moveCoroutine = StartCoroutine(MoveToTargetCoroutine());
    }

    IEnumerator MoveToTargetCoroutine()
    {
        int currentWP = 0;

        while (currentWP < path.vectorPath.Count)
        {
            Vector2 direction = ((Vector2)path.vectorPath[currentWP] - rb.position).normalized;
            Vector2 force = direction * moveSpeed * Time.deltaTime;
            transform.parent.position += (Vector3)force;

            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWP]);
            if (distance < nextWayPointDistance)
                currentWP++;

            if (force.x != 0)
                if (force.x < 0)
                    characterSR.transform.localScale = new Vector3(-1, 1, 0);
                else
                    characterSR.transform.localScale = new Vector3(1, 1, 0);

            yield return null;
        }
    }
}
