using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{

    public int      turnNumber,
                    quarter;
    public bool     nextTurn,
                    endPhase,
                    eventCheck,
                    actionCheck,
                    checkedTurn,
                    playedSound;
    public string   yearOrYears,
                    quarterOrQuarters,
                    endText;
    public AudioClip    gameOverSound,
                        victorySound;
    public AudioSource  soundSource;

    void Start ()
    {
        turnNumber = 1;
        quarter = 1;
        nextTurn = false;
        endPhase = false;
        eventCheck = false;
        actionCheck = false;
        checkedTurn = false;
        playedSound = false;
        TurnCheck();
    }
	
    public void TurnCounter ()
    {
        if (nextTurn == true && endPhase == false) {

            if (turnNumber <= 5) {
                turnNumber += 1;
                nextTurn = false;
                TurnCheck();
            }

            else {
                AddIncome();
                if (quarter <= 3) {
                    turnNumber = 1;
                    quarter += 1;
                    nextTurn = false;
                    TurnCheck();
                }

                else {
                    if (GetComponent<ResourceManager>().year <= 2)
                    {
                        turnNumber = 1;
                        quarter = 1;
                        GetComponent<ResourceManager>().year += 1;
                        nextTurn = false;
                        TurnCheck();
                    }
                    else
                    {
                        quarter = 1;
                        GetComponent<ResourceManager>().year += 1;
                        nextTurn = false;
                        endPhase = true;
                    }
                }
            }
        }
    }

    void TurnCheck()
    {
        if (checkedTurn == false)
        {
            checkedTurn = true;
            if (turnNumber % 2 == 0)
            {
                eventCheck = false;
                actionCheck = true;
                GetComponent<CallActions>().ableToAct = true;
            }
            else
            {
                eventCheck = true;
                actionCheck = false;
                GetComponent<CallEvents>().playedSound = false;
                GetComponent<CallEvents>().getEvent = true;
                GetComponent<CallEvents>().changedResponse = false;
            }
        }        
    }

    void UpdateEndText()
    {
        if (endPhase == false)
        {
            if (GetComponent<ResourceManager>().year == 1)
            {
                yearOrYears = null;
            }
            if (GetComponent<ResourceManager>().year == 2)
            {
                yearOrYears = "one year";
            }
            if (GetComponent<ResourceManager>().year == 3)
            {
                yearOrYears = "two years";
            }
            if (quarter == 1)
            {
                quarterOrQuarters = null;
            }
            if (quarter == 2)
            {
                quarterOrQuarters = "one quarter";
            }
            if (quarter == 3)
            {
                quarterOrQuarters = "two quarters";
            }
            if (quarter == 4)
            {
                quarterOrQuarters = "three quarters";
            }
            if (yearOrYears == null && quarterOrQuarters == null)
            {
                endText = "How...? The year's just started, and we're already bankrupt... Oh dear...";
            }
            if (yearOrYears == null && quarterOrQuarters != null)
            {
                endText = "Blast! After just " + quarterOrQuarters + ", we've gone bankrupt!";
            }
            if (yearOrYears != null && quarterOrQuarters == null)
            {
                endText = "Blast! After " + yearOrYears + ", we've gone bankrupt!";
            }
            if (yearOrYears != null && quarterOrQuarters != null)
            {
                endText = "Blast! After " + yearOrYears + " and " + quarterOrQuarters + ", we've gone bankrupt!";
            }
        }
    }

    void AddIncome()
    {
        GetComponent<ResourceManager>().money += GetComponent<ResourceManager>().baseIncome * GetComponent<ResourceManager>().staffMorale / 100f;
        if (GetComponent<ResourceManager>().staffMorale > GetComponent<ResourceManager>().staffThreshold)
        {
            GetComponent<ResourceManager>().publicMorale += (GetComponent<ResourceManager>().staffMorale - GetComponent<ResourceManager>().staffThreshold) / 100f * GetComponent<ResourceManager>().publicMorale;
        }
    }

    void UpdateQuarterText()
    {
        GameObject.Find("QuarterText").GetComponent<Text>().text = "Q" + quarter.ToString() + " " + (2017f + GetComponent<ResourceManager>().year).ToString();
        GameObject.Find("QuarterTextBlack").GetComponent<Text>().text = "Q" + quarter.ToString() + " " + (2017f + GetComponent<ResourceManager>().year).ToString();
    }

    void CheckForGameOver()
    {
        if (GetComponent<ResourceManager>().money < 0f)
        {
            GetComponent<ResourceManager>().money = 0f;
            endPhase = true;
        }
    }

    void EndPhase()
    {
        if (endPhase)
        {
            if (GetComponent<ResourceManager>().year != 4)
            {
                if (playedSound == false)
                {
                    playedSound = true;
                    soundSource.PlayOneShot(victorySound, 1f);
                }
                if (GetComponent<ResourceManager>().money < 0)
                {
                    GetComponent<ResourceManager>().money = 0;
                }
                GameObject.Find("MoneyText").GetComponent<Text>().text = GetComponent<ResourceManager>().money.ToString();
                GameObject.Find("StaffMoralePercentage").GetComponent<Text>().text = GetComponent<ResourceManager>().staffMorale.ToString();
                GameObject.Find("StaffMoralePercentageBlack").GetComponent<Text>().text = GetComponent<ResourceManager>().staffMorale.ToString();
                GameObject.Find("StaffMoraleBar").GetComponent<RectTransform>().sizeDelta = new Vector2(679f * GetComponent<ResourceManager>().staffMorale / 100, 25f);
                GameObject.Find("PublicMoralePercentage").GetComponent<Text>().text = GetComponent<ResourceManager>().publicMorale.ToString();
                GameObject.Find("PublicMoralePercentageBlack").GetComponent<Text>().text = GetComponent<ResourceManager>().publicMorale.ToString();
                GameObject.Find("PublicMoraleBar").GetComponent<RectTransform>().sizeDelta = new Vector2(679f * GetComponent<ResourceManager>().publicMorale / 100, 32f);

                GameObject.Find("EventBubbleRed").transform.position = GetComponent<CallEvents>().eBubbleRedPos;
                GameObject.Find("EventBubbleBlue").transform.position = GetComponent<CallEvents>().offPos;
                GameObject.Find("LoanBubble").transform.position = GetComponent<CallEvents>().offPos;

                GameObject.Find("EventBubbleRed").GetComponent<CanvasGroup>().alpha = 1f;
                GameObject.Find("EventBubbleBlue").GetComponent<CanvasGroup>().alpha = 0f;
                GameObject.Find("LoanBubble").GetComponent<CanvasGroup>().alpha = 0f;

                GameObject.Find("EventText").GetComponent<Text>().text = endText;

                GameObject.Find("JeffSad").GetComponent<Image>().enabled = true;
                GameObject.Find("JeffHappy").GetComponent<Image>().enabled = false;
                GameObject.Find("RobberHappy").GetComponent<Image>().enabled = false;
                GameObject.Find("RobberSad").GetComponent<Image>().enabled = false;

                GameObject.Find("Okay").GetComponent<CanvasGroup>().alpha = 0f;
                GameObject.Find("Okay").GetComponent<Button>().enabled = false;
                GameObject.Find("Okay").transform.position = GetComponent<CallEvents>().offPos;
                GameObject.Find("Accept").GetComponent<CanvasGroup>().alpha = 0f;
                GameObject.Find("Accept").GetComponent<Button>().enabled = false;
                GameObject.Find("Accept").transform.position = GetComponent<CallEvents>().offPos;
                GameObject.Find("Deny").GetComponent<CanvasGroup>().alpha = 0f;
                GameObject.Find("Deny").GetComponent<Button>().enabled = false;
                GameObject.Find("Deny").transform.position = GetComponent<CallEvents>().offPos;

                GameObject.Find("ActionBubble").GetComponent<CanvasGroup>().alpha = 0f;
                GameObject.Find("ResponseText").GetComponent<Text>().text = null;

                GameObject.Find("ActionBarOpen").GetComponent<CanvasGroup>().alpha = 0f;

                GameObject.Find("DoNothing").GetComponent<Button>().enabled = false;
                GameObject.Find("Promote").GetComponent<Button>().enabled = false;
                GameObject.Find("UpgradeSecurity").GetComponent<Button>().enabled = false;
                GameObject.Find("Advertise").GetComponent<Button>().enabled = false;
                GameObject.Find("Hire").GetComponent<Button>().enabled = false;
                GameObject.Find("Fire").GetComponent<Button>().enabled = false;
            }
            else
            {
                if (playedSound == false)
                {
                    playedSound = true;
                    soundSource.PlayOneShot(gameOverSound, 1f);
                }
                if (GetComponent<ResourceManager>().money < 0)
                {
                    GetComponent<ResourceManager>().money = 0;
                }

                GameObject.Find("MoneyText").GetComponent<Text>().text = GetComponent<ResourceManager>().money.ToString();
                GameObject.Find("StaffMoralePercentage").GetComponent<Text>().text = GetComponent<ResourceManager>().staffMorale.ToString();
                GameObject.Find("StaffMoralePercentageBlack").GetComponent<Text>().text = GetComponent<ResourceManager>().staffMorale.ToString();
                GameObject.Find("StaffMoraleBar").GetComponent<RectTransform>().sizeDelta = new Vector2(679f * GetComponent<ResourceManager>().staffMorale / 100, 25f);
                GameObject.Find("PublicMoralePercentage").GetComponent<Text>().text = GetComponent<ResourceManager>().publicMorale.ToString();
                GameObject.Find("PublicMoralePercentageBlack").GetComponent<Text>().text = GetComponent<ResourceManager>().publicMorale.ToString();
                GameObject.Find("PublicMoraleBar").GetComponent<RectTransform>().sizeDelta = new Vector2(679f * GetComponent<ResourceManager>().publicMorale / 100, 32f);

                GameObject.Find("EventBubbleBlue").transform.position = GetComponent<CallEvents>().eBubbleBluePos;
                GameObject.Find("EventBubbleRed").transform.position = GetComponent<CallEvents>().offPos;
                GameObject.Find("LoanBubble").transform.position = GetComponent<CallEvents>().offPos;

                GameObject.Find("EventBubbleBlue").GetComponent<CanvasGroup>().alpha = 1f;
                GameObject.Find("EventBubbleRed").GetComponent<CanvasGroup>().alpha = 0f;
                GameObject.Find("LoanBubble").GetComponent<CanvasGroup>().alpha = 0f;

                GameObject.Find("EventText").GetComponent<Text>().text = "Splendid! You made it to the end of the three-year term, and we're left with " + GetComponent<ResourceManager>().money + " P! Good work!";

                GameObject.Find("JeffHappy").GetComponent<Image>().enabled = true;
                GameObject.Find("JeffSad").GetComponent<Image>().enabled = false;
                GameObject.Find("RobberHappy").GetComponent<Image>().enabled = false;
                GameObject.Find("RobberSad").GetComponent<Image>().enabled = false;

                GameObject.Find("Okay").GetComponent<CanvasGroup>().alpha = 0f;
                GameObject.Find("Okay").GetComponent<Button>().enabled = false;
                GameObject.Find("Okay").transform.position = GetComponent<CallEvents>().offPos;
                GameObject.Find("Accept").GetComponent<CanvasGroup>().alpha = 0f;
                GameObject.Find("Accept").GetComponent<Button>().enabled = false;
                GameObject.Find("Accept").transform.position = GetComponent<CallEvents>().offPos;
                GameObject.Find("Deny").GetComponent<CanvasGroup>().alpha = 0f;
                GameObject.Find("Deny").GetComponent<Button>().enabled = false;
                GameObject.Find("Deny").transform.position = GetComponent<CallEvents>().offPos;

                GameObject.Find("ActionBubble").GetComponent<CanvasGroup>().alpha = 0f;
                GameObject.Find("ResponseText").GetComponent<Text>().text = null;

                GameObject.Find("ActionBarOpen").GetComponent<CanvasGroup>().alpha = 0f;

                GameObject.Find("DoNothing").GetComponent<Button>().enabled = false;
                GameObject.Find("Promote").GetComponent<Button>().enabled = false;
                GameObject.Find("UpgradeSecurity").GetComponent<Button>().enabled = false;
                GameObject.Find("Advertise").GetComponent<Button>().enabled = false;
                GameObject.Find("Hire").GetComponent<Button>().enabled = false;
                GameObject.Find("Fire").GetComponent<Button>().enabled = false;
            }
        }
    }

	void Update ()
    {
        UpdateQuarterText();
        UpdateEndText();
        CheckForGameOver();
        TurnCounter();
        EndPhase();
    }

}
