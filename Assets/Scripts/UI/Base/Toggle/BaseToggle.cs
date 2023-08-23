
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseToggle : InitMonoBehaviour
{
    [Header("Base Toggle")]

    [SerializeField] protected Toggle toggle;

    protected override void Start()
    {
        base.Start();
        this.AddOnClickEvent();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadToggle();
    }

    protected virtual void LoadToggle()
    {
        if (this.toggle != null) return;
        this.toggle = GetComponent<Toggle>();
        Debug.LogWarning(transform.name + ": LoadToggle", gameObject);
    }

    protected virtual void AddOnClickEvent() => this.toggle.onValueChanged.AddListener(this.OnChanged);

    protected abstract void OnChanged(bool option);
}
