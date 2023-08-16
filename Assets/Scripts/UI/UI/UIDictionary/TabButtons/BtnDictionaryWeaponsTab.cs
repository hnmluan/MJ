using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class BtnDictionaryWeaponsTab : BaseButton
{
    private void Update()
    {
        Color targetColor = ColorUtility.TryParseHtmlString("#A9A9A9", out Color parsedColor) ? parsedColor : Color.white;
        this.GetComponent<Image>().color = targetColor;
        if (UIDictionary.Instance.DictionaryType == EDictionaryType.Weapons)
            this.GetComponent<Image>().color = Color.white;
    }
    protected override void OnClick()
    {
        UIDictionary.Instance.SetDictionaryFilter(EDictionaryType.Weapons);
        UIDictionaryDetail.Instance.ShowEmptyObj();
    }
}
