using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIImageText : InitMonoBehaviour
{
    [SerializeField] protected Text content;
    public Text Content => content;

    [SerializeField] protected Image image;
    public Image Image => image;

    [SerializeField] protected float speed = 2f;

    [SerializeField] protected float time = 0.5f;

    protected virtual void FixedUpdate() => transform.Translate(Vector3.up * speed * Time.deltaTime);

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadContent();
        this.LoadImage();
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
        this.content = transform.Find("Layout").Find("Text").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadContent", gameObject);
    }
    protected virtual void LoadImage()
    {
        if (this.image != null) return;
        this.image = transform.Find("Layout").Find("Image").GetComponent<Image>();
        Debug.Log(transform.name + ": LoadContent", gameObject);
    }


    public void SetContent(string content, Sprite image)
    {
        this.content.text = content;
        this.image.sprite = image;
    }
}
