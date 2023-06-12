using UnityEngine;

public class Tile : MonoBehaviour, ITile
{
    public GemData GemData { get; set; }
    
    private ICollectible _gem;

    private void Start()
    {
        SpawnNewCollectible();
    }

    public void SpawnNewCollectible()
    {
        GemData = GetRandomGemData();

        var emptyObj = CreateEmptyObjInGameObject();

        var obj = Instantiate(GemData.GemObject, transform.position + Vector3.up, Quaternion.identity,emptyObj);
        
        _gem = obj.GetComponent<ICollectible>();
        
        _gem.OnSpawn();

    }

    private Transform CreateEmptyObjInGameObject()
    {
        var emptyObj = new GameObject("GemHolder");
        emptyObj.transform.SetParent(transform);
        return emptyObj.transform;
    }

    public void OnCollected()
    {
        SpawnNewCollectible();
        
        _gem.Collect();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _gem.IsCollectible())
        {
            _gem.Collect();
        }
    }

    private GemData GetRandomGemData()
    {
        return GameManager.Instance.GetRandomGemData;
    }
}