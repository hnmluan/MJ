using UnityEngine;
using UnityEngine.UI;

public class SliderSFX : BaseSlider
{
    [SerializeField] protected Toggle toggle;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadToggle();
    }

    protected virtual void LoadToggle()
    {
        if (this.toggle != null) return;
        this.toggle = transform.parent.Find("Toggle").GetComponent<Toggle>();
        Debug.LogWarning(transform.name + ": LoadToggle", gameObject);
    }

    protected override void OnChanged(float newValue)
    {
        if (newValue == 0) toggle.isOn = true;
        if (newValue > 0) toggle.isOn = false;
        AudioManager.Instance.SFXVolume = newValue;
    }
}
