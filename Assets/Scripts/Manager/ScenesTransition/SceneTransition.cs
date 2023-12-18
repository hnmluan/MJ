using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class SceneTransition : InitMonoBehaviour
{
    [SerializeField] private Scenes scene;

    [SerializeField] private Vector3 position;

    public void MoveToScene()
    {
        if (scene == Scenes.NoScene) return;
        LoadingScene.Instance.LoadScence(scene, position);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) MoveToScene();
    }
}
