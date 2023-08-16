using UnityEngine;

public class LocalizationKey : InitMonoBehaviour
{
    private static LocalizationKey instance;
    public static LocalizationKey Instance => instance;
    protected override void Awake()
    {
        base.Awake();
        if (LocalizationKey.instance != null) Debug.LogError("Only 1 LocalizationKey allow to exist");
        LocalizationKey.instance = this;
    }

    public static string ItemName(ItemCode item) => "Item." + item.ToString();
    public static string ItemDescription(ItemCode item) => "Item.Description." + item.ToString();
    public static string ItemType(ItemType item) => "Item.Type." + item.ToString();
    public static string EnemyName(EnemyCode enemy) => "Enemy." + enemy.ToString();
    public static string EnemyType(EnemyCode enemy) => "Enemy.Type." + enemy.ToString();
    public static string EnemyDescription(EnemyCode enemy) => "Enemy.Description." + enemy.ToString();
    public static string CurrencyName(CurrencyCode currency) => "Currency." + currency.ToString();
    public static string CurrencyDescription(CurrencyCode currency) => "Currency.Description." + currency.ToString();

}
