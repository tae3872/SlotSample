using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CSGlowAnimation : MonoBehaviour
{
    [Range(0f, 1f)] public float location;
    [Range(0f, 1f)] public float width;
    public float duration;
    public bool animateOnWake;
    public int repeat = -1;
    public bool ignoreTimeScale = false;

    private bool _materialSetted = false;
    private int _actionId;

    private Material _material;
    private Material Material
    {
        get
        {
            if (_material == null)
                _material = GetComponent<Image>().materialForRendering;
            return _material;
        }
    }
    private bool _enable = false;
    public bool enable
    {
        get { return _enable; }
        set
        {
            if (value == _enable)
                return;
            _enable = value;
            Action(_enable);
        }
    }
    private void Action(bool animate)
    {
        //if (!_materialSetted)
        //{
        //	_materialSetted = true;
        //	SetMaterial();
        //}
        if (animate)
        {
            Start(animate);
        }
        else
        {
            SetShineLocation(0f);
            Stop(animate);
        }
    }
    private void Start(bool animate)
    {
        float delay = duration * 1f;
        _actionId = LeanTween.value(gameObject, -delay, 1f, duration + delay).setOnUpdate(delegate (float obj) {
            if (obj > 0f && obj <= 1f)
            {
                SetShineLocation(location + obj);
                //Shader.SetGlobalFloat("_ShineLocation", location + obj);
            }

        }).setRepeat(repeat).setIgnoreTimeScale(ignoreTimeScale).id;
    }
    private void SetShineLocation(float value)
    {
        Material.SetFloat("_ShineLocation", value);
    }
    private void Stop(bool animate)
    {
        LeanTween.cancel(_actionId);
    }
}
