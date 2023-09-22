using System.Collections;
using UnityEngine;

public class PlayerMovement : PlayerAbstract
{
    [Header("Top-Down movement")]

    [SerializeField] protected float speed = 8;

    [SerializeField] public Vector2 direction;

    [Header("Dash movement")]

    public float dashBoost = 20f;

    [SerializeField] protected float _dashTime;

    public float dashTime = 0.2f;

    [SerializeField] protected bool isDashing = false;

    [SerializeField] protected float ghostDelaySeconds;

    [SerializeField] protected Coroutine dashEffectCoroutine;

    [Header("Sound movement")]

    [SerializeField] protected float sfxTimer = 0f;

    [SerializeField] protected float sfxInterval = 0.2f;

    private void Update()
    {
        //if (GameManager.Instance.State != GameState.FreeRoam) return;

        GetDirection();

        SetAnimation();

        if (direction != Vector2.zero)
        {
            Move();
            //PlayWalkSFX();
        };

        if (Input.GetKey(KeyCode.Space) && isDashing == false && _dashTime <= 0)
        {
            speed += dashBoost;
            _dashTime = dashTime;
            isDashing = true;
            //StartDashEffect();
        }

        if (_dashTime <= 0 && isDashing == true)
        {
            speed -= dashBoost;
            isDashing = false;
            //StopDashEffect();
        }
        else
        {
            _dashTime -= Time.deltaTime;
        }
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
            AudioManager.Instance.Play("sfx_walk");

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

    private void StopDashEffect()
    {
        if (dashEffectCoroutine != null) StopCoroutine(dashEffectCoroutine);
    }

    private void StartDashEffect()
    {
        if (dashEffectCoroutine != null) StopCoroutine(dashEffectCoroutine);
        dashEffectCoroutine = StartCoroutine(DashEffectCoroutine());
    }

    IEnumerator DashEffectCoroutine()
    {
        while (true)
        {
            Transform ghost = FXSpawner.Instance.Spawn("PlayerGhost", playerCtrl.PlayerSprite.transform.position, Quaternion.identity);
            ghost.GetComponentInChildren<SpriteRenderer>().sprite = playerCtrl.PlayerSprite.sprite;
            ghost.gameObject.SetActive(true);

            yield return new WaitForSeconds(ghostDelaySeconds);
        }
    }
}
