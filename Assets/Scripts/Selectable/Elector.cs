using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum SelectionState
{
    UnitsSelected,
    Frame,
    Other
}

public class Elector : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Highlighter _highlighter;
    [SerializeField] private Image _frame;

    private List<SelectableObject> _listOfSelected = new List<SelectableObject>(); 
    private SelectableObject _selected;
    private SelectionState _currentSelectionState;
    private Vector2 _frameStart;
    private Vector2 _frameEnd;

    private void Start() 
    {
        _frame.gameObject.SetActive(false);    
    }

    private void Update() 
    {
        _selected = _highlighter.Hovered;

        if(Input.GetMouseButtonUp(0))
        {
            if(_selected)
            {
                if(Input.GetKey(KeyCode.LeftControl) == false)
                {
                    UnselectAll();
                }

                _currentSelectionState = SelectionState.UnitsSelected;
                Select(_selected);
            }

        }

        if(_currentSelectionState == SelectionState.UnitsSelected)
        {
            if(Input.GetMouseButtonUp(0))
            {
                if(_highlighter.Hit.collider.TryGetComponent(out Ground ground))
                {
                    int rowNumber = Mathf.CeilToInt(Mathf.Sqrt(_listOfSelected.Count));

                    for (int i = 0; i < _listOfSelected.Count; i++)
                    {
                        int row = i / rowNumber;
                        int column = i % rowNumber;

                        Vector3 point = _highlighter.Hit.point + new Vector3(row, 0f, column);

                        _listOfSelected[i].MoveToPoitOnGround(point);
                    }
                }
            }
        }

        if(Input.GetMouseButtonDown(1))
            UnselectAll();

        Frame();
    }

    private void Select(SelectableObject selectableObject)
    {
        if(_listOfSelected.Contains(selectableObject) == false)
        {
            _listOfSelected.Add(selectableObject);
            selectableObject.OnSelect();
        } 
    }

    private void UnselectAll()
    {
        for (int i = 0; i < _listOfSelected.Count; i++)
        {
            _listOfSelected[i].OnUnselect();
        }
        _listOfSelected.Clear();
        _currentSelectionState = SelectionState.Other;
    }

    private void Frame()
    {
        if(Input.GetMouseButtonDown(0))
            _frameStart = Input.mousePosition;

        if(Input.GetMouseButton(0))
        {
            _frameEnd = Input.mousePosition;
            
            Vector2 min = Vector2.Min(_frameStart, _frameEnd);
            Vector2 max = Vector2.Max(_frameStart, _frameEnd);

            Vector2 size = max - min;

            if(size.magnitude > 10)
            { 
                _frame.gameObject.SetActive(true);

                _frame.rectTransform.anchoredPosition = min;
                _frame.rectTransform.sizeDelta = size;

                Rect rect = new Rect(min, size);

                UnselectAll();
                Unit[] allUnits = FindObjectsOfType<Unit>();
                for (int i = 0; i < allUnits.Length; i++)
                {
                    Vector2 screenPosition = _mainCamera.WorldToScreenPoint(allUnits[i].transform.position);
                    if(rect.Contains(screenPosition))
                        Select(allUnits[i]);
                }
                
                _currentSelectionState = SelectionState.Frame;
            }          
        }

        if(Input.GetMouseButtonUp(0))
        {
            _frame.gameObject.SetActive(false);
            if(_listOfSelected.Count > 0)
                _currentSelectionState = SelectionState.UnitsSelected;
            else
                _currentSelectionState = SelectionState.Other;
        }
    }
}
