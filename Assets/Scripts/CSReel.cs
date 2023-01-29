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
}
