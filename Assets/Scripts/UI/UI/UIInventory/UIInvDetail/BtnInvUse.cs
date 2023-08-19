public class BtnInvUse : BaseButton
{
    protected override void OnClick() => UITextSpawner.Instance.SpawnUITextWithMousePosition(UIInvDetail.Instance.UseItem());
}
