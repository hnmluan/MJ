public class TxtNewWeaponsDictionary : BaseText
{
    private void Update()
    {
        if (Dictionary.Instance.GetNumberOfWeaponsInNotSeen() == 0)
        {
            text.text = "";
            return;
        }

        text.text =
            "(" +
            Dictionary.Instance.GetNumberOfWeaponsInNotSeen().ToString() +
            ")";
    }
}
