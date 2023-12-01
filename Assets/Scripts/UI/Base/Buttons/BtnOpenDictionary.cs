public class BtnOpenDictionary : BaseButton
{
    protected override void OnClick() => UIDictionary.Instance.Open();

    private void Update()
    {
        if (InputManager.Instance.OpenDictionary()) OnClick();
    }
}