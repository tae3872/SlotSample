using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CSAlert : MonoBehaviour
{
    public ParticleSystem fireworks;
    public RectTransform ribbon;
    public Transform title;
    public Transform board;
    public CanvasGroup canvas;
    public CanvasGroup innerCanvas;

    private GameObject _title;
    protected GameObject _board;
    private float _ribbonWidth;
    private Image _image;
    private GameObject _particle;
    private CSGlowAnimation _glowScript;

    private Vector3 _titleShowPosition;
    private Vector3 _boardShowPosition;

    private bool _active;
    public bool active
    {
        get { return _active; }
        set
        {
            if (value == _active)
                return;
            _active = value;
            CanvasStatus(_active);
        }
    }
    private void CanvasStatus(bool value)
    {
        canvas.blocksRaycasts = value;
        canvas.interactable = value;
        canvas.alpha = value ? 1f : 0f;

        innerCanvas.blocksRaycasts = value;
        innerCanvas.interactable = value;

        if (_glowScript != null)
        {
            _glowScript.enable = value;
        }
    }
    virtual public void Appear(System.Action callback = null)
    {
        CSSoundManager.instance.Play("Win_0");
        HideBoards();
        active = true;
        AddPaticle();
        _image.color = Color.clear;
        LeanTween.alpha(_image.rectTransform, 0.8f, 0.4f);
        ScaleAction(() => {
            ScaleActionCompleted();
            if (callback != null)
                callback();
        });
    }
}
