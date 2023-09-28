using System;
using System.Linq;
using UnityEngine;

[Serializable]
public class KeyItemActionData : ItemActionData
{

    public ItemCode treasure;

    public override void Action()
    {
        if (!IsExistTreasureSO())
        {
            Debug.Log("Don't find any treasure with item code " + treasure.ToString());
            return;
        }

        if (!IsAvailabelTreasureInInventory())
        {
            ConfirmPanel.Ask("Don't have any" + treasure.ToString() + "to use this key", null, null);
            return;
        }

        if (IsHaveTreasureItemActionData())
        {
            TreasureItemActionData treasureItemActionData = ItemDataSO.FindByItemCode(treasure).actionItemDatas.OfType<TreasureItemActionData>().FirstOrDefault();
            treasureItemActionData.Action();
        }
    }

    private bool IsExistTreasureSO() => ItemDataSO.FindByItemCode(treasure) != null;

    private bool IsAvailabelTreasureInInventory() => Inventory.Instance.ItemTotalCount(this.treasure) != 0;

    private bool IsHaveTreasureItemActionData() => ItemDataSO.FindByItemCode(treasure).actionItemDatas.OfType<TreasureItemActionData>().FirstOrDefault() != null;

    protected override void SetKeyActionLocalization() => this.keyActionLocalization = "Use";
}
