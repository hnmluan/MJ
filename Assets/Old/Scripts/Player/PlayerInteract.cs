using UnityEngine;

public class PlayerInteract : InitMonoBehaviour
{
    [SerializeField] protected LayerMask interactablesLayer;

    [SerializeField] protected PlayerCtrl playerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
        this.LoadInteractablesLayer();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = transform.parent.GetComponent<PlayerCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", gameObject);
    }

    protected virtual void LoadInteractablesLayer()
    {
        if (this.interactablesLayer != 0) return;
        this.interactablesLayer = LayerMask.GetMask("Interactable");
        Debug.Log(transform.name + ": LoadSolidObjectLayer", gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Z)) Interact();
    }

    public void Interact()
    {
        Vector3 facingDir = new Vector3(playerCtrl.Animator.GetFloat("X"), playerCtrl.Animator.GetFloat("Y"));

        Vector3 interactPosition = transform.position + facingDir;

        Debug.DrawLine(transform.position, interactPosition, Color.red);

        //Debug.Log("Npc");
        //Debug.Log(facingDir);
        //Debug.Log(interactPosition);

        var collider = Physics2D.OverlapCircle(interactPosition, 0.2f, interactablesLayer);
        Debug.Log(collider);


        if (collider != null) collider.GetComponent<IInteractable>()?.Interact();
    }
}
