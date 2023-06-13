using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerCarrier : MonoSingleton<PlayerCarrier>
{
    [SerializeField] private Transform carrierTransform;

    [SerializeField] private float jumpPower = 2f;
    [SerializeField] private float jumpDuration = .25f;

    private List<ICollectible> _collectedList = new List<ICollectible>();

    public void Carry(ICollectible collectible)
    {
        // add to collectedList
        _collectedList.Add(collectible);


        // set parent
        collectible.CollectibleGameObject.transform.SetParent(carrierTransform);

        // jump animation
        collectible.CollectibleGameObject.transform.DOLocalJump(
            Vector3.zero + Vector3.up * (_collectedList.Count - 1), jumpPower, 1, jumpDuration);
        
        // rotate animation
        collectible.CollectibleGameObject.transform.DOLocalRotate(Vector3.zero, jumpDuration);
    }
}