public class TxtNewEnemiesDictionary : BaseText
{
    private void Update()
    {
        if (Dictionary.Instance.GetNumberOfEnemiesInNotSeen() == 0)
        {
            text.text = "";
            return;
        }

        text.text =
            "(" +
            Dictionary.Instance.GetNumberOfEnemiesInNotSeen().ToString() +
            ")";
    }
}
