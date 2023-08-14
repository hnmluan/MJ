public class DictionaryIn4ItemImage : BaseImage
{
    protected virtual void FixedUpdate() => this.UpdateImage();

    protected virtual void UpdateImage()
    {
        try
        {
            if (UIDictionaryIn4.Instance.ItemDictionary == null)
            {
                image.sprite = null;
                return;
            }
            image.sprite = UIDictionaryIn4.Instance.ItemDictionary.itemProfile.itemSprite;
        }
        catch (System.Exception)
        {
            image.sprite = null;
        }
    }
    protected override void OnDisable() => image.sprite = null;

}
