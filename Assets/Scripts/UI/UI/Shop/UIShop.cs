using Assets.SimpleLocalization;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

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
        itemSpawner.ClearItems();
        foreach (ItemShop item in Shop.Instance.listItem) itemSpawner.SpawnItem(item);
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

    protected int GetSecondsBetweenTimestamps(DateTime startTime, DateTime endTime)
    {
        TimeSpan duration = endTime - startTime;
        int timeDifferenceInSeconds = (int)duration.TotalSeconds;
        return timeDifferenceInSeconds;
    }

    protected string ConvertSecondsToHMS(int seconds)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
        string t = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
        return t;
    }

    protected string GetRamdomGreeting()
    {
        Random random = new Random();
        return keysGreetingText[random.Next(keysGreetingText.Count)];
    }
    public void BuyItem() => ShowItems();

    public void ResetItems() => ShowItems();
}
