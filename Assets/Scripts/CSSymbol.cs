using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;

public enum CSSymbolType
{
    SymbolNone,
    SymbolWild,
    SymbolScatter,
    Symbol_3,
    Symbol_4,
    Symbol_5,
    Symbol_6,
    Symbol_7,
    Symbol_8,
    Symbol_9,
    Symbol_10,
    Symbol_11,
    Symbol_12,
    Symbol_13,
}

[RequireComponent(typeof(Image))]
public abstract class CSSymbol : MonoBehaviour
{
    public CSSymbolData[] data;
    protected CSSymbolData curr = null;
    public Dictionary<CSSymbolType, CSSymbolData> dictionaryData;
    public CSSymbolType type;
    public CSCell cell;
    public CSSymbolData wildExpand;
    public CSSymbolData wildExpandStay;
    [HideInInspector] public CSSymbol replacement = null;
    [HideInInspector] public CSSymbolPercent[] percents;

    private Image _image;
    private int _animationId;
    protected ParticleSystem _particle;
    private RectTransform _rect;
    private float _totalChance;
    void Awake()
    {
        _rect = transform as RectTransform;
        _image = GetComponent<Image>();
        dictionaryData = CreateDictionaryData(data);
    }
    public void StartWith(CSSymbolType t, CSCell cell, Vector3 position)
    {
        this.cell = cell;
        _rect.localPosition = position;
        SetType(t);
    }
    public void SetType(CSSymbolType t)
    {
        if (t == CSSymbolType.SymbolNone)
        {
            _image.sprite = null;
            _image.rectTransform.sizeDelta = Vector3.zero;
            return;
        }
        type = t;
        _rect.pivot = new Vector2(0.5f, 0.5f);
        replacement = null;

        curr = dictionaryData[t];
        Debug.Assert(curr != null, "Couldn't find data for type " + t);

        _image.sprite = curr.sprite;
        _image.SetNativeSize();
    }
    private Dictionary<CSSymbolType, CSSymbolData> CreateDictionaryData(CSSymbolData[] array)
    {
        Dictionary<CSSymbolType, CSSymbolData> dictionary = new Dictionary<CSSymbolType, CSSymbolData>();
        for (int i = 0; i < array.Length; i++)
        {
            dictionary.Add(array[i].type, array[i]);
        }
        return dictionary;
    }
}


[System.Serializable]
public struct CSSymbolPercent
{
    public float percent;
    public CSSymbolType type;

    public override string ToString()
    {
        return percent + ", " + type;
    }
}