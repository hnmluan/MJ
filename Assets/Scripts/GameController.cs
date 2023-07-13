using UnityEngine;
public enum GameState { FreeRoam, Dialog, Battle, Setting }
public class GameController : InitMonoBehaviour
{
    private static GameController instance;
    public static GameController Instance { get => instance; }

    [SerializeField] protected GameState state = GameState.FreeRoam;
    public GameState State { get => state; }

    [SerializeField] protected GameState previousState = GameState.FreeRoam;

    protected override void Awake()
    {
        base.Awake();
        if (GameController.instance != null) Debug.LogError("Only 1 GameController allow to exist");
        GameController.instance = this;
    }

    protected override void Start()
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
