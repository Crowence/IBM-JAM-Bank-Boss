using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public float    money,
                    baseIncome,
                    securityLevel,
                    staffMorale,
                    publicMorale,
                    year,
                    staffThreshold,
                    moneyAdd;

	void Start ()
    {
        money = 80000f;
        baseIncome = 20000f;
        securityLevel = 1f;
        staffMorale = 50f;
        publicMorale = 50f;
        year = 1f;
        staffThreshold = 40f;
        moneyAdd = 2000f;
	}

    void SetResourceUIValues()
    {
        GameObject.Find("MoneyText").GetComponent<Text>().text = money.ToString();
        GameObject.Find("StaffMoralePercentage").GetComponent<Text>().text = staffMorale.ToString();
        GameObject.Find("StaffMoralePercentageBlack").GetComponent<Text>().text = staffMorale.ToString();
        GameObject.Find("StaffMoraleBar").GetComponent<RectTransform>().sizeDelta = new Vector2(679f * staffMorale / 100, 25f);
        GameObject.Find("PublicMoralePercentage").GetComponent<Text>().text = publicMorale.ToString();
        GameObject.Find("PublicMoralePercentageBlack").GetComponent<Text>().text = publicMorale.ToString();
        GameObject.Find("PublicMoraleBar").GetComponent<RectTransform>().sizeDelta = new Vector2(679f * publicMorale / 100, 32f);
    }

    void SetSecurityIndicator()
    {
        if (securityLevel == 1f)
        {
            GameObject.Find("SecurityLevelOne").GetComponent<Image>().enabled = true;
            GameObject.Find("SecurityLevelTwo").GetComponent<Image>().enabled = false;
            GameObject.Find("SecurityLevelThree").GetComponent<Image>().enabled = false;
            GameObject.Find("SecurityLevelFour").GetComponent<Image>().enabled = false;
            GameObject.Find("SecurityLevelFive").GetComponent<Image>().enabled = false;
            GameObject.Find("UpgradeSecurityMoneyText").GetComponent<Text>().text = "- 20000 P";
            GameObject.Find("UpgradeSecurityLevelText").GetComponent<Text>().enabled = true;
        }
        if (securityLevel == 2f)
        {
            GameObject.Find("SecurityLevelOne").GetComponent<Image>().enabled = false;
            GameObject.Find("SecurityLevelTwo").GetComponent<Image>().enabled = true;
            GameObject.Find("SecurityLevelThree").GetComponent<Image>().enabled = false;
            GameObject.Find("SecurityLevelFour").GetComponent<Image>().enabled = false;
            GameObject.Find("SecurityLevelFive").GetComponent<Image>().enabled = false;
            GameObject.Find("UpgradeSecurityMoneyText").GetComponent<Text>().text = "- 40000 P";
            GameObject.Find("UpgradeSecurityLevelText").GetComponent<Text>().enabled = true;
        }
        if (securityLevel == 3f)
        {
            GameObject.Find("SecurityLevelOne").GetComponent<Image>().enabled = false;
            GameObject.Find("SecurityLevelTwo").GetComponent<Image>().enabled = false;
            GameObject.Find("SecurityLevelThree").GetComponent<Image>().enabled = true;
            GameObject.Find("SecurityLevelFour").GetComponent<Image>().enabled = false;
            GameObject.Find("SecurityLevelFive").GetComponent<Image>().enabled = false;
            GameObject.Find("UpgradeSecurityMoneyText").GetComponent<Text>().text = "- 60000 P";
            GameObject.Find("UpgradeSecurityLevelText").GetComponent<Text>().enabled = true;
        }
        if (securityLevel == 4f)
        {
            GameObject.Find("SecurityLevelOne").GetComponent<Image>().enabled = false;
            GameObject.Find("SecurityLevelTwo").GetComponent<Image>().enabled = false;
            GameObject.Find("SecurityLevelThree").GetComponent<Image>().enabled = false;
            GameObject.Find("SecurityLevelFour").GetComponent<Image>().enabled = true;
            GameObject.Find("SecurityLevelFive").GetComponent<Image>().enabled = false;
            GameObject.Find("UpgradeSecurityMoneyText").GetComponent<Text>().text = "- 80000 P";
            GameObject.Find("UpgradeSecurityLevelText").GetComponent<Text>().enabled = true;
        }
        if (securityLevel == 5f)
        {
            GameObject.Find("SecurityLevelOne").GetComponent<Image>().enabled = false;
            GameObject.Find("SecurityLevelTwo").GetComponent<Image>().enabled = false;
            GameObject.Find("SecurityLevelThree").GetComponent<Image>().enabled = false;
            GameObject.Find("SecurityLevelFour").GetComponent<Image>().enabled = false;
            GameObject.Find("SecurityLevelFive").GetComponent<Image>().enabled = true;
            GameObject.Find("UpgradeSecurityMoneyText").GetComponent<Text>().text = null;
            GameObject.Find("UpgradeSecurityLevelText").GetComponent<Text>().enabled = false;
        }
    }

    void CapMorale()
    {
        if (staffMorale < 0f)
        {
            staffMorale = 0f;
        }
        if (publicMorale < 0f)
        {
            publicMorale = 0f;
        }
        if (staffMorale > 100f)
        {
            staffMorale = 100f;
        }
        if (publicMorale > 100f)
        {
            publicMorale = 100f;
        }
    }

    void ChangeLoanButtonAmounts()
    {
        GameObject.Find("SMGain").GetComponent<Text>().text = "+ " + (year * 5f).ToString() + " Public Morale";
        GameObject.Find("LoanAmount").GetComponent<Text>().text = "- " + (year * 15000f).ToString() + " P";
        GameObject.Find("SMLoss").GetComponent<Text>().text = "- " + (year * 5f).ToString() + " Public Morale";
    }

    void Update()
    {
        if (GetComponent<TurnManager>().endPhase == false)
        {
            SetSecurityIndicator();
            SetResourceUIValues();
            CapMorale();
            ChangeLoanButtonAmounts();
        }
    }

}
