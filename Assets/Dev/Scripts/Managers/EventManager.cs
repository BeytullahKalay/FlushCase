using System;

public static class EventManager
{
    public static Action<int> UpdateGoldUI;
    public static Action<GemData> GemCollected;
}
