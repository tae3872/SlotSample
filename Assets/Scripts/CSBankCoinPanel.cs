using UnityEngine;
using UnityEngine.UI;

public class CSBankCoinPanel : MonoBehaviour
{
    public System.Action<CSBankCoinPanel> bankValueChanged;

    public Text text;
    public GameObject particle;
    public RectTransform coinIcon;
    public bool formatText;

    private float _bank;

    public float bank
    {
        get { return _bank; }
        set { text.text = Format(value);
            _bank= value;
            ValueChanged();
        }
    }
    private void OnDestroy()
    {
        //LeanTween.cancel(text.gameObject);
    }
    private void Awake()
    {
        _bank = CSGameSettings.instance.coins;
        text.text = Format(_bank);
    }
    private string Format(float value)
    {
        return formatText ? CSUtilities.FormatNumber(value) : string.Format("{0:0.00}", value);
    }
    private void ValueChanged()
    {
        CSGameSettings.instance.coins = _bank;
        if (bankValueChanged != null)
        {
            bankValueChanged(this);
        }
    }
}
