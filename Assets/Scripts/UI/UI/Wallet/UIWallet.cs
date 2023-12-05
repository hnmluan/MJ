using System;
using UnityEngine;
using UnityEngine.UI;

public class UIWallet : InitMonoBehaviour, IObservationWallet
{
    [SerializeField] protected Text GoldBalance;
    [SerializeField] protected Text SilverBalance;
    [SerializeField] protected Image GoldSprite;
    [SerializeField] protected Image SilverSprite;

    protected override void Awake()
    {
        Wallet.Instance.AddObservation(this);
        GoldBalance.text = GetFormattedBalance(Wallet.Instance.GoldenBalance);
        SilverBalance.text = GetFormattedBalance(Wallet.Instance.SilverBalance);
        GoldSprite.sprite = CurrencyDataSO.FindByCode(CurrencyCode.Gold).currencySprite;
        SilverSprite.sprite = CurrencyDataSO.FindByCode(CurrencyCode.Silver).currencySprite;
    }

    public void AddGold() => GoldBalance.text = GetFormattedBalance(Wallet.Instance.GoldenBalance);

    public void AddSilver() => SilverBalance.text = GetFormattedBalance(Wallet.Instance.SilverBalance);

    public void DeductGold() => GoldBalance.text = GetFormattedBalance(Wallet.Instance.GoldenBalance);

    public void DeductSilver() => SilverBalance.text = GetFormattedBalance(Wallet.Instance.SilverBalance);

    public string GetFormattedBalance(int balance)
        => balance < 1000 ? balance.ToString() : Math.Round(Convert.ToDouble(balance / 1000)) + "k";

}
