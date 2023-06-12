using DG.Tweening;
using UnityEngine;

public class Gem : MonoBehaviour, ICollectible
{
    public GemData GemData { get; }

    private const float START_SCALE = .1f;
    private const float MIN_HARVES_SCALE = .25f;
    private const float SCALE_TIME = 7f;

    private Tween _tween;

    public void OnSpawn()
    {
        transform.localScale = Vector3.zero * START_SCALE;
        _tween = transform.DOScale(Vector3.one, SCALE_TIME);
    }

    public void Collect()
    {
        _tween?.Kill();
        print("Collect");
    }

    public bool IsCollectible()
    {
        return gameObject.transform.localScale.x > MIN_HARVES_SCALE;
    }
}