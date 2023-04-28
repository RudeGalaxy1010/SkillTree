using UnityEngine;
using UnityEngine.UI;

public class Starter : MonoBehaviour
{
    [Header("Points")]
    [SerializeField] private Counter _pointsCounter;
    [SerializeField] private Button _addPointsButton;

    [Header("Skills")]
    [SerializeField] private SkillData[] _skillsData;
    [SerializeField] private SkillView[] _skillViews;

    private Points _points;
    private PointsPresenter _pointsPresenter;
    private SkillsPresenter _skillsPresenter;

    private void Start()
    {
        InitPoints(_pointsCounter, _addPointsButton);
        InitSkills(_points);
    }

    private void InitPoints(Counter pointsCounter, Button addPointsButton)
    {
        _points = new Points();
        _pointsPresenter = new PointsPresenter().Construct(_points, pointsCounter, addPointsButton);
    }

    private void InitSkills(Points points)
    {
        _skillsPresenter = new SkillsPresenter().Construct(_skillViews, points);
    }

    private void OnDestroy()
    {
        Deconstruct();
    }

    private void Deconstruct()
    {
        _pointsPresenter.Deconstruct();
        _skillsPresenter.Deconstruct();
    }
}
