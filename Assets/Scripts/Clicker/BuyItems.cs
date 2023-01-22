using UnityEngine;
using TMPro;

public class BuyItems : MonoBehaviour
{
    Money moneyA;
    PlayerStats playerScript;

    [Header("Buy Items")]
    int ItemSW;
    int ItemSS;
    // 0 = can buy
    // 1 = cant buy

    [Header("Lock Panels")]
    public GameObject ItemLP1;
    public GameObject ItemLP2;

    int CurrAttack;


    void Awake() {
        moneyA = GetComponent<Money>();
        playerScript = GetComponent<PlayerStats>();

        ItemSW = PlayerPrefs.GetInt("ItemSW", 0);
        ItemSS = PlayerPrefs.GetInt("ItemSS", 0);
    }

    void Update() {
        if(ItemSW == 0) {
            ItemLP1.SetActive(false);
        } else {
            ItemLP1.SetActive(true);
        }
        
        if(ItemSS == 0) {
            ItemLP2.SetActive(false);
        } else {
            ItemLP2.SetActive(true);
        }
    }

    public void BuyItemSwordW() {
        if(ItemSW == 0) {
            if(moneyA.money >= 500) {
                moneyA.money -= 500;
                CurrAttack = playerScript.Attack + 1;

                ItemSW++;

                PlayerPrefs.SetInt("ItemSW", ItemSW);
                PlayerPrefs.SetString("money", moneyA.money.ToString());
                PlayerPrefs.SetInt("Attack", CurrAttack);
            };
        }
    }

    public void BuyItemSwordS() {
        if(ItemSS == 0) {
            if(moneyA.money >= 3000) {
                moneyA.money -= 3000;
                CurrAttack = playerScript.Attack + 5;

                ItemSS++;

                PlayerPrefs.SetInt("ItemSS", ItemSS);
                PlayerPrefs.SetString("money", moneyA.money.ToString());
                PlayerPrefs.SetInt("Attack", CurrAttack);
            };
        }
    }
}
