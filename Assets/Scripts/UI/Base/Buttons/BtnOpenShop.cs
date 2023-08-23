public class BtnOpenShop : BaseButton
{
    protected override void OnClick() => UIShop.Instance.Toggle();

    private void Update()
    {
        if (InputManager.Instance.OpenShop()) OnClick();
    }
}
