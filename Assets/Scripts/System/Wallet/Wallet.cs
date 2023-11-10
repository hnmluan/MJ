using System;
using UnityEngine;

[Serializable]
public class Wallet : Singleton<Wallet>
{
    [SerializeField] private int goldenBalance;
    public int GoldenBalance { get => goldenBalance; }

    [SerializeField] private int silverBalance;
    public int SilverBalance { get => silverBalance; }

    protected override void Awake()
    {
        base.Awake();
        LoadData();
    }

    public void LoadData()
    {
        WalletData walletData = SaveLoadHandler.LoadFromFile<WalletData>(FileNameData.Wallet);

        if (walletData == null)
        {
            this.goldenBalance = 100;
            this.silverBalance = 100;
            Debug.Log("NULLLLLLLLLLLLLLLLLLL");
            return;
        };

        this.goldenBalance = walletData.goldenBalance;
        this.silverBalance = walletData.silverBalance;
    }

    public void SaveData() => SaveLoadHandler.SaveToFile(FileNameData.Wallet, this);

    public void SetGoldenBalance(int golden)
    {
        this.goldenBalance = golden;
        SaveData();
    }

    public void AddGoldenBalance(int golden)
    {
        this.goldenBalance += golden;
        SaveData();
    }

    public bool DeductGoldenBalance(int golden)
    {
        if (golden - this.goldenBalance > 0) return false;
        this.goldenBalance -= golden;
        SaveData();
        return true;
    }

    public void SetSilverBalance(int silver)
    {
        this.silverBalance = silver;
        SaveData();
    }

    public void AddSilverBalance(int silver)
    {
        this.silverBalance += silver;
        SaveData();
    }

    public bool DeductSilverBalance(int silver)
    {
        if (silver - this.silverBalance > 0) return false;
        this.silverBalance -= silver;
        SaveData();
        return true;
    }
}
