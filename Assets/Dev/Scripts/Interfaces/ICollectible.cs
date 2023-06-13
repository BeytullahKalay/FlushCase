
using UnityEngine;

public interface ICollectible
{
    public GameObject CollectibleGameObject { get; }
    public GemData GemData { get; }
    public void OnSpawn();
    public void Collect();
    public bool IsCollectible();
}
