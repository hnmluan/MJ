using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class SwitchScene : InitMonoBehaviour
{
    public BoxCollider2D boxCollider2D;
    public string targetScene;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("hello");
            SceneManager.LoadSceneAsync(targetScene);
        }
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCollider2D();
    }

    private void LoadCollider2D()
    {
        if (boxCollider2D != null) return;
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
        boxCollider2D.isTrigger = true;
        Debug.Log(transform.name + ": LoadCollider2D", gameObject);
    }
}
