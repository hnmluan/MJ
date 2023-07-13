using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : NPCAbstract
{
    public float standingTime = 2f; // Thời gian đứng yên sau khi đến một điểm

    public List<Transform> movePoints; // Danh sách các điểm cần di chuyển đến

    [SerializeField] private int currentPointIndex = 0; // Chỉ số của điểm hiện tại trong danh sách

    [SerializeField] private bool isMoving = true; // Trạng thái di chuyển của nhân vật

    public float moveSpeed = 5f; // Tốc độ di chuyển

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMovePoints();
    }

    private void LoadMovePoints()
    {
        if (movePoints.Count != 0) return;
        movePoints = new List<Transform>(transform.GetComponentsInChildren<Transform>());
        Debug.Log(transform.name + ": LoadMovePoints", gameObject);
    }

    protected override void Start()
    {
        base.Start();

        if (movePoints.Count == 0) return;

        transform.parent.position = movePoints[0].position;
        StartCoroutine(MoveToNextPoint());
    }

    private IEnumerator MoveToNextPoint()
    {
        while (true)
        {
            if (isMoving)
            {
                if (currentPointIndex >= movePoints.Count)
                {
                    // Nếu đã di chuyển hết danh sách, quay lại điểm đầu tiên
                    currentPointIndex = 0;
                }

                Vector3 targetPosition = movePoints[currentPointIndex].position;
                float distance = Vector3.Distance(transform.position, targetPosition);

                while (distance > 0.01f)
                {
                    MoveTowardsTarget(targetPosition);
                    distance = Vector3.Distance(transform.position, targetPosition);
                    yield return null;
                }

                // Đạt đến điểm tiếp theo, chuyển sang trạng thái đứng yên
                SetMovingState(false);
                yield return new WaitForSeconds(standingTime);
                SetMovingState(true);

                currentPointIndex++;
            }

            yield return null;
        }
    }

    private void MoveTowardsTarget(Vector3 targetPosition)
    {
        Vector3 currentPosition = transform.position;
        Vector3 moveDirection = targetPosition - currentPosition;
        moveDirection.Normalize();
        transform.parent.position += moveDirection * moveSpeed * Time.deltaTime;

        SetAnimation(moveDirection);
    }

    private void SetAnimation(Vector3 moveDirection)
    {
        if (npcCtrl.Animator == null) return;

        if (moveDirection.x != 0 || moveDirection.y != 0)
        {
            npcCtrl.Animator.SetFloat("X", moveDirection.x);
            npcCtrl.Animator.SetFloat("Y", moveDirection.y);
        }
    }

    public void SetMovingState(bool isMoving)
    {
        this.isMoving = isMoving;
        npcCtrl.Animator.SetBool("isWalking", isMoving);
    }
}
