using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class PlayerConverse : PlayerAbstract
{
    public float detectionConversableRange = 2f;

    [SerializeField] protected LayerMask converseLayer;

    [SerializeField] protected CircleCollider2D collider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadConverseLayer();
        this.LoadCircleCollider2D();
    }

    protected virtual void LoadConverseLayer()
    {
        if (this.converseLayer != 0) return;
        this.converseLayer = LayerMask.GetMask("Converse");
        Debug.Log(transform.name + ": LoadConverseLayer", gameObject);
    }

    protected virtual void LoadCircleCollider2D()
    {
        if (this.collider != null) return;
        this.collider = transform.GetComponent<CircleCollider2D>();
        collider.radius = detectionConversableRange;
        collider.isTrigger = true;
        Debug.Log(transform.name + ": LoadCircleCollider2D", gameObject);
    }

    private void Update()
    {
        // if (Input.GetKeyUp(KeyCode.C)) Converse();
    }

    /*public void Converse()
      {
          Vector3 facingDirection = new Vector3(playerCtrl.Animator.GetFloat("X"), playerCtrl.Animator.GetFloat("Y"));

          Vector3 conversePosition = transform.position + facingDirection;

          Debug.DrawLine(transform.position, conversePosition, Color.red);

          Collider2D collider = Physics2D.OverlapCircle(conversePosition, 0.2f, converseLayer);

          Debug.Log(collider);

          if (collider != null && !(GameManager.Instance.State == GameState.Dialog)) collider.GetComponent<IInteractable>()?.Interact();
      }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IInteractable converse = collision.GetComponent<IInteractable>();
        if (converse == null) return;
        if ((GameManager.Instance.State == GameState.Dialog)) return;
        if (Input.GetKeyUp(KeyCode.C)) converse.Interact();
    }
}