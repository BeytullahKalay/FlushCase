using DG.Tweening;
using UnityEngine;

public class Gem : MonoBehaviour, ICollectible
{
    public GemData GemData { get; set; }
    public GameObject CollectibleGameObject { get; set; }

    private const float START_SCALE = 0;
    private const float MIN_HARVES_SCALE = .25f;
    private const float SCALE_TIME = 5f;

    private Tween _tween;

    private void Awake()
    {
        CollectibleGameObject = gameObject;
    }

    public void Initialize(GemData data)
    {
        transform.localScale = Vector3.zero * START_SCALE;
        _tween = transform.DOScale(Vector3.one, SCALE_TIME);
        GemData = data;
    }

    public void Collect()
    {
        _tween?.Kill();
        PlayerCarrier.Instance.Carry(this);
    }

    public bool IsCollectible()
    {
        return CollectibleGameObject.transform.localScale.x > MIN_HARVES_SCALE;
    }
}