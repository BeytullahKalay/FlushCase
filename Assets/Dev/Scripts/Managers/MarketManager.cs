using System;
using UnityEngine;

public class MarketManager : MonoBehaviour
{
    [SerializeField] private int money = 0;

    [SerializeField] private float timeBetweenSells = .1f;

    private float _nextSellTime = float.MinValue;

    private PlayerCarrier _carrier;

    private void Awake()
    {
        _carrier = PlayerCarrier.Instance;
    }

    private void OnTriggerStay(Collider other)
    {
        if (Time.time < _nextSellTime) return;

        if (_carrier.IsCollectedEmpty()) return;

        if (other.CompareTag("Player"))
        {
            SellGem();

            // set next sell time
            _nextSellTime = Time.time + timeBetweenSells;
        }
    }

    private void SellGem()
    {
        var collectible = _carrier.GetLastCollectibleOnList();
        var salePrice = (int)collectible.GemData.GemCost +
                        (int)MathF.Ceiling(collectible.CollectibleGameObject.transform.localScale.x * 100);
        money += salePrice;
        Destroy(collectible.CollectibleGameObject);
    }
}