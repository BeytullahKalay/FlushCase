using System;
using TMPro;
using UnityEngine;

public class GoldShowerUI : MonoBehaviour
{
    [SerializeField] private TMP_Text goldUIText;

    private void Awake()
    {
        CheckPlayerPref();
    }

    private void Start()
    {
        SetText();
    }

    private static void CheckPlayerPref()
    {
        if (!PlayerPrefs.HasKey(PlayerPrefNames.GoldHolder))
        {
            PlayerPrefs.SetInt(PlayerPrefNames.GoldHolder, 0);
        }
    }
    
    private void SetText()
    {
        goldUIText.text = PlayerPrefs.GetInt(PlayerPrefNames.GoldHolder).ToString();
    }

    private void OnEnable()
    {
        EventManager.UpdateGoldUI += UpdateGoldTextUI;
    }

    private void OnDisable()
    {
        EventManager.UpdateGoldUI -= UpdateGoldTextUI;
    }

    private void UpdateGoldTextUI(int increaseAmount)
    {
        var currentGold = PlayerPrefs.GetInt(PlayerPrefNames.GoldHolder);
        PlayerPrefs.SetInt(PlayerPrefNames.GoldHolder,(currentGold + increaseAmount));
        SetText();
    }
}
