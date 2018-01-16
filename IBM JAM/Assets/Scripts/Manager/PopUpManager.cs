using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpManager : MonoBehaviour
{

    public GameObject   popUpCanvas,
                        moneyPopUpText,
                        staffMoralePopUpText,
                        publicMoralePopUpText;
    public float        currentMoney,
                        tempMoney,
                        moneyChange,
                        currentStaffMorale,
                        tempStaffMorale,
                        staffMoraleChange,
                        currentPublicMorale,
                        tempPublicMorale,
                        publicMoraleChange;
    public string       moneyText,
                        staffMoraleText,
                        publicMoraleText;
    public Vector3      moneyPos,
                        staffMoralePos,
                        publicMoralePos,
                        nullVector;


	void Start ()
    {
        popUpCanvas = GameObject.Find("PopUps");
        nullVector.x = 0f; nullVector.y = 0f; nullVector.z = 0f;
        moneyPos.x = -580f; moneyPos.y = 415f; moneyPos.z = 0f;
        staffMoralePos.x = 50f; staffMoralePos.y = 420f; staffMoralePos.z = 0f;
        publicMoralePos.x = 50f; publicMoralePos.y = 325f; publicMoralePos.z = 0f;
        currentMoney = 80000f;
        currentStaffMorale = 50f;
        currentPublicMorale = 50f;
	}

    void MoneyPopUp()
    {
        tempMoney = GetComponent<ResourceManager>().money;
        if (currentMoney != tempMoney)
        {
            moneyChange = tempMoney - currentMoney;
            GameObject moneyPopUp = Instantiate(moneyPopUpText, moneyPos, Quaternion.identity);
            moneyPopUp.transform.SetParent(popUpCanvas.transform, false);
            if (moneyChange > 0f)
            {
                moneyPopUp.GetComponent<Text>().text = "+ " + moneyChange.ToString() + " P";
                moneyPopUp.GetComponent<Text>().color = Color.green;
            }
            if (moneyChange < 0f)
            {
                moneyPopUp.GetComponent<Text>().text = "- " + Mathf.Abs(moneyChange).ToString() + " P";
                moneyPopUp.GetComponent<Text>().color = Color.red;
            }
            moneyPopUp.GetComponent<Text>().CrossFadeAlpha(0f, 1.5f, false);
            StartCoroutine(LerpPopUp(moneyPopUp, moneyPos));
            StartCoroutine(DestroyPopUp(moneyPopUp));
            currentMoney = tempMoney;
        }
    }

    void StaffMoralePopUp()
    {
        tempStaffMorale = GetComponent<ResourceManager>().staffMorale;
        if (currentStaffMorale != tempStaffMorale)
        {
            staffMoraleChange = tempStaffMorale - currentStaffMorale;
            GameObject staffMoralePopUp = Instantiate(staffMoralePopUpText, staffMoralePos, Quaternion.identity);
            staffMoralePopUp.transform.SetParent(popUpCanvas.transform, false);
            if (staffMoraleChange > 0f)
            {
                staffMoralePopUp.GetComponent<Text>().text = "+ " + staffMoraleChange.ToString() + " Staff Morale";
                staffMoralePopUp.GetComponent<Text>().color = Color.green;
            }
            if (staffMoraleChange < 0f)
            {
                staffMoralePopUp.GetComponent<Text>().text = "- " + Mathf.Abs(staffMoraleChange).ToString() + " Staff Morale";
                staffMoralePopUp.GetComponent<Text>().color = Color.red;
            }
            staffMoralePopUp.GetComponent<Text>().CrossFadeAlpha(0f, 1.5f, false);
            StartCoroutine(LerpPopUp(staffMoralePopUp, staffMoralePos));
            StartCoroutine(DestroyPopUp(staffMoralePopUp));
            currentStaffMorale = tempStaffMorale;
        }
    }

    void PublicMoralePopUp()
    {
        tempPublicMorale = GetComponent<ResourceManager>().publicMorale;
        if (currentPublicMorale != tempPublicMorale)
        {
            publicMoraleChange = tempPublicMorale - currentPublicMorale;
            GameObject publicMoralePopUp = Instantiate(publicMoralePopUpText, publicMoralePos, Quaternion.identity);
            publicMoralePopUp.transform.SetParent(popUpCanvas.transform, false);
            if (publicMoraleChange > 0f)
            {
                publicMoralePopUp.GetComponent<Text>().text = "+ " + publicMoraleChange.ToString() + " Public Morale";
                publicMoralePopUp.GetComponent<Text>().color = Color.green;
            }
            if (publicMoraleChange < 0f)
            {
                publicMoralePopUp.GetComponent<Text>().text = "- " + Mathf.Abs(publicMoraleChange).ToString() + " Public Morale";
                publicMoralePopUp.GetComponent<Text>().color = Color.red;
            }
            publicMoralePopUp.GetComponent<Text>().CrossFadeAlpha(0f, 1.5f, false);
            StartCoroutine(LerpPopUp(publicMoralePopUp, publicMoralePos));
            StartCoroutine(DestroyPopUp(publicMoralePopUp));
            currentPublicMorale = tempPublicMorale;
        }
    }

    IEnumerator DestroyPopUp(GameObject popUp)
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(popUp);
    }

    IEnumerator LerpPopUp(GameObject popUp, Vector3 startPos)
    {
        float currentTime = 0f;
        float travelFraction;
        while (currentTime <= 1.5f)
        {
            currentTime += Time.deltaTime;
            travelFraction = currentTime / 1.5f;
            popUp.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(startPos, new Vector3(startPos.x, startPos.y + 40f, startPos.z), travelFraction);
            yield return null;
        }
    }

    void LateUpdate ()
    {
        MoneyPopUp();
        StaffMoralePopUp();
        PublicMoralePopUp();
	}
}
