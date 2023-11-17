using Pathfinding;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Seeker))]
public class ObjMoveToTarget : InitMonoBehaviour
{
    [SerializeField] protected Transform target;
    public Transform Target => target;

    [SerializeField] protected float speed = 2f;

    [SerializeField] protected float outline = 0.1f;

    [SerializeField] protected Animator animator;

    [SerializeField] protected Seeker seeker;

    [SerializeField] protected Rigidbody2D rb;

    protected float nextWayPointDistance;

    protected float repeatTimeUpdatePath;

    protected Coroutine moveCoroutine;

    protected Path path;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSeeker();
        this.LoadAnimator();
        this.LoadRb();
        this.LoadTarget();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        nextWayPointDistance = 0.5f;
        repeatTimeUpdatePath = 0.5f;
    }

    protected virtual void LoadTarget() { }

    protected virtual void LoadSeeker()
    {
        if (this.seeker != null) return;
        this.seeker = transform.GetComponent<Seeker>();
        Debug.Log(transform.name + ": LoadSeeker", gameObject);
    }

    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = transform.parent.Find("Visual").GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }

    protected virtual void LoadRb()
    {
        if (this.rb != null) return;
        this.rb = GetComponentInParent<Rigidbody2D>();
        Debug.Log(transform.name + ": LoadRb", gameObject);
    }

    protected override void OnEnable() => InvokeRepeating("CalculatePath", 0f, repeatTimeUpdatePath);

    protected override void OnDisable() => CancelInvoke("CalculatePath");

    protected virtual void CalculatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathCompleted);
    }

    protected virtual void OnPathCompleted(Path p)
    {
        if (!p.error)
        {
            path = p;
            MoveToTarget();
        }
    }

    protected virtual void MoveToTarget()
    {
        if (moveCoroutine != null) StopCoroutine(moveCoroutine);
        moveCoroutine = StartCoroutine(MoveToTargetCoroutine());
    }

    protected virtual IEnumerator MoveToTargetCoroutine()
    {
        int currentWP = 0;

        while (currentWP < path.vectorPath.Count)
        {
            if (Vector3.Distance(transform.position, target.position) >= outline)
            {

                Vector2 direction = ((Vector2)path.vectorPath[currentWP] - rb.position).normalized;
                Vector2 force = direction * speed * Time.deltaTime;
                SetAnimator(direction);
                transform.parent.position += (Vector3)force;
                float distance = Vector2.Distance(rb.position, path.vectorPath[currentWP]);
                if (distance < nextWayPointDistance) currentWP++;

            }
            else
                animator.SetBool("isWalking", false);
            yield return null;

        }
    }

    protected virtual void SetAnimator(Vector2 direction)
    {
        animator.SetFloat("X", -direction.x);
        animator.SetFloat("Y", -direction.y);
        animator.SetBool("isWalking", true);
    }

    public void SetSpeed(float speed) => this.speed = speed;

    public void SetOutline(float outline) => this.outline = outline;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, outline);
    }
}
