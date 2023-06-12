
public interface ICollectible
{
    public GemData GemData { get; }
    public void OnSpawn();
    public void Collect();
    public bool IsCollectible();
}
