using UnityEngine;

public class Tile : MonoBehaviour, ITile
{
    private GemData GemData { get; set; }

    private ICollectible _gem;

    private Transform _gemHolder;

    private void Start()
    {
        _gemHolder = CreateEmptyObjInGameObject();
        
        SpawnNewCollectible();
    }

    public void SpawnNewCollectible()
    {
        GemData = GetRandomGemData();
        var obj = Instantiate(GemData.GemObject, transform.position + Vector3.up, Quaternion.identity, _gemHolder);
        _gem = obj.GetComponent<ICollectible>();
        _gem.OnSpawn();
    }

    private Transform CreateEmptyObjInGameObject()
    {
        var emptyObj = new GameObject("GemHolder");
        emptyObj.transform.SetParent(transform);
        return emptyObj.transform;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _gem.IsCollectible())
        {
            OnCollected();
        }
    }

    public void OnCollected()
    {
        _gem.Collect();

        SpawnNewCollectible();
    }

    private GemData GetRandomGemData()
    {
        return GameManager.Instance.GetRandomGemData;
    }
}