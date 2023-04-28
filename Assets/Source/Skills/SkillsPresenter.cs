using System;
using System.Linq;

public class SkillsPresenter
{
    public event Action SkillsUpdated;

    private SkillSelector _skillSelector;
    private SkillData[] _skillsData;
    private Points _points;

    public SkillsPresenter Construct(SkillSelector skillSelector, SkillData[] skillsData, Points points)
    {
        _points = points;
        _skillsData = skillsData;
        _skillSelector = skillSelector;
        SubscribeAll();
        return this;
    }

    public bool CanUnlockSkill(SkillData skillData) => skillData.IsUnlocked == false
            && skillData.HasUnlockedPaths() == true
            && _points.TrySpend(skillData.Cost) == true;
    public bool CanLockSkill(SkillData skillData) => skillData.IsRoot == false 
            && skillData.IsUnlocked == true
            && _skillsData.Any(d => d.IsUnlocked == true
                    && d.IsDirectlyDependsOn(skillData) == true
                    && SkillHasSinglePath(d) == true) == false;

    private bool SkillHasSinglePath(SkillData skillData) => skillData.GetUnlockedPathsCount() == 1;

    public void Deconstruct()
    {
        UnsubscribeAll();
        _skillsData = null;
        _skillSelector = null;
        _points = null;
    }

    private void SubscribeAll()
    {
        _skillSelector.OnUnlockButtonClicked += OnUnlockButtonClicked;
        _skillSelector.OnLockButtonClicked += OnLockButtonClicked;
        _skillSelector.OnLockAllButtonClicked += OnLockAllButtonClicked;
    }

    private void UnsubscribeAll()
    {
        _skillSelector.OnUnlockButtonClicked -= OnUnlockButtonClicked;
        _skillSelector.OnLockButtonClicked -= OnLockButtonClicked;
        _skillSelector.OnLockAllButtonClicked -= OnLockAllButtonClicked;
    }

    private void OnUnlockButtonClicked(SkillData skillData)
    {
        if (skillData == null)
        {
            return;
        }

        TryUnlockSkill(skillData);
    }

    private void OnLockButtonClicked(SkillData skillData)
    {
        if (skillData == null)
        {
            return;
        }

        TryLockSkill(skillData);
    }

    private void OnLockAllButtonClicked()
    {
        for (int i = 0; i < _skillsData.Length; i++)
        {
            if (_skillsData[i].IsRoot == true)
            {
                continue;
            }

            if (_skillsData[i].IsUnlocked == true)
            {
                _points.Add(_skillsData[i].Cost);
            }

            _skillsData[i].IsUnlocked = false;
        }

        SkillsUpdated?.Invoke();
    }

    private void TryUnlockSkill(SkillData skillData)
    {
        if (CanUnlockSkill(skillData) == false)
        {
            return;
        }

        skillData.IsUnlocked = true;
        SkillsUpdated?.Invoke();
    }

    private void TryLockSkill(SkillData skillData)
    {
        if (CanLockSkill(skillData) == false)
        {
            return;
        }

        skillData.IsUnlocked = false;
        _points.Add(skillData.Cost);
        SkillsUpdated?.Invoke();
    }
}
