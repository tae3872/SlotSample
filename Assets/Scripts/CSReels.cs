using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public interface IFreeGame
{
    void FreeGameValueChanged(bool value);
}

public abstract class CSReels : MonoBehaviour
{
    public event System.Action<bool> FreeGameValueChangedEvent;
    public GameObject reel;
    public CSLine[] lines;
    public HorizontalScrollSnap scrollView;
    [HideInInspector] public 
}
