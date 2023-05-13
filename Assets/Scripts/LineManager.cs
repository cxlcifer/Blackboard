using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LineManager : MonoBehaviour
{
    [SerializeField] private Line _linePrefab;
    [SerializeField] private Transform _parent;
    private Line _currentLine;
    public List<Line> _lines = new();

    public Color _currentButtonColor;
    
    public void SpawnLine()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _currentLine = Instantiate(_linePrefab, mousePos, Quaternion.identity,_parent);
        _currentButtonColor = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color;
        _currentLine.GetComponent<LineRenderer>().startColor = _currentButtonColor;
        _currentLine.GetComponent<LineRenderer>().endColor = _currentButtonColor;
        _lines.Add(_currentLine);
    }

    public void ClearBoard()
    {
        for (int i = 0; i < _lines.Count; i++)
        {
            _lines[i].GetComponent<LineRenderer>().positionCount = 0;
        }
        
    }
}
