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
    public CSBottomPanel basePanel;
    public CSFreeGamePanel
    public HorizontalScrollSnap scrollView;
    [HideInInspector] public CSReel[] reels;
    private Vector2 _tileSize;
    protected bool _autoSpin;
    //private

    public bool autoSpin
    {
        get { return _autoSpin; }
    }
    private bool _enable;

    public bool enable
    {
        get { return _enable; }
        set
        {
            if (_enable == value)
                return;
            _enable = value;
            //if (!_freegame && !_autoSpin)
            //{
            //    basePanel.Set
            //}
        }
    }
    protected CSReelsAnimation _reelAnimation;
    protected bool _freeGame;
    private void Start()
    {
        
    }
}
