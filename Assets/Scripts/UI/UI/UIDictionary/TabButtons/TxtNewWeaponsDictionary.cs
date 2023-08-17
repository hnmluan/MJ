public class TxtNewWeaponsDictionary : BaseText, IActionDictionaryObserver
{
    public void OnAddItem() => text.text = GetNumberNewObjText();

    public void OnSeenItem() => text.text = GetNumberNewObjText();

    protected override void OnEnable() => text.text = GetNumberNewObjText();

    protected override void Start() => Dictionary.Instance.AddObserver(this);

    private string GetNumberNewObjText()
    {
        try
        {
            if (Dictionary.Instance.GetNumberOfWeaponsInNotSeen() == 0) return "";
            return "(" + Dictionary.Instance.GetNumberOfWeaponsInNotSeen().ToString() + ")";
        }
        catch (System.Exception)
        {
            return "";
        }

    }
}
