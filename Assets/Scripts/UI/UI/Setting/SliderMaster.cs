public class SliderMaster : BaseSlider
{
    protected override void OnEnable() => slider.value = AudioManager.Instance.MasterVolume;

    protected override void OnChanged(float newValue) => AudioManager.Instance.MasterVolume = newValue;
}
