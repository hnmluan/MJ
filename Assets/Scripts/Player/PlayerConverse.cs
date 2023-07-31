using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class PlayerConverse : PlayerAbstract
{
    [SerializeField] protected float detectionConversableRange = 2f;

    [SerializeField] protected CircleCollider2D trigger;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCircleCollider2D();
    }

    protected virtual void LoadCircleCollider2D()
    {
        if (this.trigger != null) return;
        this.trigger = transform.GetComponent<CircleCollider2D>();
        trigger.radius = detectionConversableRange;
        trigger.isTrigger = true;
        Debug.Log(transform.name + ": LoadCircleCollider2D", gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        IInteractable converse = collision.GetComponent<IInteractable>();
        if (converse == null) return;
        if ((GameManager.Instance.State == GameState.Dialog)) return;
        if (Input.GetKey(KeyCode.Z)) converse.Interact();
        converse.ToggleCommunicativeSign(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IInteractable converse = collision.GetComponent<IInteractable>();
        if (converse == null) return;
        converse.ToggleCommunicativeSign(false);
    }
}