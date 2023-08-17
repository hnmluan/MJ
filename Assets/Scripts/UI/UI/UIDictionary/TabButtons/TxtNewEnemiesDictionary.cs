public class TxtNewEnemiesDictionary : BaseText, IActionDictionaryObserver
{
    public void OnAddItem() => text.text = GetNumberNewObjText();

    public void OnSeenItem() => text.text = GetNumberNewObjText();

    protected override void OnEnable() => text.text = GetNumberNewObjText();

    protected override void Start() => Dictionary.Instance.AddObserver(this);

    private string GetNumberNewObjText()
    {
        if (Dictionary.Instance.GetNumberOfEnemiesInNotSeen() == 0) return "";
        return "(" + Dictionary.Instance.GetNumberOfEnemiesInNotSeen().ToString() + ")";
    }
}