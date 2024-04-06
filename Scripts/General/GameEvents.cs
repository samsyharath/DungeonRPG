using System;

public class GameEvents
{
    public static event Action OnstartGame;
    public static event Action OnEndGame;

    public static void RaiseStartGame() => OnstartGame?.Invoke();
    public static void RaiseEndGame() => OnEndGame?.Invoke();
    
}