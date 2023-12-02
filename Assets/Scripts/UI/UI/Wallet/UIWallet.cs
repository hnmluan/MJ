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
        GoldBalance.text = "x " + Wallet.Instance.GoldenBalance;
        SilverBalance.text = "x " + Wallet.Instance.SilverBalance;
        GoldSprite.sprite = CurrencyDataSO.FindByCode(CurrencyCode.Gold).currencySprite;
        SilverSprite.sprite = CurrencyDataSO.FindByCode(CurrencyCode.Silver).currencySprite;
    }

    public void AddGold() => GoldBalance.text = "x " + Wallet.Instance.GoldenBalance;

    public void AddSilver() => SilverBalance.text = "x " + Wallet.Instance.SilverBalance;

    public void DeductGold() => GoldBalance.text = "x " + Wallet.Instance.GoldenBalance;

    public void DeductSilver() => SilverBalance.text = "x " + Wallet.Instance.SilverBalance;
}
