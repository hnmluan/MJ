using System;

[Serializable]

public class WeaponRecipeIngredient
{
    public ItemDataSO itemProfile;
    public int itemCount;

    public bool isAvailable() => Inventory.Instance.GetItemCount(itemProfile) >= itemCount;
}
