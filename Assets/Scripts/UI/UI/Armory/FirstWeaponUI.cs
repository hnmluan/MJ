using UnityEngine;
using UnityEngine.UI;

public class FirstWeaponUI : Singleton<FirstWeaponUI>
{
    [SerializeField] public ItemArmory weapon;

    [SerializeField] private Image image;

    [SerializeField] private Text level;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLevel();
        this.LoadImage();
    }

    private void LoadImage()
    {
        if (this.image != null) return;
        image = transform.Find("Image").Find("Image").GetComponent<Image>();
        Debug.Log(transform.name + ": LoadImage", gameObject);
    }
    private void LoadLevel()
    {
        if (this.level != null) return;
        level = transform.Find("LevelBox").Find("Level").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadLevel", gameObject);
    }

    public void SetFirstWeaponUI(ItemArmory weapon)
    {
        this.weapon = weapon;
        image.sprite = weapon.weaponProfile.spriteInHand;
        level.text = "+" + weapon.level;
    }
}
