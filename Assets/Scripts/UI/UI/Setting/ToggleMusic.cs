using UnityEngine;
using UnityEngine.UI;

public class ToggleMusic : BaseToggle
{
    [SerializeField] protected Slider m_slider;

    [SerializeField] private float oldVolumn = 1;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSlider();
    }

    protected virtual void LoadSlider()
    {
        if (this.m_slider != null) return;
        this.m_slider = transform.parent.Find("Slider").GetComponent<Slider>();
        Debug.LogWarning(transform.name + ": LoadSlider", gameObject);
    }

    protected override void OnChanged(bool option)
    {
        if (option)
        {
            oldVolumn = m_slider.value;
            m_slider.value = 0;
        }

        if (!option)
        {
            if (oldVolumn == 0) return;
            m_slider.value = oldVolumn;
        }
    }
}
