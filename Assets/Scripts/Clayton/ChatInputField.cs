using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChatInputField : MonoBehaviour
{
    public ChatterManager chatManager;
    private InputField inputField;
    public ScrollRect scroll;

    EventSystem eventSystem;

    private void OnEnable()
    {
        eventSystem = EventSystem.current;
    }

    private void Start()
    {
        inputField = GetComponent<InputField>();
        scroll.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Slash)) //It is the / key
        {
            if (!scroll.gameObject.activeSelf)
            {
                scroll.gameObject.SetActive(true);
                eventSystem.SetSelectedGameObject(inputField.gameObject, null);
            }
            else
            {
                chatManager.MSG = null;
                scroll.gameObject.SetActive(false);
                eventSystem.SetSelectedGameObject(null);
                inputField.text = string.Empty;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        if (!scroll.gameObject.activeSelf)
        {
            if (!string.IsNullOrEmpty(chatManager.MSG))
            {
                scroll.gameObject.SetActive(true);
                eventSystem.SetSelectedGameObject(inputField.gameObject, null);
                chatManager.MSG = null;
            }
        }
    }

    public void ValueChange()
    {
        if (inputField.text.Contains("\n"))
            chatManager.writeMessage(inputField);
    }
}
