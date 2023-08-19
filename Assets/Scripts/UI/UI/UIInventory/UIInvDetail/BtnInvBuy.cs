public class BtnInvBuy : BaseButton
{
    protected override void OnClick()
    {
        UITextSpawner.Instance.SpawnUITextWithMousePosition("+ " + UIInvDetail.Instance.BuyItem().ToString() + " GOLD");
    }

}
