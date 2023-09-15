using Assets.SimpleLocalization;
using UnityEngine;
using UnityEngine.UI;

public class CharacterGenerator : InitMonoBehaviour
{
    protected SpriteRenderer visual;

    protected Animator animator;

    protected LocalizedText keyName;

    protected CharacterDataSO characterData;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCharacterData();
        this.LoadVisual();
        this.LoadAnimator();
        this.LoadKeyName();
    }

    private void LoadCharacterData()
    {
        characterData = CharacterDataSO.FindByName(name);
        if (characterData == null)
        {
            Debug.Log(transform.name + ": Don't have data", gameObject);
            return;
        };
        Debug.Log(transform.name + ": LoadCharacterData", gameObject);
    }

    private void LoadVisual()
    {
        visual = transform.Find("Visual").GetComponent<SpriteRenderer>();
        visual.sprite = characterData.visual;
        Debug.Log(transform.name + ": LoadVisual", gameObject);
    }

    private void LoadAnimator()
    {
        animator = transform.Find("Visual").GetComponent<Animator>();
        animator.runtimeAnimatorController = characterData.animator;
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }

    private void LoadKeyName()
    {
        keyName = GetComponentInChildren<LocalizedText>();
        keyName.LocalizationKey = characterData.keyName;
        GetComponentInChildren<Text>().text = LocalizationManager.Localize(characterData.keyName);
        Debug.Log(transform.name + ": LoadKeyName", gameObject);
    }

}
