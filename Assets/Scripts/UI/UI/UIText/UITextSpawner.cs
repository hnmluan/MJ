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
        if (UITextSpawner.instance != null) Debug.LogError("Only 1 UITextSpawner allow to exist");
        UITextSpawner.instance = this;
    }

    /*    public virtual void SpawnUIText(string content)
        {
            Vector3 centerPosition = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0f);

            Transform text = Spawn("UIText", centerPosition, Quaternion.identity);

            text.gameObject.SetActive(true);

            UIText uIText = text.GetComponent<UIText>();

            uIText.SetText(content);
        }*/

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

}
