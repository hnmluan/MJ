public class ImgSilverIcon : BaseImage
{
    protected virtual void FixedUpdate() => this.UpdateImage();

    protected virtual void UpdateImage()
    {
        try
        {
            image.sprite = CurrencyProfileSO.FindByItemCode(CurrencyCode.Silver).currencySprite;
        }
        catch (System.Exception)
        {
            image.sprite = null;
        }
    }
}
