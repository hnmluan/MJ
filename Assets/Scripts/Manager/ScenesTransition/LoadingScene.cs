using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Scenes
{
    NoScene = 0,
    StartGameMenu = 1,
    CutScene = 2,
    MainScene = 3,
    VillageElderHouseScene = 4
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
            await System.Threading.Tasks.Task.Delay(100);
            loadingProcess.value = scene.progress;
            processText.text = scene.progress * 100 + " %";
        } while (scene.progress < 0.9f);

        await System.Threading.Tasks.Task.Delay(1000);

        scene.allowSceneActivation = true;
        loadingUI.SetActive(false);

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) player.transform.position = position;
    }
}
