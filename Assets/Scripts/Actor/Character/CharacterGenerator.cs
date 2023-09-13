using Assets.SimpleLocalization;
using UnityEngine;

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
        if (this.characterData != null) return;
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
        if (this.visual != null) return;
        visual = GameObject.Find("Visual").GetComponent<SpriteRenderer>();
        Debug.Log(transform.name + ": LoadVisual", gameObject);
    }

    private void LoadAnimator()
    {
        if (this.animator != null) return;
        animator = GameObject.Find("Visual").GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }

    private void LoadKeyName()
    {
        if (this.keyName != null) return;
        keyName = GetComponentInChildren<LocalizedText>();
        Debug.Log(transform.name + ": LoadKeyName", gameObject);
    }

}
