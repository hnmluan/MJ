public class InvIn4ItemImage : BaseImage
{
    protected virtual void FixedUpdate() => this.UpdateImage();

    protected virtual void UpdateImage()
    {
        try
        {
            if (UIInvIn4.Instance.ItemInventory == null)
            {
                image.sprite = null;
                return;
            }
            image.sprite = UIInvIn4.Instance.ItemInventory.itemProfile.itemSprite;
        }
        catch (System.Exception)
        {
            image.sprite = null;
        }
    }
    protected override void OnDisable() => image.sprite = null;

}
