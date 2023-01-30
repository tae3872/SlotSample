using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CSReels))]

public class CSReelAutoSpin : MonoBehaviour
{
    public Sprite normalSprite;
    public SpriteState state;
    public float holdDuration = 1.1f;

    private float _startTime;
    private bool _start;
    private CSReels _reels;

    private void Awake()
    {
        _reels= GetComponent<CSReels>();
    }
    private void Update()
    {
        if (!_start || _reels.autoSpin)
            return;
        float delta = Time.time - _startTime;
        if (delta < holdDuration)
            return;
        _reels.Set
    }
}
