public class VFXSlider : BaseSlider
{
    protected override void OnChanged(float newValue) => AudioController.Instance.SFXVolume(newValue);
}
