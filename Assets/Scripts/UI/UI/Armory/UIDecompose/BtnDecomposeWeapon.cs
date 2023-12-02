using Assets.SimpleLocalization;
using System.Collections.Generic;

public class BtnDecomposeWeapon : BaseButton
{
    protected override void OnClick()
    {
        ItemArmory weapon = UIArmoryDetail.Instance.Weapon;

        List<WeaponRecipeIngredient> listRecipeIngredient = weapon.GetRecipeDecompose();

        List<ImageText> textList = new List<ImageText>();

        foreach (WeaponRecipeIngredient item in listRecipeIngredient)
        {
            ImageText imageText = new ImageText();
            imageText.text = LocalizationManager.Localize(item.itemProfile.keyName) + "+" + item.itemCount;
            imageText.image = item.itemProfile.itemSprite;
            textList.Add(imageText);
        }

        UITextSpawner.Instance.SpawnUIImageTextWithMousePosition(textList);

        UIDecompose.Instance.Close();

        weapon.Decompose();

        UIArmoryDetail.Instance.SetEmptyUIArmoryDetail();

        UIArmory.Instance.ShowWeapons();

        UIArmory.Instance.KeepFocusInCurrentItemArmory();
    }
}
