using DG.Tweening;
using UnityEngine;

public class ScaleAnimation : MonoBehaviour
{
    [SerializeField] private float _endScale;
    [SerializeField] private float _duration;

    private Tween _tween;
    private float _scaleEndValue;

    private void Awake()
    {
        _scaleEndValue = transform.localScale.x * _endScale;
        _duration = _duration / 2f; // Scale and return to default takes double time
    }

    public void PlayOnce()
    {
        Play(2);
    }

    public void PlayInfinite()
    {
        Play(-1);
    }

    public void Stop()
    {
        _tween.Rewind();
        _tween.Kill();
    }

    private void Play(int loops)
    {
        _tween = transform.DOScale(_scaleEndValue, _duration).SetLoops(loops, LoopType.Yoyo);
        _tween.Play();
    }
}
