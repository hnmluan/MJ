public class SliderSFX : BaseSlider
{
    protected override void OnChanged(float newValue) => AudioController.Ins.SFXVolume(newValue);
}
