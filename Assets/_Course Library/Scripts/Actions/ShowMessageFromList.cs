using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

/// <summary>
/// Shows an ordered list of messages via a text mesh
/// </summary>
public class ShowMessageFromList : MonoBehaviour
{
    [Tooltip("The text mesh the message is output to")]
    public TextMeshProUGUI messageOutput = null;
    public TextMeshProUGUI _buttonText;
    [Tooltip("The text message only shows the first time that is invoked")]
    public bool _showJustOnce = true;
    // What happens once the list is completed
    public UnityEvent OnComplete = new UnityEvent();
    [Tooltip("The list of messages that are shown")]
    [TextArea] public List<string> messages = new List<string>();

    private bool _alreadyShown = false;
    private int index = 0;
    private Canvas _canvas;

    private void Start()
    {
        _canvas = GetComponentInParent<Canvas>(true);

        if (!_showJustOnce)
        {
            if(_canvas != null)
            {
                _canvas.gameObject.SetActive(true);
                ShowMessage();
            }
        }
        else
        {
            if (!_alreadyShown)
            {
                _canvas.gameObject.SetActive(true);
                ShowMessage();
            }
        }   
    }

    public void NextMessage()
    {
        int newIndex = ++index % messages.Count;

        if (newIndex < index)
        {
            _alreadyShown = true;
            OnComplete.Invoke();
        }
        else
        {
            if (_buttonText != null && index == messages.Count - 1)
                _buttonText.text = "Close";

            ShowMessage();
        }
    }

    public void PreviousMessage()
    {
        index = --index % messages.Count;
        ShowMessage();
    }

    private void ShowMessage()
    {
        messageOutput.text = messages[Mathf.Abs(index)];
    }

    public void ShowMessageAtIndex(int value)
    {
        index = value;
        ShowMessage();
    }
}
