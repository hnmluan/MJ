public class BtnInvUseAll : BaseButton
{
    protected override void OnClick()
        =>
       UITextSpawner.Instance.SpawnUITextWithMousePosition(UIInvDetail.Instance.UseAllItem());
}
