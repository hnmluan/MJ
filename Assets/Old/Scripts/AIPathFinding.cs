using Pathfinding;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Seeker))]
public class AIPathFinding : InitMonoBehaviour
{
    [SerializeField] protected Seeker seeker;

    [SerializeField] protected Transform target;

    [SerializeField] protected float speed = 5f;

    [SerializeField] protected float distanceToNextPoint = 0.3f;

    [SerializeField] private Path path;

    [SerializeField] private Coroutine moveCoroutine;

    [SerializeField] protected EnemyCtrl enemyCtrl;

    protected override void Start()
    {
        InvokeRepeating("CalculatePath", 0f, 0.5f);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSeeker();
        //this.LoadTagret();
        this.LoadEnemyCtrl();
    }

    protected virtual void LoadSeeker()
    {
        if (this.seeker != null) return;
        this.seeker = transform.GetComponent<Seeker>();
        Debug.Log(transform.name + ": LoadSeeker", gameObject);
    }

    //protected virtual void LoadTagret()
    //{
    //    if (this.target != null) return;
    //    this.target = FindObjectOfType<PlayerCtrl>().gameObject.transform;
    //    Debug.Log(transform.name + ": LoadTagret", gameObject);
    //}

    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }

    void CalculatePath()
    {
        if (seeker.IsDone())

            seeker.StartPath(transform.parent.position, target.position, OnPathCallBack);
    }

    void OnPathCallBack(Path p)
    {
        if (p.error) return;

        path = p;

        MoveToTarget();
    }

    void MoveToTarget()
    {
        if (gameObject.activeSelf)
        {
            if (moveCoroutine != null) StopCoroutine(moveCoroutine);

            moveCoroutine = StartCoroutine(MoveToTargetCoroutine());
        }
        else

            StopAllCoroutines();
    }

    IEnumerator MoveToTargetCoroutine()
    {
        int currenPoint = 0;

        while (currenPoint < path.vectorPath.Count)
        {
            Vector2 direction = ((Vector2)path.vectorPath[currenPoint] - (Vector2)transform.parent.position).normalized;

            Vector3 force = direction * speed * Time.deltaTime;

            if (path.vectorPath.Count > 2) transform.parent.position += force;

            float distance = Vector2.Distance(transform.parent.position, path.vectorPath[currenPoint]);

            if (distance < distanceToNextPoint) currenPoint++;

            if (direction.x != 0)

                if (direction.x < 0)

                    enemyCtrl.EnemySprite.transform.localScale = new Vector3(-1, 1, 0);

                else

                    enemyCtrl.EnemySprite.transform.localScale = new Vector3(1, 1, 0);

            yield return null;
        }
    }
}
