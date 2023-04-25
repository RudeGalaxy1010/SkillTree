using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void Display(int value)
    {
        _text.text = $"{value}";
    }
}
