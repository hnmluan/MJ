public class BtnCloseUIDecompose : BaseButton
{
    protected override void OnClick()
    {
        UIDecompose.Instance.Close();
    }
}
