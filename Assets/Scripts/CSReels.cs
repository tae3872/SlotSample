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
    public CSFreeGamePanel freeGamePanel;
    public HorizontalScrollSnap scrollView;
    public CSTopPanel topPanel;
    public CSAlertRewardAnim rewardAlert;
    [HideInInspector] public CSReel[] reels;
    private Vector2 _tileSize;
    protected bool _autoSpin;
    private CSReelAutoSpin _stateAutoSpin;
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
            if (!_freeGame && !_autoSpin)
            {
            }
        }
    }
    protected CSReelsAnimation _reelAnimation;
    protected bool _freeGame;

    public bool freeGame
    {
        get { return _freeGame; }
        set
        {
            if (_freeGame == value)
                return;
            _freeGame = value;

            if (FreeGameValueChangedEvent != null)
            {
                FreeGameValueChangedEvent(value);
            }
        }
    }
    private void Start()
    {

    }
}
