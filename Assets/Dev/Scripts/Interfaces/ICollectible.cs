
using UnityEngine;

public interface ICollectible
{
    public GameObject CollectibleGameObject { get; }
    public GemData GemData { get; }
    public void Initialize(GemData data);
    public void Collect();
    public bool IsCollectible();
}
