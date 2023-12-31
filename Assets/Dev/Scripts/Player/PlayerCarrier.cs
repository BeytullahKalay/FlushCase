using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class PlayerCarrier : MonoSingleton<PlayerCarrier>
{
    [SerializeField] private Transform carrierTransform;

    [SerializeField] private float jumpPower = 2f;
    [SerializeField] private float jumpDuration = .25f;

    private List<ICollectible> _collectedList = new List<ICollectible>();

    private float _lastYPos;

    public void Carry(ICollectible collectible)
    {
        // add to collectedList
        _collectedList.Add(collectible);
        
        // set parent
        collectible.CollectibleGameObject.transform.SetParent(carrierTransform);

        // jump animation
        var localScale = collectible.CollectibleGameObject.transform.localScale;
        collectible.CollectibleGameObject.transform.DOLocalJump(Vector3.zero + Vector3.up * (_lastYPos + localScale.x),
            jumpPower, 1, jumpDuration);

        // increase last Y position
        _lastYPos += localScale.x + localScale.x / 2;

        // rotate animation
        collectible.CollectibleGameObject.transform.DOLocalRotate(Vector3.zero, jumpDuration);
    }

    public bool IsCollectedEmpty()
    {
        return _collectedList.Count <= 0;
    }

    public ICollectible GetLastCollectibleOnList()
    {
        var lastCollectible = _collectedList.Last();
        _collectedList.Remove(lastCollectible);
        DecreaseLastYPos(lastCollectible.CollectibleGameObject.transform.localScale.x);
        return lastCollectible;
    }

    private void DecreaseLastYPos(float removingCollectibleScale)
    {
        _lastYPos -= removingCollectibleScale + removingCollectibleScale / 2;
    }
}