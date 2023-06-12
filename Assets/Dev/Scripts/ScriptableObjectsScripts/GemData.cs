using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObjects/GemData")]
public class GemData : ScriptableObject
{
    [SerializeField] private GemType gemType;
    [SerializeField] private float gemCost;
    [SerializeField] private GameObject gemObject;
    

    public GameObject GemObject => gemObject;
    public GemType GemType => gemType;
    public float GemCost => gemCost;
}
