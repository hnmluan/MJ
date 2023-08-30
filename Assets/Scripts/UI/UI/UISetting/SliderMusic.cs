public class SliderMusic : BaseSlider
{
    protected override void OnChanged(float newValue) =>
    AudioController.Ins.MusicVolume(newValue);
}
