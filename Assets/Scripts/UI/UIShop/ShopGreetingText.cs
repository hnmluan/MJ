using Assets.SimpleLocalization;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

[RequireComponent(typeof(LocalizedText))]
public class ShopGreetingText : BaseText
{
    [Header("Shop Greeting Text")]

    [SerializeField] protected LocalizedText localizedText;

    [SerializeField] protected List<string> keysLocalizedText;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLocalizedText();
    }

    protected override void OnEnable()
    {
        localizedText.LocalizationKey = GetRamdomGreeting();
        localizedText.Localize();
    }

    protected string GetRamdomGreeting()
    {
        Random random = new Random();

        int randomIndex = random.Next(keysLocalizedText.Count);

        return keysLocalizedText[randomIndex];
    }

    private void LoadLocalizedText()
    {
        if (this.localizedText != null) return;
        this.localizedText = transform.GetComponent<LocalizedText>();
        Debug.Log(transform.name + ": LoadLocalizedText", gameObject);
    }
}
