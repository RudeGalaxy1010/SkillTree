using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Skill Data", fileName = "New skill data")]
public class SkillData : ScriptableObject
{
    public string Name;
    public int Cost;
    public Sprite Preview;
    public bool IsUnlocked;
    public bool IsRoot;
    public SkillData[] Requirements;
}
