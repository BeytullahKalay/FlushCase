using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private List<GemData> GemDatas = new List<GemData>();

    public GemData GetRandomGemData => GemDatas[Random.Range(0, GemDatas.Count - 1)];
}