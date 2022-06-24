using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class WriteTextOnScreen : MonoBehaviour
{

    [SerializeField]
    AudioSource keyboardSound;

    [SerializeField]
    TextMeshProUGUI tutorMessage;

    [SerializeField]
    GameObject playButton;

    [SerializeField]
    MessagesToDisplay messageToDisplay;

    string dispMessage;
    int messagePos;
    // Start is called before the first frame update
    void Start()
    {
        dispMessage = messageToDisplay.message;
        messagePos = 0;
        playButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (messagePos < dispMessage.Length)
        {
            StartCoroutine(DisplayMessage());
        }
        else
        {
            playButton.SetActive(true);
        }
        
    }

    IEnumerator DisplayMessage()
    {
        yield return new WaitForSeconds(1f);
        if (messagePos < dispMessage.Length)
        {
            if (!keyboardSound.isPlaying)
            {
                keyboardSound.Play();
            }

            tutorMessage.text += dispMessage[messagePos];
            messagePos++;
        }
    }
}
