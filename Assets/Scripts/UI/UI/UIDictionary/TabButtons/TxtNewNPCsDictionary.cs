public class TxtNewNPCsDictionary : BaseText
{
    private void Update()
    {
        if (Dictionary.Instance.GetNumberOfNpcsInNotSeen() == 0)
        {
            text.text = "";
            return;
        }

        text.text =
            "(" +
            Dictionary.Instance.GetNumberOfNpcsInNotSeen().ToString() +
            ")";
    }
}
