using UnityEngine;
using UnityEngine.UI;

public class SliderMusic : BaseSlider
{
    [SerializeField] protected Toggle Toggle;
    protected override void OnChanged(float newValue)
    {
        if (newValue == 0) Toggle.isOn = true;
        if (newValue > 0) Toggle.isOn = false;
        AudioController.Instance.MusicVolume(newValue);
    }
}
