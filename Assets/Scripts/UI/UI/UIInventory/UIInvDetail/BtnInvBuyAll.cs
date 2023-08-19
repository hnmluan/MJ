using System.Collections.Generic;

public class BtnInvBuyAll : BaseButton
{
    protected override void OnClick()
    {
        List<int> listPrice = UIInvDetail.Instance.BuyAllItem();
        List<string> stringList = listPrice.ConvertAll(item => "+ " + item.ToString() + " GOLD");
        UITextSpawner.Instance.SpawnUITextWithMousePosition(stringList);
    }
}
