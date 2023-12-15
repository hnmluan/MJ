public class BtnOpenTask : BaseButton
{
    protected override void OnClick() => UITask.Instance.Open();
}
