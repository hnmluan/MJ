using UnityEngine;
public enum GameState { FreeRoam, Dialog, Battle, Setting }
public class GameManager : Singleton<GameManager>
{
    [SerializeField] protected GameState state = GameState.FreeRoam;
    public GameState State { get => state; }

    [SerializeField] protected GameState previousState = GameState.FreeRoam;
}
