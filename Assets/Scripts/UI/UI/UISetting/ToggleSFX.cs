using UnityEngine;
using UnityEngine.UI;

public class ToggleSFX : BaseToggle
{
    [SerializeField] protected Slider m_slider;

    [SerializeField] private float oldVolumn = 1;

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
