using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallActions : MonoBehaviour
{

    public bool     doNothing,
                    promote,
                    upgradeSecurityOne,
                    upgradeSecurityTwo,
                    upgradeSecurityThree,
                    upgradeSecurityFour,
                    advertisement,
                    hire,
                    fire,

                    checkDoNothing,
                    checkPromote,
                    checkUpgradeSecurityOne,
                    checkUpgradeSecurityTwo,
                    checkUpgradeSecurityThree,
                    checkUpgradeSecurityFour,
                    checkAdvertisement,
                    checkHire,
                    checkFire,

                    canConfirm,
                    yes,
                    no,

                    actionTurn,
                    ableToAct,
                    showText;
    public string   displayText;
    public Button   dNButton,
                    pButton,
                    uSButton,
                    aButton,
                    hButton,
                    fButton,

                    yButton,
                    nButton;

    public Vector3  offPos,
                    yesPos,
                    noPos,
                    aBubblePos;

    public float[]  currentAction;

    public AudioSource  soundSource;
    public AudioClip    positiveEventSound,
                        negativeEventSound;

    void Start ()
    {
        doNothing = false;
        promote = false;
        upgradeSecurityOne = false;
        upgradeSecurityTwo = false;
        upgradeSecurityThree = false;
        upgradeSecurityFour = false;
        advertisement = false;
        hire = false;
        fire = false;

        checkDoNothing = false;
        checkPromote = false;
        checkUpgradeSecurityOne = false;
        checkUpgradeSecurityTwo = false;
        checkUpgradeSecurityThree = false;
        checkUpgradeSecurityFour = false;
        checkAdvertisement = false;
        checkHire = false;
        checkFire = false;

        canConfirm = false;
        yes = false;
        no = false;

        ableToAct = false;
        currentAction = new float[5];

        yesPos = GameObject.Find("Yes").transform.position;
        noPos = GameObject.Find("No").transform.position;
        aBubblePos = GameObject.Find("ActionBubble").transform.position;
        offPos.x = 9999f; offPos.y = 9999f; offPos.z = 9999f;
    }

    public void TriggerAction()
    {
        actionTurn = GetComponent<TurnManager>().actionCheck;
        if (actionTurn && ableToAct)
        {
            if (doNothing)
            {
                SetCurrentAction(0);
                displayText = GetComponent<Responses>().responseArray[(int)GetComponent<ActionsManager>().actionsList[0][4]];
                showText = true;
                ableToAct = false;
                canConfirm = true;
                checkDoNothing = true;
            }

            if (promote)
            {
                SetCurrentAction(1);
                displayText = GetComponent<Responses>().responseArray[(int)GetComponent<ActionsManager>().actionsList[1][4]];
                showText = true;
                ableToAct = false;
                canConfirm = true;
                checkPromote = true;
            }

            if (upgradeSecurityOne)
            {
                SetCurrentAction(2);
                displayText = GetComponent<Responses>().responseArray[(int)GetComponent<ActionsManager>().actionsList[2][4]];
                showText = true;
                ableToAct = false;
                canConfirm = true;
                checkUpgradeSecurityOne = true;
            }

            if (upgradeSecurityTwo)
            {
                SetCurrentAction(3);
                displayText = GetComponent<Responses>().responseArray[(int)GetComponent<ActionsManager>().actionsList[3][4]];
                showText = true;
                ableToAct = false;
                canConfirm = true;
                checkUpgradeSecurityTwo = true;
            }

            if (upgradeSecurityThree)
            {
                SetCurrentAction(4);
                displayText = GetComponent<Responses>().responseArray[(int)GetComponent<ActionsManager>().actionsList[4][4]];
                showText = true;
                ableToAct = false;
                canConfirm = true;
                checkUpgradeSecurityThree = true;
            }

            if (upgradeSecurityFour)
            {
                SetCurrentAction(5);
                displayText = GetComponent<Responses>().responseArray[(int)GetComponent<ActionsManager>().actionsList[5][4]];
                showText = true;
                ableToAct = false;
                canConfirm = true;
                checkUpgradeSecurityFour = true;
            }

            if (advertisement)
            {
                SetCurrentAction(6);
                displayText = GetComponent<Responses>().responseArray[(int)GetComponent<ActionsManager>().actionsList[6][4]];
                showText = true;
                ableToAct = false;
                canConfirm = true;
                checkAdvertisement = true;
            }

            if (hire)
            {
                SetCurrentAction(7);
                displayText = GetComponent<Responses>().responseArray[(int)GetComponent<ActionsManager>().actionsList[7][4]];
                showText = true;
                ableToAct = false;
                canConfirm = true;
                checkHire = true;
            }

            if (fire)
            {
                SetCurrentAction(8);
                displayText = GetComponent<Responses>().responseArray[(int)GetComponent<ActionsManager>().actionsList[8][4]];
                showText = true;
                ableToAct = false;
                canConfirm = true;
                checkFire = true;
            }
        }
    }

    void SetCurrentAction(int indexNo)
    {
        currentAction[0] = GetComponent<ActionsManager>().actionsList[indexNo][0];
        currentAction[1] = GetComponent<ActionsManager>().actionsList[indexNo][1];
        currentAction[2] = GetComponent<ActionsManager>().actionsList[indexNo][2];
        currentAction[3] = GetComponent<ActionsManager>().actionsList[indexNo][3];
        currentAction[4] = GetComponent<ActionsManager>().actionsList[indexNo][4];
    }

    void ClearCurrentAction()
    {
        currentAction[0] = 0f;
        currentAction[1] = 0f;
        currentAction[2] = 0f;
        currentAction[3] = 0f;
        currentAction[4] = 0f;
    }

    void ToggleButtonsActive()
    {
        if (canConfirm == false)
        {
            GameObject.Find("Yes").GetComponent<CanvasGroup>().alpha = 0f;
            GameObject.Find("Yes").GetComponent<Button>().enabled = false;
            GameObject.Find("No").GetComponent<CanvasGroup>().alpha = 0f;
            GameObject.Find("No").GetComponent<Button>().enabled = false;
        }
        if (canConfirm == true)
        {
            GameObject.Find("Yes").GetComponent<CanvasGroup>().alpha = 1f;
            GameObject.Find("Yes").GetComponent<Button>().enabled = true;
            GameObject.Find("No").GetComponent<CanvasGroup>().alpha = 1f;
            GameObject.Find("No").GetComponent<Button>().enabled = true;

            if (GetComponent<SpeechManager>().yes && GetComponent<SpeechManager>().takeVoiceInput)
            {
                SetYes();
            }
            if (GetComponent<SpeechManager>().no && GetComponent<SpeechManager>().takeVoiceInput)
            {
                SetNo();
            }
        }
        if (ableToAct == false)
        {
            if (actionTurn)
            {
                GameObject.Find("ActionBarOpen").GetComponent<CanvasGroup>().alpha = 1f;
            }
            else if (actionTurn == false)
            {
                GameObject.Find("ActionBarOpen").GetComponent<CanvasGroup>().alpha = 0f;
            }
            GameObject.Find("DoNothing").GetComponent<Button>().enabled = false;
            GameObject.Find("Promote").GetComponent<Button>().enabled = false;
            GameObject.Find("UpgradeSecurity").GetComponent<Button>().enabled = false;
            GameObject.Find("Advertise").GetComponent<Button>().enabled = false;
            GameObject.Find("Hire").GetComponent<Button>().enabled = false;
            GameObject.Find("Fire").GetComponent<Button>().enabled = false;
        }
        if (ableToAct == true)
        {
            GameObject.Find("ActionBarOpen").GetComponent<CanvasGroup>().alpha = 1f;
            GameObject.Find("DoNothing").GetComponent<Button>().enabled = true;
            GameObject.Find("Promote").GetComponent<Button>().enabled = true;
            GameObject.Find("UpgradeSecurity").GetComponent<Button>().enabled = true;
            GameObject.Find("Advertise").GetComponent<Button>().enabled = true;
            GameObject.Find("Hire").GetComponent<Button>().enabled = true;
            GameObject.Find("Fire").GetComponent<Button>().enabled = true;

            if (GetComponent<SpeechManager>().doNothing && GetComponent<SpeechManager>().takeVoiceInput)
            {
                SetDoNothing();
            }
            if (GetComponent<SpeechManager>().promote && GetComponent<SpeechManager>().takeVoiceInput)
            {
                SetPromote();
            }
            if (GetComponent<SpeechManager>().upgradeSecurity && GetComponent<SpeechManager>().takeVoiceInput)
            {
                SetUpgradeSecurity();
            }
            if (GetComponent<SpeechManager>().advertise && GetComponent<SpeechManager>().takeVoiceInput)
            {
                SetAdvertisement();
            }
            if (GetComponent<SpeechManager>().hire && GetComponent<SpeechManager>().takeVoiceInput)
            {
                SetHire();
            }
            if (GetComponent<SpeechManager>().fire && GetComponent<SpeechManager>().takeVoiceInput)
            {
                SetFire();
            }
        }
    }

    void GetButtonInputs()
    {
        dNButton = GameObject.Find("DoNothing").GetComponent<Button>();
        pButton = GameObject.Find("Promote").GetComponent<Button>();
        uSButton = GameObject.Find("UpgradeSecurity").GetComponent<Button>();
        aButton = GameObject.Find("Advertise").GetComponent<Button>();
        hButton = GameObject.Find("Hire").GetComponent<Button>();
        fButton = GameObject.Find("Fire").GetComponent<Button>();

        yButton = GameObject.Find("Yes").GetComponent<Button>();
        nButton = GameObject.Find("No").GetComponent<Button>();

        dNButton.onClick.AddListener(SetDoNothing);
        pButton.onClick.AddListener(SetPromote);
        uSButton.onClick.AddListener(SetUpgradeSecurity);
        aButton.onClick.AddListener(SetAdvertisement);
        hButton.onClick.AddListener(SetHire);
        fButton.onClick.AddListener(SetFire);

        yButton.onClick.AddListener(SetYes);
        nButton.onClick.AddListener(SetNo);        
    }

    void SetYes()
    {
        yes = true;
        no = false;
        GetComponent<SpeechManager>().takeVoiceInput = false;
        GetComponent<SpeechManager>().input = null;
        GetComponent<SpeechManager>().inputAnal = null;
        StartCoroutine(TakeVoiceInput());
    }

    void SetNo()
    {
        no = true;
        yes = false;
        GetComponent<SpeechManager>().takeVoiceInput = false;
        GetComponent<SpeechManager>().input = null;
        GetComponent<SpeechManager>().inputAnal = null;
        StartCoroutine(TakeVoiceInput());
    }

    void SetDoNothing()
    {
        doNothing = true;
        GetComponent<SpeechManager>().takeVoiceInput = false;
        GetComponent<SpeechManager>().input = null;
        GetComponent<SpeechManager>().inputAnal = null;
        StartCoroutine(TakeVoiceInput());
    }

    void SetPromote()
    {
        promote = true;
        GetComponent<SpeechManager>().takeVoiceInput = false;
        GetComponent<SpeechManager>().input = null;
        GetComponent<SpeechManager>().inputAnal = null;
        StartCoroutine(TakeVoiceInput());
    }

    void SetUpgradeSecurity()
    {
        if (GetComponent<ResourceManager>().securityLevel == 1f)
        {
            upgradeSecurityOne = true;
        }
        if (GetComponent<ResourceManager>().securityLevel == 2f)
        {
            upgradeSecurityTwo = true;
        }
        if (GetComponent<ResourceManager>().securityLevel == 3f)
        {
            upgradeSecurityThree = true;
        }
        if (GetComponent<ResourceManager>().securityLevel == 4f)
        {
            upgradeSecurityFour = true;
        }
        GetComponent<SpeechManager>().takeVoiceInput = false;
        GetComponent<SpeechManager>().input = null;
        GetComponent<SpeechManager>().inputAnal = null;
        StartCoroutine(TakeVoiceInput());
    }

    void SetAdvertisement()
    {
        advertisement = true;
        GetComponent<SpeechManager>().takeVoiceInput = false;
        GetComponent<SpeechManager>().input = null;
        GetComponent<SpeechManager>().inputAnal = null;
        StartCoroutine(TakeVoiceInput());
    }

    void SetHire()
    {
        hire = true;
        GetComponent<SpeechManager>().takeVoiceInput = false;
        GetComponent<SpeechManager>().input = null;
        GetComponent<SpeechManager>().inputAnal = null;
        StartCoroutine(TakeVoiceInput());
    }

    void SetFire()
    {
        fire = true;
        GetComponent<SpeechManager>().takeVoiceInput = false;
        GetComponent<SpeechManager>().input = null;
        GetComponent<SpeechManager>().inputAnal = null;
        StartCoroutine(TakeVoiceInput());
    }

    void SetResponseText()
    {
        GameObject.Find("ResponseText").GetComponent<Text>().text = displayText;
        if (showText == false)
        {
            GameObject.Find("ActionBubble").GetComponent<CanvasGroup>().alpha = 0f;
        }
        else
        {
            GameObject.Find("ActionBubble").GetComponent<CanvasGroup>().alpha = 1f;
        }
    }

    void CheckSelection()
    {
        if (checkDoNothing)
        {
            if (yes && GetComponent<ResourceManager>().money >= -currentAction[0])
            {
                canConfirm = false;
                yes = false;
                GetComponent<ResourceManager>().money += currentAction[0];
                GetComponent<ResourceManager>().securityLevel += currentAction[1];
                GetComponent<ResourceManager>().staffMorale += currentAction[2];
                GetComponent<ResourceManager>().publicMorale += currentAction[3];
                doNothing = false;
                displayText = null;
                showText = false;
                checkDoNothing = false;
                GetComponent<TurnManager>().nextTurn = true;
                GetComponent<TurnManager>().checkedTurn = false;
            }
            if (no)
            {
                canConfirm = false;
                no = false;
                ClearCurrentAction();
                ableToAct = true;
                doNothing = false;
                displayText = null;
                showText = false;
                checkDoNothing = false;
            }
        }
        else if (checkPromote)
        {
            if (yes && GetComponent<ResourceManager>().money >= -currentAction[0])
            {
                canConfirm = false;
                yes = false;
                GetComponent<ResourceManager>().money += currentAction[0];
                GetComponent<ResourceManager>().securityLevel += currentAction[1];
                GetComponent<ResourceManager>().staffMorale += currentAction[2];
                GetComponent<ResourceManager>().publicMorale += currentAction[3];
                promote = false;
                displayText = null;
                showText = false;
                checkPromote = false;
                GetComponent<TurnManager>().nextTurn = true;
                GetComponent<TurnManager>().checkedTurn = false;
            }
            if (no)
            {
                canConfirm = false;
                no = false;
                ClearCurrentAction();
                ableToAct = true;
                promote = false;
                displayText = null;
                showText = false;
                checkPromote = false;
            }
        }
        else if (checkUpgradeSecurityOne)
        {
            if (yes && GetComponent<ResourceManager>().money >= -currentAction[0])
            {
                canConfirm = false;
                yes = false;
                GetComponent<ResourceManager>().money += currentAction[0];
                GetComponent<ResourceManager>().securityLevel += currentAction[1];
                GetComponent<ResourceManager>().staffMorale += currentAction[2];
                GetComponent<ResourceManager>().publicMorale += currentAction[3];
                upgradeSecurityOne = false;
                displayText = null;
                showText = false;
                checkUpgradeSecurityOne = false;
                GetComponent<TurnManager>().nextTurn = true;
                GetComponent<TurnManager>().checkedTurn = false;
            }
            if (no)
            {
                canConfirm = false;
                no = false;
                ClearCurrentAction();
                ableToAct = true;
                upgradeSecurityOne = false;
                displayText = null;
                showText = false;
                checkUpgradeSecurityOne = false;
            }
        }
        else if (checkUpgradeSecurityTwo)
        {
            if (yes && GetComponent<ResourceManager>().money >= -currentAction[0])
            {
                canConfirm = false;
                yes = false;
                GetComponent<ResourceManager>().money += currentAction[0];
                GetComponent<ResourceManager>().securityLevel += currentAction[1];
                GetComponent<ResourceManager>().staffMorale += currentAction[2];
                GetComponent<ResourceManager>().publicMorale += currentAction[3];
                upgradeSecurityTwo = false;
                displayText = null;
                showText = false;
                checkUpgradeSecurityTwo = false;
                GetComponent<TurnManager>().nextTurn = true;
                GetComponent<TurnManager>().checkedTurn = false;
            }
            if (no)
            {
                canConfirm = false;
                no = false;
                ClearCurrentAction();
                ableToAct = true;
                upgradeSecurityTwo = false;
                displayText = null;
                showText = false;
                checkUpgradeSecurityTwo = false;
            }
        }
        else if (checkUpgradeSecurityThree)
        {
            if (yes && GetComponent<ResourceManager>().money >= -currentAction[0])
            {
                canConfirm = false;
                yes = false;
                GetComponent<ResourceManager>().money += currentAction[0];
                GetComponent<ResourceManager>().securityLevel += currentAction[1];
                GetComponent<ResourceManager>().staffMorale += currentAction[2];
                GetComponent<ResourceManager>().publicMorale += currentAction[3];
                upgradeSecurityThree = false;
                displayText = null;
                showText = false;
                checkUpgradeSecurityThree = false;
                GetComponent<TurnManager>().nextTurn = true;
                GetComponent<TurnManager>().checkedTurn = false;
            }
            if (no)
            {
                canConfirm = false;
                no = false;
                ClearCurrentAction();
                ableToAct = true;
                upgradeSecurityThree = false;
                displayText = null;
                showText = false;
                checkUpgradeSecurityThree = false;
            }
        }
        else if (checkUpgradeSecurityFour)
        {
            if (yes && GetComponent<ResourceManager>().money >= -currentAction[0])
            {
                canConfirm = false;
                yes = false;
                GetComponent<ResourceManager>().money += currentAction[0];
                GetComponent<ResourceManager>().securityLevel += currentAction[1];
                GetComponent<ResourceManager>().staffMorale += currentAction[2];
                GetComponent<ResourceManager>().publicMorale += currentAction[3];
                upgradeSecurityFour = false;
                displayText = null;
                showText = false;
                checkUpgradeSecurityFour = false;
                GetComponent<TurnManager>().nextTurn = true;
                GetComponent<TurnManager>().checkedTurn = false;
            }
            if (no)
            {
                canConfirm = false;
                no = false;
                ClearCurrentAction();
                ableToAct = true;
                upgradeSecurityFour = false;
                displayText = null;
                showText = false;
                checkUpgradeSecurityFour = false;
            }
        }
        else if (checkAdvertisement)
        {
            if (yes && GetComponent<ResourceManager>().money >= -currentAction[0])
            {
                canConfirm = false;
                yes = false;
                GetComponent<ResourceManager>().money += currentAction[0];
                GetComponent<ResourceManager>().securityLevel += currentAction[1];
                GetComponent<ResourceManager>().staffMorale += currentAction[2];
                GetComponent<ResourceManager>().publicMorale += currentAction[3];
                advertisement = false;
                displayText = null;
                showText = false;
                checkAdvertisement = false;
                GetComponent<TurnManager>().nextTurn = true;
                GetComponent<TurnManager>().checkedTurn = false;
            }
            if (no)
            {
                canConfirm = false;
                no = false;
                ClearCurrentAction();
                ableToAct = true;
                advertisement = false;
                displayText = null;
                showText = false;
                checkAdvertisement = false;
            }
        }
        else if (checkHire)
        {
            if (yes && GetComponent<ResourceManager>().money >= -currentAction[0])
            {
                canConfirm = false;
                yes = false;
                GetComponent<ResourceManager>().money += currentAction[0];
                GetComponent<ResourceManager>().securityLevel += currentAction[1];
                GetComponent<ResourceManager>().staffMorale += currentAction[2];
                GetComponent<ResourceManager>().publicMorale += currentAction[3];
                hire = false;
                displayText = null;
                showText = false;
                checkHire = false;
                GetComponent<TurnManager>().nextTurn = true;
                GetComponent<TurnManager>().checkedTurn = false;
            }
            if (no)
            {
                canConfirm = false;
                no = false;
                ClearCurrentAction();
                ableToAct = true;
                hire = false;
                displayText = null;
                showText = false;
                checkHire = false;
            }
        }
        else if (checkFire)
        {
            if (yes && GetComponent<ResourceManager>().money >= -currentAction[0])
            {
                canConfirm = false;
                yes = false;
                GetComponent<ResourceManager>().money += currentAction[0];
                GetComponent<ResourceManager>().securityLevel += currentAction[1];
                GetComponent<ResourceManager>().staffMorale += currentAction[2];
                GetComponent<ResourceManager>().publicMorale += currentAction[3];
                fire = false;
                displayText = null;
                showText = false;
                checkFire = false;
                GetComponent<TurnManager>().nextTurn = true;
                GetComponent<TurnManager>().checkedTurn = false;
            }
            if (no)
            {
                canConfirm = false;
                no = false;
                ClearCurrentAction();
                ableToAct = true;
                fire = false;
                displayText = null;
                showText = false;
                checkFire = false;
            }
        }
    }

    void ShowHideJeff()
    {
        if(canConfirm && actionTurn)
        {
            GameObject.Find("JeffHappy").GetComponent<Image>().enabled = true;
            GameObject.Find("JeffSad").GetComponent<Image>().enabled = false;
            GameObject.Find("RobberHappy").GetComponent<Image>().enabled = false;
            GameObject.Find("RobberSad").GetComponent<Image>().enabled = false;
        }
        if (canConfirm == false && actionTurn)
        {
            GameObject.Find("JeffHappy").GetComponent<Image>().enabled = false;
            GameObject.Find("JeffSad").GetComponent<Image>().enabled = false;
            GameObject.Find("RobberHappy").GetComponent<Image>().enabled = false;
            GameObject.Find("RobberSad").GetComponent<Image>().enabled = false;
        }
    }

    IEnumerator TakeVoiceInput()
    {
        yield return new WaitForSeconds(2.5f);
        GetComponent<SpeechManager>().input = null;
        GetComponent<SpeechManager>().inputAnal = null;
        GetComponent<SpeechManager>().takeVoiceInput = true;
    }

    void Update ()
    {
        if (GetComponent<TurnManager>().endPhase == false)
        {
            TriggerAction();
            GetButtonInputs();
            ToggleButtonsActive();
            SetResponseText();
            CheckSelection();
            ShowHideJeff();
        }
	}
}
