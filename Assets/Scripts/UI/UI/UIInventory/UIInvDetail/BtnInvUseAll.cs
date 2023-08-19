public class BtnInvUseAll : BaseButton
{
    protected override void OnClick()
        =>
       UITextSpawner.Instance.SpawnUIImageTextWithMousePosition(UIInvDetail.Instance.UseAllItem());
}
