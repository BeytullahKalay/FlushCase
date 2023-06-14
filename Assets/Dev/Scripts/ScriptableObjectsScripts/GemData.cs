using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObjects/GemData")]
public class GemData : ScriptableObject
{
    [SerializeField] private string gemName;
    [SerializeField] private float gemCost;
    [SerializeField] private GemType gemType;
    [SerializeField] private Sprite gemIcon;
    [SerializeField] private GameObject gemObject;

    public GameObject GemObject => gemObject;
    public GemType GemType => gemType;
    public float GemCost => gemCost;
    public string GemName => gemName;
    public Sprite GemIcon => gemIcon;
}
