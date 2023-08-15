public class ImgInvItemDetail : BaseImage
{
    protected virtual void FixedUpdate() => this.UpdateImage();

    protected virtual void UpdateImage()
    {
        try
        {
            if (UIInvDetail.Instance.ItemInventory == null)
            {
                image.sprite = null;
                return;
            }
            image.sprite = UIInvDetail.Instance.ItemInventory.itemProfile.itemSprite;
        }
        catch (System.Exception)
        {
            image.sprite = null;
        }
    }
    protected override void OnDisable() => image.sprite = null;

}
