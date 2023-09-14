using Pathfinding;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Seeker))]
public class EnemyAI : InitMonoBehaviour
{
    public Transform target;

    public float moveSpeed = 2f;

    public float repeatTimeUpdatePath = 0.5f;

    public Animator animator;

    public float rangeToFollow = Mathf.Infinity;

    public float offsetTagert;

    public Seeker seeker;

    private Path path;

    private bool allowMoving;

    private float nextWayPointDistance = 0.2f;

    private Coroutine moveCoroutine;

    protected override void Start() => InvokeRepeating("CalculatePath", 0f, repeatTimeUpdatePath);

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
        this.LoadSeeker();
    }

    private void LoadSeeker()
    {
        if (seeker != null) return;
        seeker = GetComponent<Seeker>();
        Debug.Log(transform.name + ": LoadSeeker", gameObject);
    }

    private void LoadAnimator()
    {
        if (animator != null) return;
        animator = transform.parent.Find("Visual").GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
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
            MoveToTarget();
        }
    }

    void MoveToTarget()
    {
        if (moveCoroutine != null) StopCoroutine(moveCoroutine);
        moveCoroutine = StartCoroutine(MoveToTargetCoroutine());
    }

    private void SetAnimation()
    {
        animator.SetFloat("X", (transform.position - target.position).normalized.x);
        animator.SetFloat("Y", (transform.position - target.position).normalized.y);
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
        SetAnimation();
        float distance = Vector3.Distance(transform.position, target.position);
        allowMoving = distance < rangeToFollow && distance > offsetTagert;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangeToFollow);
        Gizmos.DrawWireSphere(transform.position, offsetTagert);
    }
}