using System;
using System.Linq;
using UnityEngine;

[Serializable]
public class KeyItemData : ActionItemData
{
    public ItemCode treasure;

    protected override void Action()
    {
        if (Inventory.Instance.ItemTotalCount(this.treasure) == 0)
        {
            ConfirmPanel.Ask("Don't have any" + treasure.ToString() + "to use this key", null, null);
            return;
        }

        ItemDataSO treasureSO = ItemDataSO.FindByItemCode(treasure);

        if (treasureSO == null)
        {
            Debug.Log("Don't find any treasure with item code " + treasure.ToString());
            return;
        }

        TreasureItemData? treasureItemData = treasureSO.actionItemDatas.OfType<TreasureItemData>().FirstOrDefault();

        if (treasureItemData == null)
        {
            Debug.Log(treasure.ToString() + "don't have information for TreasureItemDataAction");
            return;
        }


    }

    protected override void SetKeyActionLocalization() => this.KeyActionLocalization = "Use";
}
