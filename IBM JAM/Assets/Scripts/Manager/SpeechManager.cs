using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechManager : MonoBehaviour
{

    public bool     yes,
                    no,
                    accept,
                    deny,
                    okay,

                    promote,
                    upgradeSecurity,
                    advertise,
                    hire,
                    fire,
                    doNothing,
        
                    takeVoiceInput;
    public string   input,
                    lastInput,
                    storedInput;
    public string[] inputAnal;


    void Start ()
    {
        yes = false;
        no = false;

        promote = false;
        upgradeSecurity = false;
        advertise = false;
        hire = false;
        fire = false;
        doNothing = false;

        takeVoiceInput = true;
	}

    void AnalyseSpeech()
    {
        if (takeVoiceInput)
        {
            input = GameObject.Find("Output").GetComponent<Text>().text;
            if (input != lastInput)
            {
                lastInput = input;
                storedInput = lastInput;
                StartCoroutine(EmptyStoredInput());
            }
            inputAnal = storedInput.Split(new char[] { ' ', ',' });
            foreach (string word in inputAnal)
            {
                if (word.Equals("affirmative") || word.Equals("confirm") || word.Equals("indeed"))
                {
                    GameObject.Find("Output").GetComponent<Text>().text = null;
                    yes = true;
                    StartCoroutine(ResetYes());
                }

                if (word.Equals("negative"))
                {
                    GameObject.Find("Output").GetComponent<Text>().text = null;
                    no = true;
                    StartCoroutine(ResetNo());
                }

                if (word.Equals("okay") || word.Equals("understand"))
                {
                    GameObject.Find("Output").GetComponent<Text>().text = null;
                    okay = true;
                    StartCoroutine(ResetOkay());
                }

                if (word.Equals("accept") || word.Equals("except") || word.Equals("cassette"))
                {
                    GameObject.Find("Output").GetComponent<Text>().text = null;
                    accept = true;
                    StartCoroutine(ResetAccept());
                }

                if (word.Equals("deny") || word.Equals("decline") || word.Equals("refuse"))
                {
                    GameObject.Find("Output").GetComponent<Text>().text = null;
                    deny = true;
                    StartCoroutine(ResetDeny());
                }

                if (word.Equals("promote") || word.Equals("rise") || word.Equals("raise"))
                {
                    GameObject.Find("Output").GetComponent<Text>().text = null;
                    promote = true;
                    StartCoroutine(ResetPromote());
                }

                if (word.Equals("upgrade") || word.Equals("security"))
                {
                    GameObject.Find("Output").GetComponent<Text>().text = null;
                    upgradeSecurity = true;
                    StartCoroutine(ResetUpgradeSecurity());
                }

                if (word.Equals("advertise") || word.Equals("advert") || word.Equals("adverts") || word.Equals("advertising") || word.Equals("advertisement"))
                {
                    GameObject.Find("Output").GetComponent<Text>().text = null;
                    advertise = true;
                    StartCoroutine(ResetAdvertise());
                }

                if (word.Equals("hire") || word.Equals("recruit") || word.Equals("employ"))
                {
                    GameObject.Find("Output").GetComponent<Text>().text = null;
                    hire = true;
                    StartCoroutine(ResetHire());
                }

                if (word.Equals("fire") || word.Equals("sack") || word.Equals("sac") || word.Equals("dismiss") || word.Equals("terminate") || word.Equals("expel") || word.Equals("discharge"))
                {
                    GameObject.Find("Output").GetComponent<Text>().text = null;
                    fire = true;
                    StartCoroutine(ResetFire());
                }

                if (word.Equals("nothing") || word.Equals("pass") || word.Equals("anything") || word.Equals("don't"))
                {
                    GameObject.Find("Output").GetComponent<Text>().text = null;
                    doNothing = true;
                    StartCoroutine(ResetDoNothing());
                }
            }
        }
        
    }

    IEnumerator ResetYes()
    {
        yield return new WaitForSeconds(0.1f);
        yes = false;
    }

    IEnumerator ResetNo()
    {
        yield return new WaitForSeconds(0.1f);
        no = false;
    }

    IEnumerator ResetOkay()
    {
        yield return new WaitForSeconds(0.1f);
        okay = false;
    }

    IEnumerator ResetAccept()
    {
        yield return new WaitForSeconds(0.1f);
        accept = false;
    }

    IEnumerator ResetDeny()
    {
        yield return new WaitForSeconds(0.1f);
        deny = false;
    }

    IEnumerator ResetPromote()
    {
        yield return new WaitForSeconds(0.1f);
        promote = false;
    }

    IEnumerator ResetUpgradeSecurity()
    {
        yield return new WaitForSeconds(0.1f);
        upgradeSecurity = false;
    }

    IEnumerator ResetAdvertise()
    {
        yield return new WaitForSeconds(0.1f);
        advertise = false;
    }

    IEnumerator ResetHire()
    {
        yield return new WaitForSeconds(0.1f);
        hire = false;
    }

    IEnumerator ResetFire()
    {
        yield return new WaitForSeconds(0.1f);
        fire = false;
    }

    IEnumerator ResetDoNothing()
    {
        yield return new WaitForSeconds(0.1f);
        doNothing = false;
    }

    IEnumerator EmptyStoredInput()
    {
        yield return new WaitForSeconds(0.1f);
        if (storedInput == lastInput)
        {
            storedInput = null;
        }
    }

    void LateUpdate ()
    {
        AnalyseSpeech();
	}

}
