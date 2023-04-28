using System.Linq;

public static class SkillDataExtensions
{
    public static bool HasUnlockedPaths(this SkillData skillData)
    {
        return skillData.Requirements.Any(r => r.IsUnlocked == true);
    }

    public static int GetUnlockedPathsCount(this SkillData skillData)
    {
        return skillData.Requirements.Where(r => r.IsUnlocked == true).Count();
    }

    public static bool IsDirectlyDependsOn(this SkillData skillData, SkillData skillDataToCheck)
    {
        return skillData.Requirements.Contains(skillDataToCheck);
    }

    public static bool IsDependencyInUnlockedSkill(this SkillData skillData, SkillData[] skillDataToCheck)
    {
        return skillDataToCheck.Any(d => d.IsUnlocked == true 
            && d != skillData 
            && d.Requirements.Contains(skillData));
    }
}
