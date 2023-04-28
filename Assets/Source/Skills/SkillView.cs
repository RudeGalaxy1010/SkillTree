using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillView : MonoBehaviour
{
    public event Action<SkillData> SelectButtonCliked;

    [SerializeField] private SkillData _skillData;
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _costText;
    [SerializeField] private Image _preview;
    [SerializeField] private Button _selectButton;
    [SerializeField] private GameObject _selectionFrame;
    [SerializeField] private CanvasGroup _canvasGroup;

    public SkillData SkillData => _skillData;

    private void OnEnable()
    {
        _selectButton.onClick.AddListener(OnSelectButtonClicked);
    }

    private void OnDisable()
    {
        _selectButton.onClick.RemoveListener(OnSelectButtonClicked);
    }

    private void OnValidate()
    {
        if (_skillData != null)
        {
            UpdateView();
        }
    }

    private void Start()
    {
        UpdateView();
    }

    private void OnSelectButtonClicked()
    {
        SelectButtonCliked?.Invoke(_skillData);
    }

    public void UpdateView(bool isSelected = false)
    {
        _canvasGroup.alpha = _skillData.IsUnlocked ? Constants.UnlockedSkillAlpha : Constants.LockedSkillAplpha;
        _nameText.text = _skillData.Name;
        _costText.text = $"{_skillData.Cost}";
        _preview.sprite = _skillData.Preview;
        _selectionFrame.SetActive(isSelected);
    }
}
