public class BtnOpenShop : BaseButton
{
    protected override void OnClick() => UIShop.Instance.Toggle();
}
