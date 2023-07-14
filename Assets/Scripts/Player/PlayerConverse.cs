using UnityEngine;

public class PlayerConverse : PlayerAbstract
{
    [SerializeField] protected LayerMask converseLayer;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        //this.LoadConverseLayer();
    }

    //protected virtual void LoadConverseLayer()
    //{
    //    if (this.converseLayer != 0) return;
    //    this.converseLayer = LayerMask.GetMask("Converse");
    //    Debug.Log(transform.name + ": LoadConverseLayer", gameObject);
    //}

    //private void Update()
    //{
    //    if (Input.GetKeyUp(KeyCode.C)) Converse();
    //}

    //public void Converse()
    //{
    //    Vector3 facingDirection = new Vector3(playerCtrl.Animator.GetFloat("X"), playerCtrl.Animator.GetFloat("Y"));

    //    Vector3 conversePosition = transform.position + facingDirection;

    //    Debug.DrawLine(transform.position, conversePosition, Color.red);

    //    Collider2D collider = Physics2D.OverlapCircle(conversePosition, 0.2f, converseLayer);
    //    Debug.Log(collider);

    //    if (collider != null && !(GameController.Instance.State == GameState.Dialog)) collider.GetComponent<IInteractable>()?.Interact();
    //}
}
