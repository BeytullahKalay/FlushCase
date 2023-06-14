using System.Collections.Generic;
using UnityEngine;

public class GemCounterManager : MonoBehaviour
{
    [SerializeField] private Transform contentTransform;
    [SerializeField] private GameObject templateItemPrefab;

    private List<PopItem> _canvasItems = new List<PopItem>();
    
    private void Awake()
    {
        CheckItems();
    }

    private void OnEnable()
    {
        EventManager.GemCollected += OnGemCollected;
    }

    private void OnDisable()
    {
        EventManager.GemCollected -= OnGemCollected;
    }

    private void CheckItems()
    {
        foreach (var gemData in GemDataManager.Instance.GetGemDataList)
        {
            if (!PlayerPrefs.HasKey(gemData.GemType.ToString()))
            {
                PlayerPrefs.SetInt(gemData.GemType.ToString(), 0);
            }
            else if(PlayerPrefs.GetInt(gemData.GemType.ToString()) > 0)
            {
                InitializeNewCanvasItem(gemData);
                CallUpdateTmp(gemData);
            }
        }
    }

    private void OnGemCollected(GemData comingGemData)
    {
        if (PlayerPrefs.GetInt(comingGemData.GemType.ToString()) == 0)
        {
            PlayerPrefs.SetInt(comingGemData.GemType.ToString(), 1);
            InitializeNewCanvasItem(comingGemData);
        }
        else
        {
            IncreaseGemData(comingGemData);
        }

        CallUpdateTmp(comingGemData);
    }
    
    private void InitializeNewCanvasItem(GemData comingGemData)
    {
        var newCanvasItem = Instantiate(templateItemPrefab, contentTransform);
        if (newCanvasItem.TryGetComponent<PopItem>(out var popItemScript))
        {
            popItemScript.Initialize(comingGemData);
            _canvasItems.Add(popItemScript);
        }
    }

    private void IncreaseGemData(GemData comingGemData)
    {
        foreach (var item in _canvasItems)
        {
            if (item.GemData != comingGemData) continue;
                
            var currentAmount = PlayerPrefs.GetInt(item.GemData.GemType.ToString());
            PlayerPrefs.SetInt(item.GemData.GemType.ToString(), (currentAmount + 1));
        }
    }

    private void CallUpdateTmp(GemData comingGemData)
    {
        foreach (var item in _canvasItems)
        {
            if (item.GemData == comingGemData)
                item.UpdateItem();
        }
    }
}