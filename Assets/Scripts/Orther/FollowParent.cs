using UnityEngine;

public class FollowParent : InitMonoBehaviour
{
    [SerializeField] private Transform parent;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadParent();
    }

    private void LoadParent()
    {
        if (this.parent != null) return;
        parent = this.transform.parent;
        Debug.Log(transform.name + ": LoadParent", gameObject);
    }

    private void Update()
    {
        if (parent == null) return;
        transform.position = parent.position;
    }
}


