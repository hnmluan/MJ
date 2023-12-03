using Assets.SimpleLocalization;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShop : UIBase, IObservationShop
{
    private static UIShop instance;
    public static UIShop Instance => instance;

    [SerializeField] protected UIShopItemSpawner itemSpawner;

    [SerializeField] protected Text countdownToReset;

    [SerializeField] protected LocalizedText greetingText;

    [SerializeField] protected List<string> keysGreetingText;

    protected override void Awake()
    {
        base.Awake();
        if (UIShop.instance != null) Debug.LogError("Only 1 UIShop allow to exist");
        UIShop.instance = this;
    }

    protected override void OnEnable()
    {
        Shop.Instance.AddObservation(this);
        ShowItems();
        UpdateGreetingText();
        InvokeRepeating(nameof(UpdateCountdownToReset), 0f, 1f);
    }

    protected override void OnDisable()
    {
        Shop.Instance.RemoveObservation(this);
        CancelInvoke(nameof(UpdateCountdownToReset));
    }

    private void ShowItems()
    {
        itemSpawner.Clear();
        foreach (ItemShop item in Shop.Instance.listItem) itemSpawner.Spawn(item);
    }

    protected void UpdateGreetingText()
    {
        greetingText.LocalizationKey = GetRamdomGreeting();
        greetingText.Localize();
    }

    protected void UpdateCountdownToReset()
    {
        countdownToReset.text = ConvertSecondsToHMS(
            Shop.resetIntervalInSeconds -
            GetSecondsBetweenTimestamps
            (DateTime.Parse(Shop.Instance.latestResetTimestamp),
            DateTime.Now)
            );
    }

    protected int GetSecondsBetweenTimestamps(DateTime startTime, DateTime endTime) => (int)(endTime - startTime).TotalSeconds;

    protected string ConvertSecondsToHMS(int seconds)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
        string t = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
        return t;
    }

    protected string GetRamdomGreeting() => keysGreetingText[(new System.Random()).Next(keysGreetingText.Count)];

    public void BuyItem(ItemShop item, bool isTransactionSuccessful)
    {
        if (isTransactionSuccessful)
        {
            ShowItems();

            string nameCurrency = LocalizationManager.Localize(CurrencyDataSO.FindByName(item.currencyCode).keyName);
            string content = nameCurrency + " - " + item.price;
            Sprite image = CurrencyDataSO.FindByName(item.currencyCode).currencySprite;

            UITextSpawner.Instance.SpawnUIImageTextWithMousePosition(content, image);
            return;
        }

        UITextSpawner.Instance.SpawnUITextWithMousePosition(LocalizationManager.Localize("Shop.BalanceNotEnough"));
    }

    public void ResetItems() => ShowItems();
}
