using System.Collections.Generic;
using UnityEngine;

public class UIDecompose : InitMonoBehaviour
{
    [SerializeField] protected RecipeDecomposeUISpawner itemSpawner;
    public RecipeDecomposeUISpawner ItemSpawner => itemSpawner;

    protected override void Start() => Close();
    public virtual void Open()
    {
        gameObject.SetActive(true);
        ShowRecipeDecompose();
    }

    public virtual void Close() => gameObject.SetActive(false);

    public void ShowRecipeDecompose()
    {
        itemSpawner.ClearRecipeDecomposeLevelUI();

        List<WeaponRecipeIngredient> recipePrices = UIArmory.Instance.UIArmoryDetail.Weapon.GetRecipeDecompose();

        if (recipePrices == null) return;

        for (int i = 0; i < recipePrices.Count; i++) itemSpawner.SpawnRecipeDecomposeItemUI(recipePrices[i]);
    }
}
