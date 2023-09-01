using UnityEngine;
using UnityEngine.UI;

public class SliderSFX : BaseSlider
{
    [SerializeField] protected Toggle Toggle;
    protected override void OnChanged(float newValue)
    {
        if (newValue == 0) Toggle.isOn = true;
        if (newValue > 0) Toggle.isOn = false;
        AudioController.Instance.SFXVolume(newValue);
    }
}
