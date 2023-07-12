using UnityEngine;
public enum GameState { FreeRoam, Dialog, Battle, Setting }
public class GameController : MonoBehaviour
{
    [SerializeField] protected GameState state = GameState.FreeRoam;

    [SerializeField] protected GameState previousState = GameState.FreeRoam;

    private void Start()
    {
        DialogCtrl.Instance.OnShowDialog += () =>
        {
            previousState = state;
            state = GameState.Dialog;
        };

        DialogCtrl.Instance.OnHideDialog += () =>
        {
            if (state == GameState.Dialog)
            {
                state = GameState.FreeRoam;
            }
            previousState = GameState.Dialog;
        };

        UIMenuCtrl.Instance.OnShowSetting += () =>
        {
            previousState = state;
            state = GameState.Setting;
        };

        UIMenuCtrl.Instance.OnHideSetting += () =>
        {
            if (state == GameState.Setting)
                if (previousState == GameState.Dialog)
                    state = GameState.Dialog;
                else
                    state = GameState.FreeRoam;
            previousState = GameState.Setting;
        };
    }

    private void Update()
    {
        if (state == GameState.FreeRoam)
        {
        }
        else if (state == GameState.Dialog)
        {
            DialogCtrl.Instance.HandleUpdate();
        }
        else if (state == GameState.Setting)
        {
        }
        else if (state == GameState.Battle)
        {

        }
    }
}
