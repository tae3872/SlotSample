using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CSExperiencePanel : MonoBehaviour
{
    public RectTransform progress;
    public RectTransform bar;
    public GameObject partilcePrefab;
    public Transform icon;
    public float power;
    public float increasePercent;
    public Text levelText;
    public Text percentText;
    public CSLevelUpAlert alert;

    private Vector2 _size;
    private float _max;

    private float _xp = 0;
    public float xp
    {
        get { return _xp; }
        set
        {
            _xp = value;
            CSGameSettings.instance.xp = value;
        }
    }
    private int _level;

    public int level
    {
        get { return _level; }
        set
        {
            if (_level == value)
                return;
            _level = value;
            CSGameSettings.instance.level = value;
        }
    }

    private void Awake()
    {
        CSGameSettings settings=CSGameSettings.instance;
        _level = settings.level;
        _xp = settings.xp;
        _size = progress.sizeDelta;
        _max = MaxForLevel(_level);
        levelText.text = _level.ToString();
        UpdateBar(_xp / _max);
    }
    private void AnimateProgressWith(float value, int l, float m, float v)
    {
        int curLevel = l;
        float prev = v;
        LeanTween.cancel(gameObject);
        LeanTween.value(gameObject, v, (v + value), 1f).setOnUpdate((float f) =>
        {
            v += f - prev;
            if (v >= m)
            {
                l++;
                levelText.text = l.ToString();
                v -= m;
                m = MaxForLevel(l);
            }
            UpdateBar(Mathf.Clamp(v / m, 0f, 1f));
            prev = f;
        }).setOnComplete(() => {
            if (_level > curLevel)
                Alert();
        });
    }
    private float MaxForLevel(int l)
    {
        return Mathf.Pow(power + power * increasePercent * (l - 1), 2);
    }
    private void UpdateBar(float p)
    {
        bar.offsetMax = new Vector2(-_size.x - (-_size.x * p), bar.offsetMax.y);
        percentText.text = (p * 100).ToString("F1") + "%";
    }
    private void Alert()
    {
        alert.Appear(_level);
    }
}
