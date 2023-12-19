using Assets.SimpleLocalization;
using System.Collections;
using UnityEngine;

public class UIText : InitMonoBehaviour
{
    [SerializeField] protected LocalizedText content;
    public LocalizedText Content => content;

    [SerializeField] protected float speed = 2f;

    [SerializeField] protected float time = 0.5f;

    protected virtual void FixedUpdate() => transform.Translate(Vector3.up * speed * Time.deltaTime);

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadContent();
    }

    protected override void OnEnable() => StartCoroutine(Despawn());

    private IEnumerator Despawn()
    {
        yield return new WaitForSeconds(time);

        UITextSpawner.Instance.Despawn(transform);
    }

    protected virtual void LoadContent()
    {
        if (this.content != null) return;
        this.content = transform.Find("Text").GetComponent<LocalizedText>();
        Debug.Log(transform.name + ": LoadContent", gameObject);
    }

    public void SetText(string content)
    {
        this.content.LocalizationKey = content;
        this.content.Localize();
    }
}
