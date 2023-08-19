public class BtnInvUse : BaseButton
{
    protected override void OnClick() =>
        UITextSpawner.Instance.SpawnUIImageTextWithMousePosition(UIInvDetail.Instance.UseItem());
}
