using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallEvents : MonoBehaviour
{
    public int      randomNumber,
                    eventType; // 0 is positive, 1 is negative, 2 is loan, 3 is successful robbery, 4 is foiled robbery
    public float[]  currentEvent;
    public bool     accept,
                    deny,
                    okay,
                    decide,
                    showText,
                    changeValues,
                    getEvent,
                    changedResponse,
                    eventTurn,
                    playedSound;
    public string   displayText;
    public Button   acceptButton,
                    denyButton,
                    okayButton;
    public Vector3  offPos,
                    acceptPos,
                    denyPos,
                    okayPos,
                    eBubbleBluePos,
                    eBubbleRedPos,
                    lBubblePos;
    public AudioSource  soundSource;
    public AudioClip    positiveEventSound,
                        negativeEventSound;

    void Start()
    {
        currentEvent = new float[5];
        accept = false;
        deny = false;
        okay = false;
        decide = false;
        changedResponse = false;

        acceptButton = GameObject.Find("Accept").GetComponent<Button>();
        denyButton = GameObject.Find("Deny").GetComponent<Button>();
        okayButton = GameObject.Find("Okay").GetComponent<Button>();

        acceptPos = GameObject.Find("Accept").transform.position;
        denyPos = GameObject.Find("Deny").transform.position;
        okayPos = GameObject.Find("Okay").transform.position;
        eBubbleBluePos = GameObject.Find("EventBubbleBlue").transform.position;
        eBubbleRedPos = GameObject.Find("EventBubbleRed").transform.position;
        lBubblePos = GameObject.Find("LoanBubble").transform.position;
        offPos.x = 9999f; offPos.y = 9999f; offPos.z = 9999f;
    }

    public void GetCurrentEvent ()
    {
        eventTurn = GetComponent<TurnManager>().eventCheck;
        if (eventTurn)
        {
            if (getEvent)
            {
                getEvent = false;
                if (GetComponent<TurnManager>().turnNumber == 1 && GetComponent<TurnManager>().quarter == 4)
                {
                    SetCurrentEvent(49);
                }
                else
                {
                    randomNumber = Random.Range(0, 48);
                    SetCurrentEvent(randomNumber);
                }
            }            
            if (changedResponse == false)
            {
                if (currentEvent[1] == 2f && GetComponent<ResourceManager>().securityLevel >= 2)
                {
                    changedResponse = true;
                    currentEvent[0] = 0f;
                    currentEvent[2] = 0f;
                    currentEvent[3] = 0f;
                    currentEvent[4] += 1f;
                }

                else if (currentEvent[1] == 3f && GetComponent<ResourceManager>().securityLevel >= 3)
                {
                    changedResponse = true;
                    currentEvent[0] = 0f;
                    currentEvent[2] = 0f;
                    currentEvent[3] = 0f;
                    currentEvent[4] += 1f;
                }

                else if (currentEvent[1] == 4f && GetComponent<ResourceManager>().securityLevel >= 4)
                {
                    changedResponse = true;
                    currentEvent[0] = 0f;
                    currentEvent[2] = 0f;
                    currentEvent[3] = 0f;
                    currentEvent[4] += 1f;
                }

                else if (currentEvent[1] == 5f && GetComponent<ResourceManager>().securityLevel >= 5)
                {
                    changedResponse = true;
                    currentEvent[0] = 0f;
                    currentEvent[2] = 0f;
                    currentEvent[3] = 0f;
                    currentEvent[4] += 1f;
                }
            }
            SetEventType();
            PlayEventSound();
            if (currentEvent[1] == 0f)
            {
                decide = true;
                if (accept == true && deny == false)
                {
                    currentEvent[0] = -15000f * GetComponent<ResourceManager>().year;
                    currentEvent[3] = 5f * GetComponent<ResourceManager>().year;
                    accept = false;
                    changeValues = true;
                    okay = true;
                    decide = false;
                }
                else if (accept == false && deny == true)
                {
                    currentEvent[0] = 0f;
                    currentEvent[3] = -5f * GetComponent<ResourceManager>().year;
                    deny = false;
                    changeValues = true;
                    okay = true;
                    decide = false;
                }
            }
            if (currentEvent[1] != 0f)
            {
                if (okay)
                {
                    changeValues = true;
                    decide = false;
                }
            }
            showText = true;
        }
    }

    void SetEventText()
    {
        GameObject.Find("EventText").GetComponent<Text>().text = displayText;
        if (showText == false)
        {
            displayText = null;
            GameObject.Find("LoanBubble").GetComponent<CanvasGroup>().alpha = 0f;
            GameObject.Find("EventBubbleBlue").GetComponent<CanvasGroup>().alpha = 0f;
            GameObject.Find("EventBubbleRed").GetComponent<CanvasGroup>().alpha = 0f;
            GameObject.Find("Vault").GetComponent<SpriteRenderer>().enabled = false;

            GameObject.Find("EventBubbleBlue").transform.position = offPos;
            GameObject.Find("EventBubbleRed").transform.position = offPos;
            GameObject.Find("LoanBubble").transform.position = offPos; 
        }
        else
        {
            displayText = GetComponent<Responses>().responseArray[(int)currentEvent[4]];
            if (eventType == 0)
            {
                if (eventTurn)
                {
                    GameObject.Find("JeffHappy").GetComponent<Image>().enabled = true;
                    GameObject.Find("JeffSad").GetComponent<Image>().enabled = false;
                    GameObject.Find("RobberHappy").GetComponent<Image>().enabled = false;
                    GameObject.Find("RobberSad").GetComponent<Image>().enabled = false;
                }

                GameObject.Find("Vault").GetComponent<SpriteRenderer>().enabled = false;

                GameObject.Find("EventBubbleBlue").transform.position = eBubbleBluePos;
                GameObject.Find("EventBubbleRed").transform.position = offPos;
                GameObject.Find("LoanBubble").transform.position = offPos;

                GameObject.Find("EventBubbleBlue").GetComponent<CanvasGroup>().alpha = 1f;
                GameObject.Find("EventBubbleRed").GetComponent<CanvasGroup>().alpha = 0f;
                GameObject.Find("LoanBubble").GetComponent<CanvasGroup>().alpha = 0f;

            }
            else if (eventType == 1)
            {
                if (eventTurn)
                {
                    GameObject.Find("JeffSad").GetComponent<Image>().enabled = true;
                    GameObject.Find("JeffHappy").GetComponent<Image>().enabled = false;
                    GameObject.Find("RobberHappy").GetComponent<Image>().enabled = false;
                    GameObject.Find("RobberSad").GetComponent<Image>().enabled = false;
                }

                GameObject.Find("Vault").GetComponent<SpriteRenderer>().enabled = false;

                GameObject.Find("EventBubbleRed").transform.position = eBubbleRedPos;
                GameObject.Find("EventBubbleBlue").transform.position = offPos;
                GameObject.Find("LoanBubble").transform.position = offPos;

                GameObject.Find("EventBubbleRed").GetComponent<CanvasGroup>().alpha = 1f;
                GameObject.Find("EventBubbleBlue").GetComponent<CanvasGroup>().alpha = 0f;
                GameObject.Find("LoanBubble").GetComponent<CanvasGroup>().alpha = 0f;
            }
            else if (eventType == 2)
            {
                if (eventTurn)
                {
                    GameObject.Find("JeffHappy").GetComponent<Image>().enabled = true;
                    GameObject.Find("JeffSad").GetComponent<Image>().enabled = false;
                    GameObject.Find("RobberHappy").GetComponent<Image>().enabled = false;
                    GameObject.Find("RobberSad").GetComponent<Image>().enabled = false;
                }

                GameObject.Find("Vault").GetComponent<SpriteRenderer>().enabled = false;

                GameObject.Find("LoanBubble").transform.position = lBubblePos;
                GameObject.Find("EventBubbleBlue").transform.position = offPos;
                GameObject.Find("EventBubbleRed").transform.position = offPos;

                GameObject.Find("LoanBubble").GetComponent<CanvasGroup>().alpha = 1f;
                GameObject.Find("EventBubbleBlue").GetComponent<CanvasGroup>().alpha = 0f;
                GameObject.Find("EventBubbleRed").GetComponent<CanvasGroup>().alpha = 0f;
            }
            else if (eventType == 3)
            {
                if (eventTurn)
                {
                    GameObject.Find("JeffSad").GetComponent<Image>().enabled = true;
                    GameObject.Find("RobberHappy").GetComponent<Image>().enabled = true;
                    GameObject.Find("JeffHappy").GetComponent<Image>().enabled = false;
                    GameObject.Find("RobberSad").GetComponent<Image>().enabled = false;
                }

                GameObject.Find("Vault").GetComponent<SpriteRenderer>().enabled = true;

                GameObject.Find("EventBubbleRed").transform.position = eBubbleRedPos;
                GameObject.Find("EventBubbleBlue").transform.position = offPos;
                GameObject.Find("LoanBubble").transform.position = offPos;

                GameObject.Find("EventBubbleRed").GetComponent<CanvasGroup>().alpha = 1f;
                GameObject.Find("EventBubbleBlue").GetComponent<CanvasGroup>().alpha = 0f;
                GameObject.Find("LoanBubble").GetComponent<CanvasGroup>().alpha = 0f;
            }
            else if (eventType == 4)
            {
                if (eventTurn)
                {
                    GameObject.Find("JeffHappy").GetComponent<Image>().enabled = true;
                    GameObject.Find("RobberSad").GetComponent<Image>().enabled = true;
                    GameObject.Find("JeffSad").GetComponent<Image>().enabled = false;
                    GameObject.Find("RobberHappy").GetComponent<Image>().enabled = false;
                }

                GameObject.Find("Vault").GetComponent<SpriteRenderer>().enabled = true;

                GameObject.Find("EventBubbleBlue").transform.position = eBubbleBluePos;
                GameObject.Find("EventBubbleRed").transform.position = offPos;
                GameObject.Find("LoanBubble").transform.position = offPos;

                GameObject.Find("EventBubbleBlue").GetComponent<CanvasGroup>().alpha = 1f;
                GameObject.Find("EventBubbleRed").GetComponent<CanvasGroup>().alpha = 0f;
                GameObject.Find("LoanBubble").GetComponent<CanvasGroup>().alpha = 0f;
            }
        }
    }

    void SetCurrentEvent(int indexNo)
    {
        currentEvent[0] = GetComponent<EventsManager>().eventList[indexNo][0];
        currentEvent[1] = GetComponent<EventsManager>().eventList[indexNo][1];
        currentEvent[2] = GetComponent<EventsManager>().eventList[indexNo][2];
        currentEvent[3] = GetComponent<EventsManager>().eventList[indexNo][3];
        currentEvent[4] = GetComponent<EventsManager>().eventList[indexNo][4];
    }

    void ClearCurrentEvent()
    {
        currentEvent[0] = 0f;
        currentEvent[1] = 6f;
        currentEvent[2] = 0f;
        currentEvent[3] = 0f;
        currentEvent[4] = 0f;
    }

    void ChangeResourceValues()
    {
        if (changeValues)
        {
            changeValues = false;
            GetComponent<ResourceManager>().money += currentEvent[0];
            GetComponent<ResourceManager>().staffMorale += currentEvent[2];
            GetComponent<ResourceManager>().publicMorale += currentEvent[3];
        }
    }

    void EndEvent()
    {
        if (okay && eventTurn)
        {
            okay = false;
            ClearCurrentEvent();
            GetComponent<TurnManager>().nextTurn = true;
            GetComponent<TurnManager>().checkedTurn = false;
            showText = false;
        }
    }

    void SetEventType()
    {
        if (currentEvent[4] == 0f || currentEvent[4] == 5f || currentEvent[4] == 7f)
        {
            eventType = 0;
        }
        if (currentEvent[4] == 1f || currentEvent[4] == 6f || currentEvent[4] == 8f || currentEvent[4] == 9f || currentEvent[4] == 10f || currentEvent[4] == 11f)
        {
            eventType = 1;
        }
        if (currentEvent[4] == 4f)
        {
            eventType = 2;
        }
        if (currentEvent[4] == 2f)
        {
            eventType = 3;
        }
        if (currentEvent[4] == 3f)
        {
            eventType = 4;
        }
    }

    public void AllowResponseChange()
    {
        changedResponse = false;
    }

    void ToggleButtonsActive()
    {
        if (decide == false)
        {
            GameObject.Find("Accept").GetComponent<CanvasGroup>().alpha = 0f;
            GameObject.Find("Accept").GetComponent<Button>().enabled = false;
            GameObject.Find("Accept").transform.position = offPos;
            GameObject.Find("Deny").GetComponent<CanvasGroup>().alpha = 0f;
            GameObject.Find("Deny").GetComponent<Button>().enabled = false;
            GameObject.Find("Deny").transform.position = offPos;
        }
        if (decide)
        {
            if (GetComponent<SpeechManager>().accept && GetComponent<SpeechManager>().takeVoiceInput)
            {
                SetAccept();
            }
            if (GetComponent<SpeechManager>().deny && GetComponent<SpeechManager>().takeVoiceInput)
            {
                SetDeny();
            }
            GameObject.Find("Accept").GetComponent<CanvasGroup>().alpha = 1f;
            GameObject.Find("Accept").GetComponent<Button>().enabled = true;
            GameObject.Find("Accept").transform.position = acceptPos;
            GameObject.Find("Deny").GetComponent<CanvasGroup>().alpha = 1f;
            GameObject.Find("Deny").GetComponent<Button>().enabled = true;
            GameObject.Find("Deny").transform.position = denyPos;
            GameObject.Find("Okay").GetComponent<CanvasGroup>().alpha = 0f;
            GameObject.Find("Okay").GetComponent<Button>().enabled = false;
            GameObject.Find("Okay").transform.position = offPos;
        }
        if (eventTurn && decide == false)
        {
            if (GetComponent<SpeechManager>().okay && GetComponent<SpeechManager>().takeVoiceInput)
            {
                SetOkay();
            }
            GameObject.Find("Okay").GetComponent<CanvasGroup>().alpha = 1f;
            GameObject.Find("Okay").GetComponent<Button>().enabled = true;
            GameObject.Find("Okay").transform.position = okayPos;
        }
        if (eventTurn == false)
        {
            GameObject.Find("Okay").GetComponent<CanvasGroup>().alpha = 0f;
            GameObject.Find("Okay").GetComponent<Button>().enabled = false;
            GameObject.Find("Okay").transform.position = offPos;
            GameObject.Find("Accept").GetComponent<CanvasGroup>().alpha = 0f;
            GameObject.Find("Accept").GetComponent<Button>().enabled = false;
            GameObject.Find("Accept").transform.position = offPos;
            GameObject.Find("Deny").GetComponent<CanvasGroup>().alpha = 0f;
            GameObject.Find("Deny").GetComponent<Button>().enabled = false;
            GameObject.Find("Deny").transform.position = offPos;
        }
    }

    void SetAccept()
    {
        accept = true;
        GetComponent<SpeechManager>().takeVoiceInput = false;
        GetComponent<SpeechManager>().input = null;
        GetComponent<SpeechManager>().inputAnal = null;
        StartCoroutine(TakeVoiceInput());
    }

    void SetDeny()
    {
        deny = true;
        GetComponent<SpeechManager>().takeVoiceInput = false;
        GetComponent<SpeechManager>().input = null;
        GetComponent<SpeechManager>().inputAnal = null;
        StartCoroutine(TakeVoiceInput());
    }

    void SetOkay()
    {
        okay = true;
        GetComponent<SpeechManager>().takeVoiceInput = false;
        GetComponent<SpeechManager>().input = null;
        GetComponent<SpeechManager>().inputAnal = null;
        StartCoroutine(TakeVoiceInput());
    }

    void GetButtonInputs()
    {
        acceptButton.onClick.AddListener(SetAccept);
        denyButton.onClick.AddListener(SetDeny);
        okayButton.onClick.AddListener(SetOkay);
    }

    IEnumerator TakeVoiceInput()
    {
        yield return new WaitForSeconds(2.5f);
        GetComponent<SpeechManager>().input = null;
        GetComponent<SpeechManager>().inputAnal = null;
        GetComponent<SpeechManager>().takeVoiceInput = true;
    }

    void PlayEventSound()
    {
        if (playedSound == false)
        {
            if (eventType == 0 || eventType == 2 || eventType == 4)
            {
                playedSound = true;
                soundSource.PlayOneShot(positiveEventSound, 1f);
            }
            if (eventType == 1 || eventType == 3)
            {
                playedSound = true;
                soundSource.PlayOneShot(negativeEventSound, 1f);
            }
        }
    }

    void Update()
    {
        if (GetComponent<TurnManager>().endPhase == false)
        {
            GetCurrentEvent();
            //SetEventType();
            SetEventText();
            ChangeResourceValues();
            EndEvent();
            ToggleButtonsActive();
            GetButtonInputs();
        }
    }

}
