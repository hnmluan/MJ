using UnityEngine;

public class Wallet : InitMonoBehaviour
{
    private static Wallet instance;
    public static Wallet Instance { get => instance; }

    [SerializeField] private int goldenBalance;
    public int GoldenBalance { get => goldenBalance; }

    [SerializeField] private int silverBalance;
    public int SilverBalance { get => silverBalance; }

    public void SetGoldenBalance(int golden) => this.goldenBalance = golden;

    public void AddGoldenBalance(int golden) => this.goldenBalance += golden;

    public bool DeductGoldenBalance(int golden)
    {
        if (golden - this.goldenBalance > 0) return false;
        this.goldenBalance -= golden;
        return true;
    }

    public void SetSilverBalance(int silver) => this.silverBalance = silver;

    public void AddSilverBalance(int silver) => this.silverBalance += silver;

    public bool DeductSilverBalance(int silver)
    {
        if (silver - this.silverBalance > 0) return false;
        this.silverBalance -= silver;
        return true;
    }

    protected override void Awake()
    {
        base.Awake();
        if (Wallet.instance != null) Debug.LogError("Only 1 PlayerCtrl allow to exist");
        Wallet.instance = this;
    }
}
