public class ImgGoldIcon : BaseImage
{
    protected override void Start() => this.UpdateImage();

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
