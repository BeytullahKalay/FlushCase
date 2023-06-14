using System.Collections.Generic;
using UnityEngine;

public class GemDataManager : MonoSingleton<GemDataManager>
{
    [SerializeField] private List<GemData> gemDataList = new List<GemData>();

    public GemData GetRandomGemData => gemDataList[Random.Range(0, gemDataList.Count)];
    public List<GemData> GetGemDataList => gemDataList;
}