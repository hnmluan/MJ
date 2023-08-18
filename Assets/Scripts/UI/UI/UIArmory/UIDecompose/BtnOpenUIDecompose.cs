public class BtnOpenUIDecompose : BaseButton
{
    protected override void OnClick()
    {
        UIDecompose.Instance.Open();
    }
}
