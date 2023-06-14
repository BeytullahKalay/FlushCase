using DG.Tweening;
using UnityEngine;

public class Gem : MonoBehaviour, ICollectible
{
    public GemData GemData { get; set; }
    public GameObject CollectibleGameObject { get; set; }

    private const float START_SCALE = 0;
    private const float MIN_HARVES_SCALE = .25f;
    private const float SCALE_TIME = 5f;

    private Tween _scaleTween;
    private Tween _rotateTween;

    private void Awake()
    {
        CollectibleGameObject = gameObject;
    }

    public void Initialize(GemData data)
    {
        transform.localScale = Vector3.zero * START_SCALE;
        _scaleTween = transform.DOScale(Vector3.one, SCALE_TIME);
        _rotateTween = transform.DOLocalRotate(Vector3.up * 360, 5f, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
        GemData = data;
    }

    public void Collect()
    {
        _scaleTween?.Kill();
        _rotateTween?.Kill();
        PlayerCarrier.Instance.Carry(this);
    }

    public bool IsCollectible()
    {
        return CollectibleGameObject.transform.localScale.x > MIN_HARVES_SCALE;
    }
}