using UnityEngine;

public abstract class ObjWithoutAttack : InitMonoBehaviour, IObjAttackObserver
{
    [Header("Without ObjAttack")]
    [SerializeField] protected ObjAttack attack;

    [SerializeField] protected Vector2 direction;

    [SerializeField] protected Transform left;

    [SerializeField] protected Transform right;

    [SerializeField] protected Transform up;

    [SerializeField] protected Transform down;

    [SerializeField] protected SpriteRenderer InHandSR;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLeft();
        this.LoadRight();
        this.LoadUp();
        this.LoadDown();
    }

    protected override void ResetValue()
    {
        SetObjAttack();
        SetDirection();
        this.LoadInHandSR();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.RegisterAttackEvent();
    }

    private void LoadDown()
    {
        if (this.down != null) return;
        down = transform.Find("Down");
        Debug.Log(transform.name + ": LoadDown " + gameObject);
    }

    private void LoadUp()
    {
        if (this.up != null) return;
        up = transform.Find("Up");
        Debug.Log(transform.name + ": LoadUp " + gameObject);
    }

    private void LoadRight()
    {
        if (this.right != null) return;
        right = transform.Find("Right");
        Debug.Log(transform.name + ": LoadRight " + gameObject);
    }

    private void LoadLeft()
    {
        if (this.left != null) return;
        left = transform.Find("Left");
        Debug.Log(transform.name + ": LoadLeft " + gameObject);
    }

    protected void LoadInHandSR()
    {
        if (this.attack == null) return;
        if (this.InHandSR != null) return;
        InHandSR = transform.GetComponentInChildren<SpriteRenderer>();
        InHandSR.sprite = attack.GetDamageObjectSO().spriteInHand;
        Debug.Log(transform.name + ": LoadInHandSR " + gameObject);
    }

    public Transform GetPosition()
    {
        if (direction.x == 1) return right;
        if (direction.x == -1) return left;
        if (direction.y == 1) return up;
        return down;
    }

    public void SetPosition()
    {
        SetDirection();
        InHandSR.transform.position = GetPosition().position;
        InHandSR.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        InHandSR.transform.localScale = new Vector3(1, 1, 1);
        if (direction.x == -1) InHandSR.transform.localScale = new Vector3(-1, 1, 1);
    }

    public abstract void SetObjAttack();

    public abstract void SetDirection();

    protected virtual void RegisterAttackEvent() => this.attack.AddObserver(this);

    public void OnAttacking() => InHandSR.enabled = false;

    public void OnWithoutAttack()
    {
        InHandSR.enabled = true;
        SetPosition();
    }
}
