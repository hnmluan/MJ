using UnityEngine;
public enum GameState { FreeRoam, Dialog, Battle, Setting }
public class GameManager : Singleton<GameManager>
{
    private static GameManager instance;
    public static GameManager Instance { get => instance; }

    [SerializeField] protected GameState state = GameState.FreeRoam;
    public GameState State { get => state; }

    [SerializeField] protected GameState previousState = GameState.FreeRoam;

    protected override void Awake()
    {
        base.Awake();
        if (GameManager.instance != null) Debug.Log("Only 1 GameManager allow to exist");
        GameManager.instance = this;
    }

    protected override void Start()
    {
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
