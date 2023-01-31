using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CSAlertRewardAnim : CSAlert
{
    public CSBankCoinPanel coinPanel;
    public TextMeshProUGUI rewardLabel;
    protected float _reward;
    public override void Appear(Action callback = null)
    {
        EnableShareButton(false);
        if (rewardLabel != null)
            rewardLabel.text = "";
        base.Appear(callback);
    }
}
