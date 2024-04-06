using System;

public class GameEvents
{
    public static Action OnstartGame;

    public static void RaiseStartGame() => OnstartGame?.Invoke();
}