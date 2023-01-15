using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    [Header("Variables")]
    public long money;
    public long moneyChange;
    public long moneyPerSec;
    public long egg;

    [Header("Texts")]
    public TMP_Text TMoneyText;
    public TMP_Text TMoneyPerSecText;
    public TMP_Text TEgg;

    [Header("Other")]
    private float timePassed;
    private const float interval = 1f;

    private void Start() {
        string moneyString = PlayerPrefs.GetString("money", "0");
        string moneyChangeString = PlayerPrefs.GetString("moneyChange", "1");
        string moneyPerSecString = PlayerPrefs.GetString("moneyPerSec", "0");
        string eggString = PlayerPrefs.GetString("egg", "0");

        money = long.Parse(moneyString);
        moneyChange = long.Parse(moneyChangeString);
        moneyPerSec = long.Parse(moneyPerSecString);
        egg = long.Parse(eggString);

        TEgg.text = "EGG: 0" + PlayerPrefs.GetString("egg").ToString();
        TMoneyPerSecText.text = "Romans stealing per sec: zł" + moneyPerSec.ToString() + "/s";
    }

    private void Update() {
        timePassed += Time.deltaTime;
        if (timePassed >= interval) {
            timePassed = 0;
            money += moneyPerSec;
            PlayerPrefs.SetString("money", money.ToString());
            TMoneyText.text = "Monies: zł" + string.Format("{0:n0}", money).ToString();
            TMoneyPerSecText.text = "Romans stealing per sec: zł" + moneyPerSec.ToString() + "/s";
        }
    }

    public void AddMoney() {
        money += moneyChange;
        PlayerPrefs.SetString("money", money.ToString());
        TMoneyText.text = "Monies: zł" + string.Format("{0:n0}", money).ToString();
    }
}
