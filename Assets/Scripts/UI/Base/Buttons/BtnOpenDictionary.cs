public class BtnOpenDictionary : BaseButton
{
    protected override void OnClick() => UIDictionary.Instance.Toggle();

    private void Update()
    {
        if (InputManager.Instance.OpenDictionary()) OnClick();
    }
}