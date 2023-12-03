using System;
using System.Collections.Generic;
using System.Linq;

public class Shop : Singleton<Shop>
{
    private List<IObservationShop> observations = new List<IObservationShop>();

    public string latestResetTimestamp;

    public static int resetIntervalInSeconds = 10;

    public List<ItemShop> listItem;

    protected void SaveData() => SaveLoadHandler.SaveToFile(FileNameData.Shop, new ShopData(this));

    protected void LoadData()
    {
        ShopData shopData = SaveLoadHandler.LoadFromFile<ShopData>(FileNameData.Shop);

        if (shopData == null)
        {
            this.latestResetTimestamp = DateTime.Now.ToString();
            ResetItem();
            return;
        }

        this.latestResetTimestamp = shopData.latestItemResetTimestamp;
        this.listItem = shopData.listItem;
    }

    protected override void Start() => InvokeRepeating(nameof(CheckResetTime), 0f, 1f);

    protected void CheckResetTime()
    {
        if (!isResetTimeReached()) return;
        this.UpdateLatestResetTimestamp();
        this.ResetItem();
    }

    protected void UpdateLatestResetTimestamp() => latestResetTimestamp = DateTime.Now.ToString();

    protected override void Awake() => LoadData();

    public void ResetItem()
    {
        this.listItem.Clear();
        listItem = ResetItems();
        this.UpdateLatestResetTimestamp();
        this.ExcuteResetItemsObservation();
        this.SaveData();
    }

    protected List<ItemShop> ResetItems()
    {
        List<ItemShop> randomItems = new List<ItemShop>();
        for (int i = 0; i < 10; i++)
        {
            ItemDataSO item = ItemDataSO.GetRandomSellableItemSO();
            ItemShop itemShop = new(item);
            randomItems.Add(itemShop);
        }
        return randomItems;
    }

    public void BuyItem(ItemShop item)
    {
        bool isTransactionSuccessful = item.Buy();
        if (isTransactionSuccessful) this.SaveData();
        this.ExcuteBuyItemObservation(item, isTransactionSuccessful);
    }

    public bool isResetTimeReached() => GetSecondsBetweenTimestamps(DateTime.Parse(latestResetTimestamp), DateTime.Now) >= resetIntervalInSeconds;

    protected int GetSecondsBetweenTimestamps(DateTime startTime, DateTime endTime)
    {
        TimeSpan duration = endTime - startTime;
        int timeDifferenceInSeconds = (int)duration.TotalSeconds;
        return timeDifferenceInSeconds;
    }

    public void AddObservation(IObservationShop observation) => observations.Add(observation);

    public void RemoveObservation(IObservationShop observation) => observations.Remove(observation);

    public void ExcuteBuyItemObservation(ItemShop item, bool isTransactionSuccessful) { foreach (IObservationShop observation in observations) observation.BuyItem(item, isTransactionSuccessful); }

    public void ExcuteResetItemsObservation() { foreach (IObservationShop observation in observations) observation.ResetItems(); }
}

[Serializable]
public class ItemShop
{
    public string itemCode;
    public int quantity;
    public int price;
    public string currencyCode;
    public bool isBuy;

    public ItemShop(ItemDataSO itemDataSO)
    {
        this.itemCode = itemDataSO.itemCode.ToString();
        BuyableItemData buyableItemData = itemDataSO.datas.OfType<BuyableItemData>().FirstOrDefault();
        this.quantity = buyableItemData.quantityToBuy.GetRandomValue();
        Random random = new Random();
        int randomIndex = random.Next(0, buyableItemData.price.Count);
        ItemRangePrice priceData = buyableItemData.price[randomIndex];
        this.price = priceData.rangePrice.GetRandomValue();
        this.currencyCode = priceData.currencyCode.currencyCode.ToString();
        isBuy = false;
    }

    public bool Buy()
    {
        CurrencyCode currencyCode;

        if (Enum.TryParse(this.currencyCode, out currencyCode))
        {
            if ((currencyCode == CurrencyCode.Silver && Wallet.Instance.DeductSilver(price)) ||
                (currencyCode == CurrencyCode.Gold && Wallet.Instance.DeductGold(price)))
            {
                isBuy = true;
                return true;
            }
        }
        return false;
    }
}

[Serializable]
public class ShopData
{
    public string latestItemResetTimestamp;
    public int resetInterval = 100;
    public List<ItemShop> listItem;

    public ShopData(Shop shop)
    {
        this.latestItemResetTimestamp = shop.latestResetTimestamp;
        this.listItem = shop.listItem;
    }
}