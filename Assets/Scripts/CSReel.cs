using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSReel : MonoBehaviour
{
    public GameObject symbol;
    private Vector2 _tileSize;
    private int _count = 4;
    private CSSymbol[] _symbols;
    private Vector2 _size;
    private int _column;
    public CS2DBoolArray symbolEnabled;
    private CSReelRandom _reelRandom;

    public CSSymbol this[int index]
    {
        get { return _symbols[index]; }
        set { _symbols[index] = value; }
    }
    private void Awake()
    {
        _symbols = new CSSymbol[_count];
    }
    public void StartWithSize(Vector2 tile, int idx)
    {
        _tileSize = tile;
        _column = idx;

        _reelRandom = new CSReelRandom(symbol.GetComponent<CSSymbol>().percents, symbolEnabled, _column);
        _size = new Vector2(tile.x, tile.y * _count);
        (transform as RectTransform).sizeDelta = _size;
        CreateSymbols(idx);
    }
    void CreateSymbols(int column)
    {
        for (int i = 0; i < _count; i++)
        {
            _symbols[i] = CreateSymbol(new CSCell(column, i));
        }
    }
    CSSymbol CreateSymbol(CSCell cell)
    {
        CSSymbol script = Instantiate(symbol, transform).GetComponent<CSSymbol>();
        script.StartWith(_reelRandom.SmartRandomSymbol(), cell, PositionForRow(cell.row));
        return script;
    }
    private Vector3 PositionForRow(int row)
    {
        return new Vector3(0f, _tileSize.y * 0.5f + _tileSize.y * row);
    }
}
