using Pathfinding;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Seeker))]
public class ObjMoveFree : InitMonoBehaviour
{
    [SerializeField] protected Seeker seeker;

    [SerializeField] protected Collider2D motionArea;

    [SerializeField] protected Animator animator;

    protected float speed = 2;

    protected bool isMoving;

    protected Path currentPath;

    protected int currentWaypointIndex;

    protected Vector3 target;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSeeker();
        this.LoadMovementArea();
        this.LoadAnimator();
    }

    protected virtual void LoadMovementArea()
    {
        if (this.motionArea != null) return;
        this.motionArea = transform.GetComponentInChildren<Collider2D>();
        if (transform.GetComponentInChildren<FixedPosition>() == null) motionArea.AddComponent<FixedPosition>();
        motionArea.isTrigger = true;
        Debug.Log(transform.name + ": LoadMovementArea", gameObject);
    }

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

    protected override void OnEnable()
    {
        base.OnEnable();
        isMoving = false;
        StartCoroutine(MoveTo());
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        StopAllCoroutines();
    }

    protected virtual void SetAnimation(Vector3 direction)
    {
        animator.SetFloat("X", direction.x);
        animator.SetFloat("Y", direction.y);
        animator.SetBool("isWalking", this.isMoving);
    }

    protected virtual IEnumerator MoveTo()
    {
        while (true)
        {
            GetTarget();
            MoveTo(target);

            yield return new WaitUntil(() => !isMoving);
            yield return new WaitForSeconds(2f);
        }
    }

    protected virtual void GetTarget()
    {
        Vector3 center = motionArea.bounds.center;
        Vector3 size = motionArea.bounds.size;

        target = center + new Vector3(
           (Random.value - 0.55f) * size.x,
           (Random.value - 0.55f) * size.y,
           (Random.value - 0.55f) * size.z
       );

    }

    protected virtual void MoveTo(Vector3 target)
    {
        seeker.StartPath(transform.position, target, OnPathComplete);
        isMoving = true;
    }

    protected virtual void OnPathComplete(Path path)
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

    public void SetSpeed(float speed) => this.speed = speed;

    protected virtual void Update()
    {
        if (isMoving && currentPath != null)
        {
            if (currentWaypointIndex >= currentPath.vectorPath.Count)
            {
                isMoving = false;
                animator.SetBool("isWalking", this.isMoving);
                return;
            }

            Vector3 targetPosition = currentPath.vectorPath[currentWaypointIndex];

            Vector3 direction = (targetPosition - transform.position).normalized;

            SetAnimation(direction);

            transform.parent.position += direction * speed * Time.deltaTime;

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f) currentWaypointIndex++;
        }
    }
}
