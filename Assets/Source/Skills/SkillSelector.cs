using System;
using UnityEngine;
using UnityEngine.UI;

public class SkillSelector : MonoBehaviour
{
    public event Action<SkillData> OnUnlockButtonClicked;
    public event Action<SkillData> OnLockButtonClicked;
    public event Action OnLockAllButtonClicked;

    [SerializeField] private SkillView[] _skillViews;
    [SerializeField] private Button _unlockButton;
    [SerializeField] private Button _lockButton;
    [SerializeField] private Button _lockAllButton;

    private SkillsPresenter _skillsPresenter;
    private SkillData _selectedSkillData;

    public void Construct(SkillsPresenter skillsPresenter)
    {
        _skillsPresenter = skillsPresenter;
        SubscribeAll();
    }

    public void Deconstruct()
    {
        UnsubscribeAll();
        _skillsPresenter = null;
    }

    private void SubscribeAll()
    {
        for (int i = 0; i < _skillViews.Length; i++)
        {
            _skillViews[i].SelectButtonCliked += OnSkillSelected;
        }

        _unlockButton.onClick.AddListener(OnUnlockButtonClick);
        _lockButton.onClick.AddListener(OnLockButtonClick);
        _lockAllButton.onClick.AddListener(OnLockAllButtonClick);
        _skillsPresenter.SkillsUpdated += OnSkillsUpdated;
    }

    private void UnsubscribeAll()
    {
        for (int i = 0; i < _skillViews.Length; i++)
        {
            _skillViews[i].SelectButtonCliked -= OnSkillSelected;
        }

        _unlockButton.onClick.RemoveListener(OnUnlockButtonClick);
        _lockButton.onClick.RemoveListener(OnLockButtonClick);
        _lockAllButton.onClick.RemoveListener(OnLockAllButtonClick);

        if (_skillsPresenter != null)
        {
            _skillsPresenter.SkillsUpdated -= OnSkillsUpdated;
        }
    }

    private void OnSkillSelected(SkillData skillData)
    {
        _selectedSkillData = skillData;
        UpdateViews();
    }

    private void OnSkillsUpdated()
    {
        UpdateViews();
    }

    private void UpdateViews()
    {
        for (int i = 0; i < _skillViews.Length; i++)
        {
            _skillViews[i].UpdateView(_skillViews[i].SkillData == _selectedSkillData);
        }
    }

    private void OnUnlockButtonClick()
    {
        OnUnlockButtonClicked?.Invoke(_selectedSkillData);
    }

    private void OnLockButtonClick()
    {
        OnLockButtonClicked?.Invoke(_selectedSkillData);
    }

    private void OnLockAllButtonClick()
    {
        OnLockAllButtonClicked?.Invoke();
    }
}
