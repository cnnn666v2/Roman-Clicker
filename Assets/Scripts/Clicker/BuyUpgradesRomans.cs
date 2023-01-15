using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuyUpgradesRomans : MonoBehaviour
{
    Money moneyA;
    public int USCost;
    public int US1Cost;
    public int US2Cost;
    public int HitmanCost;
    public int PoliceCost;
    public int BossCost;

    [Header("Upgrade Levels")]
    //Steals
    public int StealIULvl;
    public int StealIIULvl;
    public int StealIIIULvl;
    public int StealIVULvl;

    //Workers
    public int HMULvl;
    public int PoliceULvl;
    public int BossULvl;

    [Header("Upgrade LVL Texts")]
    public TMP_Text StealILvl;
    public TMP_Text StealIILvl;
    public TMP_Text StealIIILvl;
    public TMP_Text StealIVLvl;
    public TMP_Text HitmanLvl;
    public TMP_Text PoliceLvl;
    public TMP_Text BossLvl;

    [Header("Upgrade Cost Texts")]
    public TMP_Text StealIICost;
    public TMP_Text StealIIICost;
    public TMP_Text StealIVCost;
    public TMP_Text HitmanCostTXT;
    public TMP_Text PoliceCostTXT;
    public TMP_Text BossCostTXT;

    void Awake() {
        moneyA = GetComponent<Money>();

        StealIULvl = PlayerPrefs.GetInt("StealI", 0);
        StealIIULvl = PlayerPrefs.GetInt("StealII", 0);
        StealIIIULvl = PlayerPrefs.GetInt("StealIII", 0);
        StealIVULvl = PlayerPrefs.GetInt("StealIV", 0);
        HMULvl = PlayerPrefs.GetInt("HM", 0);
        PoliceULvl = PlayerPrefs.GetInt("Police", 0);
        BossULvl = PlayerPrefs.GetInt("Boss", 0);

        USCost = PlayerPrefs.GetInt("US2Cost", 450);
        US1Cost = PlayerPrefs.GetInt("US3Cost", 3000);
        US2Cost = PlayerPrefs.GetInt("US4Cost", 12000);
        HitmanCost = PlayerPrefs.GetInt("HMCost", 75000);
        PoliceCost = PlayerPrefs.GetInt("PCost", 35000);
        BossCost = PlayerPrefs.GetInt("BCost", 1000000);

        StealILvl.text = "Level: " + PlayerPrefs.GetInt("StealI");

        StealIILvl.text = "Level: " + PlayerPrefs.GetInt("StealII");
        StealIICost.text = "Cost: " + string.Format("{0:n0}", PlayerPrefs.GetInt("US2Cost", USCost)).ToString() + "zł";

        StealIIILvl.text = "Level: " + PlayerPrefs.GetInt("StealIII");
        StealIIICost.text = "Cost: " + string.Format("{0:n0}", PlayerPrefs.GetInt("US3Cost", US1Cost)).ToString() + "zł";

        StealIVLvl.text = "Level: " + PlayerPrefs.GetInt("StealIV");
        StealIVCost.text = "Cost: " + string.Format("{0:n0}", PlayerPrefs.GetInt("US4Cost", US2Cost)).ToString() + "zł";

        HitmanLvl.text = "Level: " + PlayerPrefs.GetInt("HM");
        HitmanCostTXT.text = "Cost: " + string.Format("{0:n0}", PlayerPrefs.GetInt("HMCost", HitmanCost)).ToString() + "zł";

        PoliceLvl.text = "Level: " + PlayerPrefs.GetInt("Police");
        PoliceCostTXT.text = "Cost: " + string.Format("{0:n0}", PlayerPrefs.GetInt("PCost", PoliceCost)).ToString() + "zł";

        BossLvl.text = "Level: " + PlayerPrefs.GetInt("Boss");
        BossCostTXT.text = "Cost: " + string.Format("{0:n0}", PlayerPrefs.GetInt("BCost", BossCost)).ToString() + "zł";
    }

    public void UgradeStealI() {
        if(moneyA.money >= 150) {
            moneyA.money -= 150;
            moneyA.moneyPerSec++;

            StealIULvl++;

            PlayerPrefs.SetInt("StealI", StealIULvl);
            PlayerPrefs.SetString("money", moneyA.money.ToString());
            PlayerPrefs.SetString("moneyPerSec", moneyA.moneyPerSec.ToString());

            StealILvl.text = "Level: " + PlayerPrefs.GetInt("StealI", 0);
        };
    }

    public void UgradeStealII() {
        if(moneyA.money >= USCost) {
            moneyA.money -= USCost;
            moneyA.moneyPerSec += 15;

            StealIIULvl++;
            USCost += Mathf.RoundToInt(USCost/4);

            PlayerPrefs.SetInt("StealII", StealIIULvl);
            PlayerPrefs.SetString("money", moneyA.money.ToString());
            PlayerPrefs.SetString("moneyPerSec", moneyA.moneyPerSec.ToString());
            PlayerPrefs.SetInt("US2Cost", USCost);

            StealIICost.text = "Cost: " + string.Format("{0:n0}", PlayerPrefs.GetInt("US2Cost", USCost)).ToString() + "zł";
            StealIILvl.text = "Level: " + PlayerPrefs.GetInt("StealII", StealIIULvl);
        };
    }

    public void UpgradeStealIII() {
        if(moneyA.money >= US1Cost) {
            moneyA.money -= US1Cost;
            moneyA.moneyPerSec += 50;

            StealIIIULvl++;
            US1Cost += Mathf.RoundToInt(US1Cost/4);

            PlayerPrefs.SetInt("StealIII", StealIIIULvl);
            PlayerPrefs.SetString("money", moneyA.money.ToString());
            PlayerPrefs.SetString("moneyPerSec", moneyA.moneyPerSec.ToString());
            PlayerPrefs.SetInt("US3Cost", US1Cost);

            StealIIICost.text = "Cost: " + string.Format("{0:n0}", PlayerPrefs.GetInt("US3Cost", US1Cost)).ToString() + "zł";
            StealIIILvl.text = "Level: " + PlayerPrefs.GetInt("StealIII", StealIIIULvl);
        }
    }

    public void UpgradeStealIV() {
        if(moneyA.money >= US2Cost) {
            moneyA.money -= US2Cost;
            moneyA.moneyPerSec += 120;

            StealIVULvl++;
            US2Cost += Mathf.RoundToInt(US2Cost/4);

            PlayerPrefs.SetInt("StealIV", StealIVULvl);
            PlayerPrefs.SetString("money", moneyA.money.ToString());
            PlayerPrefs.SetString("moneyPerSec", moneyA.moneyPerSec.ToString());
            PlayerPrefs.SetInt("US4Cost", US2Cost);

            StealIVCost.text = "Cost: " + string.Format("{0:n0}", PlayerPrefs.GetInt("US4Cost", US2Cost)).ToString() + "zł";
            StealIVLvl.text = "Level: " + PlayerPrefs.GetInt("StealIV", StealIVULvl);
        }
    }

    public void UpgradeHitman() {
        if(moneyA.money >= HitmanCost) {
            moneyA.money -= HitmanCost;
            moneyA.moneyPerSec += 500;

            HMULvl++;
            HitmanCost += Mathf.RoundToInt(HitmanCost/4);

            PlayerPrefs.SetInt("HM", HMULvl);
            PlayerPrefs.SetString("money", moneyA.money.ToString());
            PlayerPrefs.SetString("moneyPerSec", moneyA.moneyPerSec.ToString());
            PlayerPrefs.SetInt("HMCost", HitmanCost);

            StealIVCost.text = "Cost: " + string.Format("{0:n0}", PlayerPrefs.GetInt("HMCost", HitmanCost)).ToString() + "zł";
            StealIVLvl.text = "Level: " + PlayerPrefs.GetInt("HM", HMULvl);
        }
    }

    public void UpgradePolice() {
        if(moneyA.money >= PoliceCost) {
            moneyA.money -= PoliceCost;
            moneyA.moneyPerSec += 100;

            PoliceULvl++;
            PoliceCost += Mathf.RoundToInt(PoliceCost/4);

            PlayerPrefs.SetInt("HM", PoliceULvl);
            PlayerPrefs.SetString("money", moneyA.money.ToString());
            PlayerPrefs.SetString("moneyPerSec", moneyA.moneyPerSec.ToString());
            PlayerPrefs.SetInt("PCost", PoliceCost);

            PoliceCostTXT.text = "Cost: " + string.Format("{0:n0}", PlayerPrefs.GetInt("PCost", PoliceCost)).ToString() + "zł";
            PoliceLvl.text = "Level: " + PlayerPrefs.GetInt("Police", PoliceULvl);
        }
    }

    public void UpgradeBoss() {
        if(moneyA.money >= BossCost) {
            moneyA.money -= BossCost;
            moneyA.moneyPerSec += 1000;

            BossULvl++;
            BossCost += Mathf.RoundToInt(BossCost/4);

            PlayerPrefs.SetInt("Boss", BossULvl);
            PlayerPrefs.SetString("money", moneyA.money.ToString());
            PlayerPrefs.SetString("moneyPerSec", moneyA.moneyPerSec.ToString());
            PlayerPrefs.SetInt("BCost", BossCost);

            BossCostTXT.text = "Cost: " + string.Format("{0:n0}", PlayerPrefs.GetInt("BCost", BossCost)).ToString() + "zł";
            BossLvl.text = "Level: " + PlayerPrefs.GetInt("Boss", BossULvl);
        }
    }
}
