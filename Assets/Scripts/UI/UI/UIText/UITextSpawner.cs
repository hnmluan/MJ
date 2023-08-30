using Assets.SimpleLocalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITextSpawner : Spawner
{
    private static UITextSpawner instance;
    public static UITextSpawner Instance { get => instance; }

    public float interval;

    protected override void Awake()
    {
        base.Awake();
        if (UITextSpawner.instance != null) Debug.Log("Only 1 UITextSpawner allow to exist");
        UITextSpawner.instance = this;
    }

    /*-----------------UIText----------------------*/

    public virtual void SpawnUIText(string content, Vector3 position)
    {
        Transform text = Spawn("UIText", position, Quaternion.identity);

        text.gameObject.SetActive(true);

        UIText uIText = text.GetComponent<UIText>();

        uIText.SetText(content);
    }

    public virtual IEnumerator SpawnUIText(List<string> contents, Vector3 position)
    {
        foreach (string text in contents)
        {
            SpawnUIText(text, position);
            yield return new WaitForSeconds(interval);
        }
    }

    public virtual void SpawnUITextWithMousePosition(string content)
    {
        Vector2 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, -Camera.main.transform.position.z));
        SpawnUIText(content, mouseWorldPosition);
    }

    public void SpawnUITextWithMousePosition(List<string> contents) => StartCoroutine(IESpawnUITextWithMousePosition(contents));

    private IEnumerator IESpawnUITextWithMousePosition(List<string> contents)
    {
        Vector2 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, -Camera.main.transform.position.z));
        foreach (string text in contents)
        {
            SpawnUIText(text, mouseWorldPosition);
            yield return new WaitForSeconds(interval);
        }
    }

    /*-----------------UIImageText----------------------*/

    public virtual void SpawnUIImageText(string content, Sprite image, Vector3 position)
    {
        Transform text = Spawn("UIImageText", position, Quaternion.identity);

        text.gameObject.SetActive(true);

        UIImageText uIImageText = text.GetComponent<UIImageText>();

        uIImageText.SetContent(content, image);
    }

    public virtual void SpawnUIImageTextWithMousePosition(string content, Sprite image)
    {
        Vector2 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, -Camera.main.transform.position.z));

        SpawnUIImageText(content, image, mouseWorldPosition);
    }

    public void SpawnUIImageTextWithMousePosition(List<ItemDropRate> list)
    {
        Vector2 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, -Camera.main.transform.position.z));
        Vector3 clone = new Vector3(mouseWorldPosition.x, mouseWorldPosition.y, mouseWorldPosition.z);
        StartCoroutine(IESpawnUIImageText(list, clone));
    }

    public void SpawnUIImageTextWithMousePosition(List<string> list, Sprite image) => StartCoroutine(IESpawnUIImageTextWithMousePosition(list, image));

    public void SpawnUIImageTextWithMousePosition(List<ImageText> list) => StartCoroutine(IESpawnUIImageTextWithMousePosition(list));

    private IEnumerator IESpawnUIImageTextWithMousePosition(List<string> list, Sprite image)
    {
        Vector2 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, -Camera.main.transform.position.z));

        foreach (string item in list)
        {
            SpawnUIImageText(item, image, mouseWorldPosition);
            yield return new WaitForSeconds(interval);
        }
    }

    private IEnumerator IESpawnUIImageTextWithMousePosition(List<ImageText> list)
    {
        Vector2 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, -Camera.main.transform.position.z));

        foreach (ImageText item in list)
        {
            SpawnUIImageText(item.text, item.image, mouseWorldPosition);
            yield return new WaitForSeconds(interval);
        }
    }

    private IEnumerator IESpawnUIImageText(List<ItemDropRate> list, Vector3 position)
    {
        foreach (ItemDropRate item in list)
        {
            Sprite sprite = item.itemSO.itemSprite;
            string content = LocalizationManager.Localize(item.itemSO.keyName.ToString()) + " +1";
            SpawnUIImageText(content, sprite, position);
            yield return new WaitForSeconds(interval);
        }
    }

}
