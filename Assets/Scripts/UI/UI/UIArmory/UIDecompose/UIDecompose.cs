using System.Collections.Generic;
using UnityEngine;

public class UIDecompose : InitMonoBehaviour
{
    private static UIDecompose instance;
    public static UIDecompose Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (UIDecompose.instance != null) Debug.LogError("Only 1 UIDecompose allow to exist");
        UIDecompose.instance = this;
    }

    protected override void Start() => Close();
    public virtual void Open()
    {
        gameObject.SetActive(true);
        ShowRecipeDecompose();
    }

    public virtual void Close() => gameObject.SetActive(false);

    public void ShowRecipeDecompose()
    {
        RecipeDecomposeUISpawner.Instance.ClearRecipeDecomposeLevelUI();

        List<WeaponRecipeIngredient> recipePrices = UIArmoryDetail.Instance.Weapon.GetRecipeDecompose();

        if (recipePrices == null) return;

        for (int i = 0; i < recipePrices.Count; i++) RecipeDecomposeUISpawner.Instance.SpawnRecipeDecomposeItemUI(recipePrices[i]);
    }
}
