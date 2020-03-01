using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour
{
    public GameObject item;
    public int id;
    public string type;
    public string description;
    public bool empty;

    public Transform slotIconGo;
    public Sprite icon;

    public KeyCode _key;
    private Button _button;
    public bool gotUse;

    void Awake()
    {
        _button = GetComponent<Button>();
        slotIconGo = transform.GetChild(0);
        gotUse = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(_key))
        {
            FadeToColor(_button.colors.pressedColor);
            _button.onClick.Invoke();
        }
        else if (Input.GetKeyUp(_key))
        {
            FadeToColor(_button.colors.normalColor);

            if (!gotUse && !empty)
            {
                gotUse = true;
                UseItem();
            }
        }
    }

    void FadeToColor(Color color)
    {
        Graphic graphic = GetComponent<Graphic>();
        graphic.CrossFadeColor(color, _button.colors.fadeDuration, true, true);
    }
    public void UpdateSlot()
    {
        slotIconGo.GetComponent<Image>().sprite = icon;
    }
    public void UseItem()
    {
        if (item)
            item.GetComponent<Item>().ItemUsage();
    }
}
