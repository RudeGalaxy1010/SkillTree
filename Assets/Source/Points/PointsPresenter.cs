using UnityEngine.UI;

public class PointsPresenter
{
    private Points _points;
    private Counter _counter;
    private Button _addPointsButton;

    public PointsPresenter Construct(Points points, Counter counter, Button addPointsButton)
    {
        _points = points;
        _counter = counter;
        _addPointsButton = addPointsButton;
        SubscribeAll();
        return this;
    }

    private void SubscribeAll()
    {
        _points.Changed += OnPointsChanged;
        _addPointsButton.onClick.AddListener(OnAddPointsButtonClick);
    }

    private void UnsubscribeAll()
    {
        _points.Changed -= OnPointsChanged;
        _addPointsButton.onClick.RemoveListener(OnAddPointsButtonClick);
    }

    private void OnPointsChanged(int value)
    {
        _counter.Display(value);
    }

    private void OnAddPointsButtonClick()
    {
        _points.Add(Constants.PointsToAdd);
    }

    public void Deconstruct()
    {
        UnsubscribeAll();
        _points = null;
        _counter = null;
        _addPointsButton = null;
    }
}
