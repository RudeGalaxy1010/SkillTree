using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillView : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _costText;
    [SerializeField] private Image _preview;

    public void Display(SkillData skillData)
    {
        _nameText.text = skillData.Name;
        _costText.text = $"{skillData.Cost}";
        _preview.sprite = skillData.Preview;
    }
}
