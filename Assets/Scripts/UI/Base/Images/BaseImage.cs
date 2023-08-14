using UnityEngine;
using UnityEngine.UI;

public class BaseImage : InitMonoBehaviour
{
    [Header("Base ItemImage")]
    [SerializeField] protected Image image;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadImage();
    }

    protected virtual void LoadImage()
    {
        if (this.image != null) return;
        this.image = GetComponent<Image>();
        Debug.LogWarning(transform.name + ": LoadImage", gameObject);
    }
}
