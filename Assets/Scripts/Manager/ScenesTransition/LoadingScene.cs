using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Scenes
{
    NoScene = 0,
    A_Scence = 1,
    A_to_B_1_Scence = 2,
    A_to_B_2_Scence = 3,
    A_to_B_3_Scence = 4,
    A_to_B_4_Scence = 5,
    VillageElderHouse = 6,
}

public class LoadingScene : Singleton<LoadingScene>
{
    [SerializeField] private GameObject loadingUI;

    [SerializeField] private Slider loadingProcess;

    [SerializeField] private Text processText;

    public async void LoadScence(Scenes name, Vector3 position)
    {
        var scene = SceneManager.LoadSceneAsync(name.ToString());
        scene.allowSceneActivation = false;

        loadingUI.SetActive(true);

        do
        {
            await Task.Delay(100);
            loadingProcess.value = scene.progress;
            processText.text = scene.progress * 100 + " %";
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
        AstarPath astarPath = FindObjectOfType<AstarPath>();
        if (astarPath == null) return;
        astarPath.Scan();
    }
}
