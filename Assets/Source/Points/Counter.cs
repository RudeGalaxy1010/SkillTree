using DG.Tweening;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private ScaleAnimation _scaleAnimation;

    public void Display(int value)
    {
        _text.text = $"{value}";
        _scaleAnimation.Stop();
        _scaleAnimation.PlayOnce();
    }
}
