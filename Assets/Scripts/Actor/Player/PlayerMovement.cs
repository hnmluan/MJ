using UnityEngine;

public class PlayerMovement : PlayerAbstract
{
    [SerializeField] protected float speed = 8;

    [SerializeField] public Vector2 direction;

    [Header("Movement SFX")]
    [Space(10)]

    [SerializeField] protected float sfxTimer = 0f;

    [SerializeField] protected float sfxInterval = 0.2f;

    private void Update()
    {
        if (GameManager.Instance.State != GameState.FreeRoam) return;

        GetDirection();

        SetAnimation();

        if (direction != Vector2.zero)
        {
            Move();
            //PlayWalkSFX();  
        };
    }

    private void GetDirection()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (direction.x != 0) direction.y = 0;
    }

    private void Move() => playerCtrl.Rb.MovePosition(playerCtrl.Rb.position + direction * speed * Time.fixedDeltaTime);

    private void PlayWalkSFX()
    {
        sfxTimer += Time.deltaTime;

        if (sfxTimer >= sfxInterval)
        {
            AudioController.Instance.PlayVFX("sfx_walk");

            sfxTimer = 0f;
        }
    }

    private void SetAnimation()
    {
        if (direction.x != 0 || direction.y != 0)
        {
            playerCtrl.Animator.SetFloat("X", direction.x);

            playerCtrl.Animator.SetFloat("Y", direction.y);

            playerCtrl.Animator.SetBool("isWalking", true);
        }
        else
            playerCtrl.Animator.SetBool("isWalking", false);
    }

    public void MoveToPoint(Vector3 loadToPositionOnSence) => gameObject.transform.parent.position = loadToPositionOnSence;
}
