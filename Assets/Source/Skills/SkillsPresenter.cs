using System.Linq;

public class SkillsPresenter
{
    private SkillView[] _skillViews;
    private Points _points;

    public SkillsPresenter Construct(SkillView[] skillViews, Points points)
    {
        _points = points;
        _skillViews = skillViews;
        SubscribeAll();
        return this;
    }

    public void Deconstruct()
    {
        UnsubscribeAll();
        _skillViews = null;
    }

    private void SubscribeAll()
    {
        for (int i = 0; i < _skillViews.Length; i++)
        {
            _skillViews[i].UnlockButtonCliked += OnUnlockButtonClicked;
        }
    }

    private void UnsubscribeAll()
    {
        if (_skillViews != null)
        {
            for (int i = 0; i < _skillViews.Length; i++)
            {
                _skillViews[i].UnlockButtonCliked -= OnUnlockButtonClicked;
            }
        }
    }

    private void OnUnlockButtonClicked(SkillData skillData)
    {
        if (skillData.IsUnlocked == true)
        {
            TryLockSkill(skillData);
            return;
        }

        TryUnlockSkill(skillData);
    }

    private void TryUnlockSkill(SkillData skillData)
    {
        if (skillData.IsUnlocked == true
            || skillData.HasUnlockedPaths() == false
            || _points.TrySpend(skillData.Cost) == false)
        {
            return;
        }

        skillData.IsUnlocked = true;
        UpdateView();
    }

    private void TryLockSkill(SkillData skillData)
    {
        if (_skillViews.Select(s => s.SkillData).Any(d => d.IsUnlocked == true
                && d.IsDirectlyDependsOn(skillData) == true
                && d.GetUnlockedPathsCount() <= 1))
        {
            return;
        }

        skillData.IsUnlocked = false;
        _points.Add(skillData.Cost);
        UpdateView();
    }

    private void UpdateView()
    {
        for (int i = 0; i < _skillViews.Length; i++)
        {
            _skillViews[i].UpdateView();
        }
    }
}
