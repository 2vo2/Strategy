using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SelectableObject : MonoBehaviour
{
    [SerializeField] protected GameObject _indecator;
    protected ISelect _selectBehaviour;
    protected IHover _hoverBehaviour;

    protected void SetSelectBehaviour(ISelect selectBehaviour) => _selectBehaviour = selectBehaviour;

    protected void SetHoverBehaviour(IHover hoverBehaviour) => _hoverBehaviour = hoverBehaviour;

    public void OnSelect() => _selectBehaviour.Select();

    public void OnUnselect() => _selectBehaviour.Unselect();

    public void OnHover() => _hoverBehaviour.Hover();

    public void OnUnhover() => _hoverBehaviour.Unhover();

    public virtual void MoveToPoitOnGround(Vector3 point){}
}