using System.Collections.Generic;

public class BtnInvBuy : BaseButton
{
    protected override void OnClick()
    {
        List<string> list = new List<string>();
        list.Add("abscacsaac");
        list.Add("abscacsaac");
        list.Add("abscacsaac");
        list.Add("abscacsaac");
        list.Add("abscacsaac");
        list.Add("abscacsaac");
        UITextSpawner.Instance.SpawnUITextWithMousePosition("+" + UIInvDetail.Instance.BuyItem().ToString());
        UITextSpawner.Instance.SpawnUITextWithMousePosition(list);
    }

}
