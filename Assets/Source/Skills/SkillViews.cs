using UnityEngine;

public class SkillViews : MonoBehaviour
{
    [SerializeField] private SkillView[] _skillViews;

    private SkillTree _skillTree;

    public void Construct(SkillTree skillTree)
    {
        _skillTree = skillTree;
        _skillTree.Changed += OnSkillTreeChanged;
    }

    public void Deconstruct()
    {
        if (_skillTree != null)
        {
            _skillTree.Changed -= OnSkillTreeChanged;
        }

        _skillTree = null;
    }

    private void OnSkillTreeChanged()
    {
        // TODO: update view
    }
}
