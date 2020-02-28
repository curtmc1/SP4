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

    void Awake()
    {
        _button = GetComponent<Button>();
        slotIconGo = transform.GetChild(0);
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
            UseItem();
        }
    }

    void FadeToColor(Color color)
    {
        Graphic graphic = GetComponent<Graphic>();
        graphic.CrossFadeColor(color, _button.colors.fadeDuration, true, true);
    }
    //public void OnPointerClick(PointerEventData pointerEventData)
    //{
    //    UseItem();
    //}
    public void UpdateSlot()
    {
        slotIconGo.GetComponent<Image>().sprite = icon;
    }
    public void UseItem()
    {
        item.GetComponent<Item>().ItemUsage();
    }
}
