using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class BtnDictionaryEnemiesTab : BaseButton
{
    private void Update()
    {
        Color targetColor = ColorUtility.TryParseHtmlString("#A9A9A9", out Color parsedColor) ? parsedColor : Color.white;
        this.GetComponent<Image>().color = targetColor;
        if (UIDictionary.Instance.DictionaryType == EDictionaryType.Enemies)
            this.GetComponent<Image>().color = Color.white;
    }
    protected override void OnClick()
    {
        UIDictionary.Instance.SetDictionaryFilter(EDictionaryType.Enemies);
        UIDictionaryDetail.Instance.ShowEmptyObj();
    }
}
