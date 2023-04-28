using System;

public class SkillTree
{
    public event Action Changed;

    private SkillData[] _skillsData;

    public SkillTree(SkillData[] skillsData)
    {
        _skillsData = skillsData;
        // TODO: init connections
        Changed?.Invoke();
    }
}
