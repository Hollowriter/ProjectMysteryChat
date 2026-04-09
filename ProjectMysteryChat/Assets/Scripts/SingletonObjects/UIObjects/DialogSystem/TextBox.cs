using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : SingletonBase<TextBox>
{
    int speechIndex;
    bool textWriting;
    bool textWritten;
    bool skipText;
    [Header("Chat UI")]
    [SerializeField] Transform content;
    [SerializeField] GameObject messagePrefab;
    [SerializeField] ScrollRect scrollRect;
    // [SerializeField] GameObject dialogueBackground;
    [Header("Config")]
    [SerializeField] float textSlowDown = 0.02f;
    DialogCollection items;
    GameObject nextButton;
    GameObject nextDebateButton;
    GameObject previousDebateButton;
    [SerializeField] Transform nextDebateButtonLocation;
    [SerializeField] Transform prevDebateButtonLocation;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        DontDestroyOnLoad(gameObject);
        speechIndex = 0;
        textWriting = false;
        textWritten = false;
        skipText = false;
        /*if (dialogueBackground != null)
            dialogueBackground.SetActive(false);*/
    }

    private void Awake()
    {
        SingletonAwake();
    }

    protected override bool ConditionsToBeActive()
    {
        if (items != null && GetActivated())
        {
            if (items.Dialogs != null && speechIndex < items.Dialogs.Length)
                return true;
        }
        SetActivated(false);
        return false;
    }

    IEnumerator DialogTyping(string _word)
    {
       /*if (!dialogueBackground.activeInHierarchy)
            dialogueBackground.SetActive(true);*/
        GameObject msg = Instantiate(messagePrefab, content);
        Text txt = msg.GetComponentInChildren<Text>();
        txt.text = "";
        foreach (char letter in _word.ToCharArray())
        {
            if (skipText)
            {
                txt.text = _word;
                break;
            }

            txt.text += letter;
            yield return new WaitForSeconds(textSlowDown);
        }
        textWritten = true;
        skipText = false;
        Canvas.ForceUpdateCanvases();
        scrollRect.verticalNormalizedPosition = 0f;
    }

    void WriteText()
    {
        if (!textWriting)
        {
            StopAllCoroutines();
            if (speechIndex < items.Dialogs.Length)
                StartCoroutine(DialogTyping(items.Dialogs[speechIndex].Text));
            textWriting = true;
        }
    }

    void NextButtonAppear()
    {
        if (textWritten && EvidenceInventory.instance.GetActivated() == false)
        {
            if (nextButton == null)
            {
                nextButton = ButtonCreator.instance.CreateButton(
                    "",
                    transform.position.x,
                    transform.position.y
                );
                nextButton.transform.localScale = new Vector3(100, 100, 100);
                nextButton.GetComponent<Image>().enabled = false;
                nextButton.GetComponent<Button>().onClick.AddListener(NextPressed);
            }
            else
            {
                nextButton.SetActive(true);
            }
        }
    }

    void DebateButtonsAppear()
    {
        if (textWritten && EvidenceInventory.instance.GetActivated() == false)
        {
            if (nextDebateButton == null && speechIndex < items.Dialogs.Length - 1)
            {
                nextDebateButton = ButtonCreator.instance.CreateButton(
                    ">",
                    nextDebateButtonLocation.position.x,
                    nextDebateButtonLocation.position.y
                );

                nextDebateButton.GetComponent<Button>().onClick.AddListener(NextDebateButtonPressed);
                nextDebateButton.GetComponent<Button>().onClick.AddListener(PortraitBoxes.instance.NextImage);
            }
            else if (speechIndex < items.Dialogs.Length - 1)
            {
                nextDebateButton.SetActive(true);
            }
            if (previousDebateButton == null && speechIndex > 0)
            {
                previousDebateButton = ButtonCreator.instance.CreateButton(
                    "<",
                    prevDebateButtonLocation.position.x,
                    prevDebateButtonLocation.position.y
                );

                previousDebateButton.GetComponent<Button>().onClick.AddListener(PreviousDebateButtonPressed);
                previousDebateButton.GetComponent<Button>().onClick.AddListener(PortraitBoxes.instance.PreviousImage);
            }
            else if (speechIndex > 0)
            {
                previousDebateButton.SetActive(true);
            }
            DocumentManager.instance.CheckElectionsAndInspector();
        }
    }

    void NextPressed()
    {
        if (textWritten)
        {
            speechIndex++;
            textWritten = false;
            textWriting = false;
            CheckOnDocumentManager();
            PortraitBoxes.instance.ContinuousNextImage();
        }
        else
        {
            skipText = true;
        }
    }

    void NextDebateButtonPressed()
    {
        speechIndex++;
        textWriting = false;
        textWritten = false;
    }

    void PreviousDebateButtonPressed()
    {
        speechIndex--;
        if (speechIndex < 0)
            speechIndex = 0;
        textWriting = false;
        textWritten = false;
    }

    void CheckOnDocumentManager()
    {
        if (speechIndex >= items.Dialogs.Length)
        {
            DocumentManager.instance.CheckElectionsAndInspector();
            // dialogueBackground.SetActive(false);
        }
    }

    protected override void BehaveSingleton()
    {
        if (ConditionsToBeActive())
        {
            WriteText();
            if (items.IsDebate)
                DebateButtonsAppear();
            else
                NextButtonAppear();
        }
    }

    private void OnGUI()
    {
        BehaveSingleton();
    }

    public void SetDialog(DialogCollection dialogs) => items = dialogs;
    public int GetSpeechIndex() => speechIndex;
}
