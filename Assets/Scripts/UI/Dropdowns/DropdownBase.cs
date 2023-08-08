using UnityEngine;
using UnityEngine.UI;

public abstract class BaseDropdown : InitMonoBehaviour
{
    [Header("Base Dropdown")]
    [SerializeField] protected Dropdown slider;

    protected override void Start()
    {
        base.Start();
        this.AddOnClickEvent();
    }

    protected virtual void FixedUpdate()
    {
        //For override
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDropdown();
    }

    protected virtual void LoadDropdown()
    {
        if (this.slider != null) return;
        this.slider = GetComponent<Dropdown>();
        Debug.LogWarning(transform.name + ": LoadDropdown", gameObject);
    }

    protected virtual void AddOnClickEvent() => this.slider.onValueChanged.AddListener(this.OnChanged);

    protected abstract void OnChanged(int option);
}