using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverUnit : IHover
{
    private Transform _transform;
    private Animator _animator;

    public HoverUnit(Transform transform, Animator animator)
    {
        _transform = transform;
        _animator = animator;
    } 

    public void Hover()
    {
        _transform.localScale = new Vector3(1f, 1.1f, 1f);
        _animator.SetBool("Hover", true);
    }

    public void Unhover()
    {
        _transform.localScale = new Vector3(1f, 1f, 1f);
        _animator.SetBool("Hover", false);
    }
}
