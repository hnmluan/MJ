using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Scenes
{
    NoScene = 0,
    Map_01 = 1,
    Map_02 = 2,
}

public class LoadingScene : InitMonoBehaviour
{
    private static LoadingScene instance;
    public static LoadingScene Instance => instance;

    [SerializeField] private GameObject loadingUI;

    [SerializeField] private Slider loadingProcess;

    [SerializeField] private AstarPath astarPath;
    protected override void Awake()
    {
        base.Awake();
        if (LoadingScene.instance != null) Debug.LogError("Only 1 LoadingScene allow to exist");
        LoadingScene.instance = this;
    }

    public async void LoadScence(Scenes name, Vector3 position)
    {
        var scene = SceneManager.LoadSceneAsync(name.ToString());
        scene.allowSceneActivation = false;

        loadingUI.SetActive(true);

        do
        {
            await Task.Delay(100);
            loadingProcess.value = scene.progress;
        } while (scene.progress < 0.9f);

        await Task.Delay(1000);

        scene.allowSceneActivation = true;
        loadingUI.SetActive(false);

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) player.transform.position = position;
    }

    protected override void OnEnable() => SceneManager.activeSceneChanged += OnSceneChanged;

    protected override void OnDisable() => SceneManager.activeSceneChanged -= OnSceneChanged;

    private void OnSceneChanged(Scene previousScene, Scene newScene)
    {
        if (astarPath == null) return;
        astarPath.Scan();
    }
}
