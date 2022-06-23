using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ButtonFactory<T> : MonoBehaviour where T : MonoBehaviour
{
    public abstract T ButtonLogic();
}
