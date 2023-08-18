using System.Collections.Generic;
using UnityEngine;

public class BtnDecomposeWeapon : BaseButton
{
    protected override void OnClick()
    {
        Weapon weapon = UIArmoryDetail.Instance.Weapon;

        List<WeaponRecipeIngredient> list = weapon.GetRecipeDecompose();

        foreach (WeaponRecipeIngredient item in list) Debug.Log(item.itemProfile.itemCode.ToString() + " : " + item.itemCount);

        UIDecompose.Instance.Close();

        weapon.Decompose();

        UIArmoryDetail.Instance.SetEmptyUIArmoryDetail();

        UIArmory.Instance.ShowWeapons();
    }
}
