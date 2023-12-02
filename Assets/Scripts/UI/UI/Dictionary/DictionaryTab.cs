using UnityEngine;
using UnityEngine.UI;

public class DictionaryTab : BaseButton
{
    [SerializeField] protected EDictionaryType dictionaryType;

    protected override void OnEnable()
    {
        if (dictionaryType == EDictionaryType.Enemies) this.GetComponent<Image>().color = Color.white;
    }

    protected override void OnClick()
    {
        UIDictionary.Instance.SwitchTab(this.dictionaryType);
        this.GetComponent<Image>().color = Color.white;
    }
}
