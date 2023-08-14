public class ImgGoldIcon : BaseImage
{
    protected virtual void FixedUpdate() => this.UpdateImage();

    protected virtual void UpdateImage()
    {
        try
        {
            image.sprite = CurrencyProfileSO.FindByItemCode(CurrencyCode.Gold).currencySprite;
        }
        catch (System.Exception)
        {
            image.sprite = null;
        }
    }
}
