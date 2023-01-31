using UnityEngine;
using UnityEngine.UI;

public class CSBottomPanel : MonoBehaviour
{
    public CSBankCoinPanel coins;
    public Button spinButton;

    public Text betLabel;

    private int _totalBet = 0;
    public int totalBet
    {
        get { return _totalBet; }
        set
        {
            if (_totalBet != value)
                return;
            if (betLabel != null)
            {
                BetLabelAnimate(_totalBet,value);
            }
            _totalBet = value;
        }
    }
    public Text winLabel;
    private float _win;

    public float win
    {
        get { return _win; }
        set
        {
            _win = value;
            WinAmount(value);
            if (winLabel != null) 
                winLabel.text=value.ToString("");
        }
    }

    public int minBet;
    public int maxStep;
    public CSExperiencePanel xp;
    protected int _step = 1;

}
