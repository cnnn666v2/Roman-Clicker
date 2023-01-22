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

    [Header("Upgrades Avaible")]
    int P1UPB;
    int P2UPB;
    int P3UPB;
    int P4UPB;
    int FTUPB;
    int FCUPB;

    [Header("Lock Panels")]
    public GameObject ItemLP1;
    public GameObject ItemLP2;
    public GameObject ItemLP3;
    public GameObject ItemLP4;
    public GameObject ItemLP5;
    public GameObject ItemLP6;



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
        FACCarsCost = PlayerPrefs.GetInt("FACCarsCost", 120000);

        P1UPB = PlayerPrefs.GetInt("P1UPB", 1);
        P2UPB = PlayerPrefs.GetInt("P2UPB", 0);
        P3UPB = PlayerPrefs.GetInt("P3UPB", 0);
        P4UPB = PlayerPrefs.GetInt("P4UPB", 0);
        FTUPB = PlayerPrefs.GetInt("FTUPB", 0);
        FCUPB = PlayerPrefs.GetInt("FCUPB", 0);


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

    void Update() {
        if(P1UPB > 0) {
            ItemLP1.SetActive(false);
        } else {
            ItemLP1.SetActive(true);
        }
        
        if(P2UPB > 0) {
            ItemLP2.SetActive(false);
        } else {
            ItemLP2.SetActive(true);
        }
        
        if(P3UPB > 0) {
            ItemLP3.SetActive(false);
        } else {
            ItemLP3.SetActive(true);
        }
        
        if(P4UPB > 0) {
            ItemLP4.SetActive(false);
        } else {
            ItemLP4.SetActive(true);
        }
        
        if(FTUPB > 0) {
            ItemLP5.SetActive(false);
        } else {
            ItemLP5.SetActive(true);
        }
        
        if( FCUPB > 0) {
            ItemLP6.SetActive(false);
        } else {
            ItemLP6.SetActive(true);
        }
    }

    public void UgradePeopleI() {
        if(P1UPB > 0) {
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

                P1UPB -= 1;
                PlayerPrefs.SetInt("P1UPB", P1UPB);
            };
        };
    }

    public void UgradePeopleII() {
        if(P2UPB > 0) {
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

                P2UPB -= 1;
                PlayerPrefs.SetInt("P2UPB", P2UPB);
            };
        }
    }

    public void UgradePeopleIII() {
        if(P3UPB > 0) {
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

                P3UPB -= 1;
                PlayerPrefs.SetInt("P3UPB", P3UPB);
            };
        }
    }

    public void UgradePeopleIV() {
        if(P4UPB > 0) {
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

                P4UPB -= 1;
                PlayerPrefs.SetInt("P4UPB", P4UPB);
            };
        }
    }

    public void UgradeFTanks() {
        if(FCUPB > 0) {
            if(moneyA.money >= FACTanksCost) {
                moneyA.money -= FACTanksCost;
                moneyA.moneyChange += 200;

                FTanksULvl++;
                FACTanksCost += Mathf.RoundToInt(FACTanksCost/4);

                PlayerPrefs.SetInt("FTanks", FTanksULvl);
                PlayerPrefs.SetString("money", moneyA.money.ToString());
                PlayerPrefs.SetString("moneyChange", moneyA.moneyChange.ToString());
                PlayerPrefs.SetInt("FACTanksCost", FACTanksCost);

                FTanksCost.text = "Cost: " + string.Format("{0:n0}", PlayerPrefs.GetInt("FACTanksCost", FACTanksCost)).ToString() + "zł";
                FTanksLvl.text = "Level: " + PlayerPrefs.GetInt("FTanks", FTanksULvl);

                FTUPB -= 1;
                PlayerPrefs.SetInt("FTUPB", FTUPB);
            };
        }
    }

    public void UgradeFCars() {
        if(FCUPB > 0) {
            if(moneyA.money >= FACCarsCost) {
                moneyA.money -= FACCarsCost;
                moneyA.moneyChange += 500;

                FCarsULvl++;
                FACCarsCost += Mathf.RoundToInt(FACCarsCost/4);

                PlayerPrefs.SetInt("FCars", FCarsULvl);
                PlayerPrefs.SetString("money", moneyA.money.ToString());
                PlayerPrefs.SetString("moneyChange", moneyA.moneyChange.ToString());
                PlayerPrefs.SetInt("FACCarsCost", FACCarsCost);

                FCarsCost.text = "Cost: " + string.Format("{0:n0}", PlayerPrefs.GetInt("FACCarsCost", FACCarsCost)).ToString() + "zł";
                FCarsLvl.text = "Level: " + PlayerPrefs.GetInt("FCars", FCarsULvl);

                FCUPB -= 1;
                PlayerPrefs.SetInt("FCUPB", FCUPB);
            };
        }
    }
}
