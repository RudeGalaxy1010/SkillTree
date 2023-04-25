using UnityEngine;
using UnityEngine.UI;

public class Starter : MonoBehaviour
{
    [SerializeField] private Counter _pointsCounter;
    [SerializeField] private Button _addPointsButton;

    private Points _points;
    private PointsPresenter _pointsPresenter;

    private void Start()
    {
        _points = new Points();
        _pointsPresenter = new PointsPresenter(_points, _pointsCounter, _addPointsButton);
    }

    private void OnDestroy()
    {
        Deconstruct();
    }

    private void Deconstruct()
    {
        _pointsPresenter.Deconstruct();
    }
}
