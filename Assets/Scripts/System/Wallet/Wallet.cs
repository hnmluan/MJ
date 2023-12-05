using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Wallet : Singleton<Wallet>
{
    private List<IObservationWallet> observations = new List<IObservationWallet>();

    [SerializeField] private int goldenBalance;
    public int GoldenBalance => goldenBalance;

    [SerializeField] private int silverBalance;
    public int SilverBalance => silverBalance;

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
            this.goldenBalance = 99;
            this.silverBalance = 99;
            return;
        };

        this.goldenBalance = walletData.goldenBalance;
        this.silverBalance = walletData.silverBalance;
    }

    public void SaveData() => SaveLoadHandler.SaveToFile(FileNameData.Wallet, this);

    public void AddGold(int golden)
    {
        this.goldenBalance += golden;
        this.SaveData();
        this.ExcuteAddGoldObservation();
    }

    public void AddSilver(int silver)
    {
        this.silverBalance += silver;
        this.SaveData();
        this.ExcuteAddSilverObservation();
    }

    public bool DeductGold(int golden)
    {
        if (golden - this.goldenBalance > 0) return false;
        this.goldenBalance -= golden;
        this.SaveData();
        this.ExcuteDeductGoldObservation();
        return true;
    }

    public bool DeductSilver(int silver)
    {
        if (silver - this.silverBalance > 0) return false;
        this.silverBalance -= silver;
        this.SaveData();
        this.ExcuteDeductSilverObservation();
        return true;
    }

    public void AddObservation(IObservationWallet observation) => observations.Add(observation);

    public void RemoveObservation(IObservationWallet observation) => observations.Remove(observation);

    public void ExcuteAddGoldObservation()
    {
        foreach (IObservationWallet observation in observations)
            observation.AddGold();
    }

    public void ExcuteDeductGoldObservation()
    {
        foreach (IObservationWallet observation in observations)
            observation.DeductGold();
    }

    public void ExcuteAddSilverObservation()
    {
        foreach (IObservationWallet observation in observations)
            observation.AddSilver();
    }

    public void ExcuteDeductSilverObservation()
    {
        foreach (IObservationWallet observation in observations)
            observation.DeductSilver();
    }
}
