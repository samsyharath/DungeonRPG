using System;

public class GameEvents
{
    public static event Action OnstartGame;
    public static event Action OnEndGame;
    public static event Action<int> OnNewEnemyCount;
    public static event Action OnVictory;

    public static void RaiseStartGame() => OnstartGame?.Invoke();
    public static void RaiseEndGame() => OnEndGame?.Invoke();
    public static void RaiseNewEnemyCount(int count) => OnNewEnemyCount?.Invoke(count);
    public static void RaiseVictory() => OnVictory?.Invoke();
    
}