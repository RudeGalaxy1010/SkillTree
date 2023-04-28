using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillView : MonoBehaviour
{
    public event Action<SkillData> UnlockButtonCliked;

    [SerializeField] private SkillData _skillData;
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _costText;
    [SerializeField] private Image _preview;
    [SerializeField] private Button _unlockButton;
    [SerializeField] private CanvasGroup _canvasGroup;

    public SkillData SkillData => _skillData;

    private void OnEnable()
    {
        _unlockButton.onClick.AddListener(OnUnlockButtonClicked);
    }

    private void OnDisable()
    {
        _unlockButton.onClick.RemoveListener(OnUnlockButtonClicked);
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

    private void OnUnlockButtonClicked()
    {
        UnlockButtonCliked?.Invoke(_skillData);
    }

    public void UpdateView()
    {
        _canvasGroup.alpha = _skillData.IsUnlocked ? Constants.UnlockedSkillAlpha : Constants.LockedSkillAplpha;
        _nameText.text = _skillData.Name;
        _costText.text = $"{_skillData.Cost}";
        _preview.sprite = _skillData.Preview;
    }
}
