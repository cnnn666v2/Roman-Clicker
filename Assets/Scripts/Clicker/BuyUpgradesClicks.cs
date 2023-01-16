using UnityEngine;
using TMPro;

public class BuyUpgradesClicks : MonoBehaviour
{
    Money moneyA;

    [Header("Upgrade Cost")]
    public int UPCost;
    public int UP1Cost;
    public int UP2Cost;
    public int UP3Cost;
    public int FACTanksCost;
    public int FACCarsCost;

    [Header("Upgrade Levels")]
    //People
    public int PeopleIULvl;
    public int PeopleIIULvl;
    public int PeopleIIIULvl;
    public int PeopleIVULvl;

    //Factories
    public int FTanksULvl;
    public int FCarsULvl;

    [Header("Upgrade LVL Texts")]
    public TMP_Text PeopleILvl;
    public TMP_Text PeopleIILvl;
    public TMP_Text PeopleIIILvl;
    public TMP_Text PeopleIVLvl;
    public TMP_Text FTanksLvl;
    public TMP_Text FCarsLvl;

    [Header("Upgrade Cost Texts")]
    public TMP_Text PeopleICost;
    public TMP_Text PeopleIICost;
    public TMP_Text PeopleIIICost;
    public TMP_Text PeopleIVCost;
    public TMP_Text FTanksCost;
    public TMP_Text FCarsCost;



    void Awake() {
        moneyA = GetComponent<Money>();
        PeopleIULvl = PlayerPrefs.GetInt("PeopleI", 0);
        PeopleIIULvl = PlayerPrefs.GetInt("PeopleII", 0);
        PeopleIIIULvl = PlayerPrefs.GetInt("PeopleIII", 0);
        PeopleIVULvl = PlayerPrefs.GetInt("PeopleIV", 0);
        FTanksULvl = PlayerPrefs.GetInt("FTanks", 0);
        FCarsULvl = PlayerPrefs.GetInt("FCars", 0);


        UPCost = PlayerPrefs.GetInt("UPCost", 10);
        UP1Cost = PlayerPrefs.GetInt("UP1Cost", 200);
        UP2Cost = PlayerPrefs.GetInt("UP2Cost", 800);
        UP3Cost = PlayerPrefs.GetInt("UP3Cost", 2000);
        FACTanksCost = PlayerPrefs.GetInt("FACTanksCost", 40000);
        FACCarsCost = PlayerPrefs.GetInt("FACCarsCost", 40000);


        PeopleILvl.text = "Level: " + PlayerPrefs.GetInt("PeopleI");
        PeopleICost.text = "Cost: " + string.Format("{0:n0}", PlayerPrefs.GetInt("UPCost", UPCost)).ToString() + "zł";

        PeopleIILvl.text = "Level: " + PlayerPrefs.GetInt("PeopleII");
        PeopleIICost.text = "Cost: " + string.Format("{0:n0}", PlayerPrefs.GetInt("UP1Cost", UP1Cost)).ToString() + "zł";

        PeopleIIILvl.text = "Level: " + PlayerPrefs.GetInt("PeopleIII");
        PeopleIIICost.text = "Cost: " + string.Format("{0:n0}", PlayerPrefs.GetInt("UP2Cost", UP2Cost)).ToString() + "zł";

        PeopleIVLvl.text = "Level: " + PlayerPrefs.GetInt("PeopleIV");
        PeopleIVCost.text = "Cost: " + string.Format("{0:n0}", PlayerPrefs.GetInt("UP3Cost", UP3Cost)).ToString() + "zł";

        FTanksLvl.text = "Level: " + PlayerPrefs.GetInt("FTanks");
        FTanksCost.text = "Cost: " + string.Format("{0:n0}", PlayerPrefs.GetInt("FTanks", FACTanksCost)).ToString() + "zł";

        FCarsLvl.text = "Level: " + PlayerPrefs.GetInt("FCars");
        FCarsCost.text = "Cost: " + string.Format("{0:n0}", PlayerPrefs.GetInt("FCars", FACCarsCost)).ToString() + "zł";
    }

    public void UgradePeopleI() {
        if(moneyA.money >= UPCost) {
            moneyA.money -= UPCost;
            moneyA.moneyChange += 1;

            PeopleIULvl++;
            UPCost += Mathf.RoundToInt(UPCost/4);

            PlayerPrefs.SetInt("PeopleI", PeopleIULvl);
            PlayerPrefs.SetString("money", moneyA.money.ToString());
            PlayerPrefs.SetString("moneyChange", moneyA.moneyChange.ToString());
            PlayerPrefs.SetInt("UPCost", UPCost);

            PeopleICost.text = "Cost: " + string.Format("{0:n0}", PlayerPrefs.GetInt("UPCost", UPCost)).ToString() + "zł";
            PeopleILvl.text = "Level: " + PlayerPrefs.GetInt("PeopleI", PeopleIULvl);
        };
    }

    public void UgradePeopleII() {
        if(moneyA.money >= UP1Cost) {
            moneyA.money -= UP1Cost;
            moneyA.moneyChange += 5;

            PeopleIIULvl++;
            UP1Cost += Mathf.RoundToInt(UP1Cost/4);

            PlayerPrefs.SetInt("PeopleII", PeopleIIULvl);
            PlayerPrefs.SetString("money", moneyA.money.ToString());
            PlayerPrefs.SetString("moneyChange", moneyA.moneyChange.ToString());
            PlayerPrefs.SetInt("UP1Cost", UP1Cost);

            PeopleIICost.text = "Cost: " + string.Format("{0:n0}", PlayerPrefs.GetInt("UP1Cost", UP1Cost)).ToString() + "zł";
            PeopleIILvl.text = "Level: " + PlayerPrefs.GetInt("PeopleII", PeopleIIULvl);
        };
    }

    public void UgradePeopleIII() {
        if(moneyA.money >= UP2Cost) {
            moneyA.money -= UP2Cost;
            moneyA.moneyChange += 10;

            PeopleIIIULvl++;
            UP2Cost += Mathf.RoundToInt(UP2Cost/4);

            PlayerPrefs.SetInt("PeopleIII", PeopleIIIULvl);
            PlayerPrefs.SetString("money", moneyA.money.ToString());
            PlayerPrefs.SetString("moneyChange", moneyA.moneyChange.ToString());
            PlayerPrefs.SetInt("UP2Cost", UP2Cost);

            PeopleIIICost.text = "Cost: " + string.Format("{0:n0}", PlayerPrefs.GetInt("UP2Cost", UP2Cost)).ToString() + "zł";
            PeopleIIILvl.text = "Level: " + PlayerPrefs.GetInt("PeopleIII", PeopleIIIULvl);
        };
    }

    public void UgradePeopleIV() {
        if(moneyA.money >= UP3Cost) {
            moneyA.money -= UP3Cost;
            moneyA.moneyChange += 20;

            PeopleIVULvl++;
            UP3Cost += Mathf.RoundToInt(UP3Cost/4);

            PlayerPrefs.SetInt("PeopleIV", PeopleIVULvl);
            PlayerPrefs.SetString("money", moneyA.money.ToString());
            PlayerPrefs.SetString("moneyChange", moneyA.moneyChange.ToString());
            PlayerPrefs.SetInt("UP3Cost", UP3Cost);

            PeopleIVCost.text = "Cost: " + string.Format("{0:n0}", PlayerPrefs.GetInt("UP3Cost", UP3Cost)).ToString() + "zł";
            PeopleIVLvl.text = "Level: " + PlayerPrefs.GetInt("PeopleIV", PeopleIVULvl);
        };
    }
}
