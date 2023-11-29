public class BtnOpenShop : BaseButton
{
    protected override void OnClick() => UIShop.Instance.Open();

    private void Update()
    {
        if (InputManager.Instance.OpenShop()) OnClick();
    }
}
