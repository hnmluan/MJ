using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : InitMonoBehaviour
{
    [SerializeField] protected float speed = 8;

    [SerializeField] protected Vector2 direction;

    [SerializeField] protected float sfxTimer = 0f;

    [SerializeField] protected float sfxDeplay = 0.2f;

    [SerializeField] protected PlayerCtrl playerCtrl;

    [SerializeField] protected Rigidbody2D rb;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayerCtrl();
        LoadRigidbody2D();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (playerCtrl != null) return;
        playerCtrl = transform.parent.GetComponent<PlayerCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", gameObject);
    }

    protected virtual void LoadRigidbody2D()
    {
        if (rb != null) return;
        rb = transform.parent.GetComponent<Rigidbody2D>();
        Debug.Log(transform.name + ": LoadRigidbody2D", gameObject);
    }

    private void Update()
    {
        SetAnimation();

        if (direction != Vector2.zero)
        {
            Move();

            sfxTimer += Time.deltaTime;
            if (sfxTimer >= sfxDeplay)
            {
                SoundController.Instance.PlayVFX("sfx_walk");
                sfxTimer = 0f;
            }
        }

    }

    private void OnMovement(InputValue value)
    {
        direction = value.Get<Vector2>();
        if (direction.x != 0) direction.y = 0;
    }

    private void Move()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
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
        {
            playerCtrl.Animator.SetBool("isWalking", false);
        }
    }
}
