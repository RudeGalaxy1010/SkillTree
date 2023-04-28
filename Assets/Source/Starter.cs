using UnityEngine;
using UnityEngine.UI;

public class Starter : MonoBehaviour
{
    [Header("Points")]
    [SerializeField] private Counter _pointsCounter;
    [SerializeField] private Button _addPointsButton;

    [Header("Skills")]
    [SerializeField] private SkillData[] _skillsData;
    [SerializeField] private SkillViews _skillsViews;

    private Points _points;
    private PointsPresenter _pointsPresenter;

    private SkillTree _skillTree;

    private void Start()
    {
        InitPoints();
        InitSkills();
    }

    private void InitPoints()
    {
        _points = new Points();
        _pointsPresenter = new PointsPresenter().Construct(_points, _pointsCounter, _addPointsButton);
    }

    private void InitSkills()
    {
        _skillTree = new SkillTree(_skillsData);
        _skillsViews.Construct(_skillTree);
    }

    private void OnDestroy()
    {
        Deconstruct();
    }

    private void Deconstruct()
    {
        _pointsPresenter.Deconstruct();
        _skillsViews.Deconstruct();
    }
}
