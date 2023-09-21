using UnityEditor;
using UnityEngine;

public class QuitGameHelper : MonoBehaviour
{
    public void QuitGame() => this.Quit();

    private void Quit() => ConfirmPanel.Ask("Are you sure you want to quit game?", QuitImediately);

    private static void QuitImediately()
    {
        EventManager.RaiseEvent("OnGameSave");
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
