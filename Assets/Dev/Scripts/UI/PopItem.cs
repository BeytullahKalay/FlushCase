using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopItem : MonoBehaviour
{
    [SerializeField] private Image gemImage;
    [SerializeField] private TMP_Text gemTypeName;
    [SerializeField] private TMP_Text gemCount;
    
    private GemData _gemData;

    public GemData GemData => _gemData;

    public void Initialize(GemData comingGemData)
    {
        _gemData = comingGemData;
        
        gemImage.sprite = _gemData.GemIcon;
        gemTypeName.text = _gemData.GemName;
        gemCount.text = "0";
    }

    public void UpdateItem()
    {
        gemCount.text = PlayerPrefs.GetInt(_gemData.GemType.ToString()).ToString();
    }
}
