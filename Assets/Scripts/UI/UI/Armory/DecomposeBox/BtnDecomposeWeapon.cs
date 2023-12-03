using Assets.SimpleLocalization;
using System.Collections.Generic;

public class BtnDecomposeWeapon : BaseButton
{
    protected override void OnClick()
    {
        ItemArmory weapon = UIArmory.Instance.UIArmoryDetail.Weapon;

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

        UIArmory.Instance.UIDecompose.Close();

        weapon.Decompose();

        UIArmory.Instance.UIArmoryDetail.Clear();

        UIArmory.Instance.ShowItems();
    }
}
