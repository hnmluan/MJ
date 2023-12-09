using UnityEngine;
using UnityEngine.UI;

public abstract class BaseButton : InitMonoBehaviour
{
    [Header("Base Button")]
    [SerializeField] protected Button button;

    protected override void Start()
    {
        base.Start();
        this.AddOnClickEvent();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadButton();
    }

    protected virtual void LoadButton()
    {
        if (this.button != null) return;
        this.button = GetComponent<Button>();
        Debug.Log(transform.name + ": LoadButton", gameObject);
    }

    protected virtual void AddOnClickEvent()
    {
        this.button.onClick.AddListener(this.OnClick);
        this.button.onClick.AddListener(this.SoundOnClick);
    }

    protected abstract void OnClick();

    protected virtual void SoundOnClick() => AudioManager.Instance.Play("sfx_button_press");
}