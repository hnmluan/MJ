using UnityEngine;
public enum GameState { FreeRoam, Dialog, Battle, Setting }
public class GameManager : InitMonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get => instance; }

    [SerializeField] protected GameState state = GameState.FreeRoam;
    public GameState State { get => state; }

    [SerializeField] protected GameState previousState = GameState.FreeRoam;

    protected override void Awake()
    {
        base.Awake();
        if (GameManager.instance != null) Debug.LogError("Only 1 GameManager allow to exist");
        GameManager.instance = this;
    }

    protected override void Start()
    {
        UIDialog.Instance.OnShowDialog += () =>
        {
            previousState = state;
            state = GameState.Dialog;
        };

        UIDialog.Instance.OnHideDialog += () =>
        {
            if (state == GameState.Dialog)
            {
                state = GameState.FreeRoam;
            }
            previousState = GameState.Dialog;
        };

        UICtrl.Instance.OnShowSetting += () =>
        {
            previousState = state;
            state = GameState.Setting;
        };

        UICtrl.Instance.OnHideSetting += () =>
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
        switch (state)
        {
            case GameState.Dialog:
                UIDialog.Instance.HandleUpdate();
                break;
            case GameState.FreeRoam:
                break;
            case GameState.Battle:
                break;
            case GameState.Setting:
                break;
        }
    }
}
