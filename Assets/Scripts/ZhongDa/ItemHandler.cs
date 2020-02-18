using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        HUD hud = GetComponentInParent<HUD>();
        transform.parent = hud.transform;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.GetChild(0).position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.GetChild(0).localPosition = Vector3.zero;
    }
    //public InventoryItemBase Item { get; set; } //DragHandler

    //#region //ClickHandler
    //public Inventory _Inventory;
    //public KeyCode _Key;
    //private Button _button;


    //void Awake()
    //{
    //    _button = GetComponent<Button>();
    //}

    //void Update()
    //{
    //    if (Input.GetKeyDown(_Key))
    //    {
    //        FadeToColor(_button.colors.pressedColor);

    //        // Click the button
    //        _button.onClick.Invoke();
    //    }
    //    else if (Input.GetKeyUp(_Key))
    //    {
    //        FadeToColor(_button.colors.normalColor);
    //    }
    //}
    //void FadeToColor(Color color)
    //{
    //    Graphic graphic = GetComponent<Graphic>();
    //    graphic.CrossFadeColor(color, _button.colors.fadeDuration, true, true);
    //}

    //private InventoryItemBase AttachedItem
    //{
    //    get
    //    {
    //        ItemHandler dragHandler =
    //        gameObject.transform.Find("ItemImage").GetComponent<ItemHandler>();

    //        return dragHandler.Item;
    //    }
    //}

    //public void OnItemClicked()
    //{
    //    InventoryItemBase item = AttachedItem;

    //    if (item != null)
    //    {
    //        _Inventory.UseItem(item);
    //    }
    //}
    //#endregion

    ////DropHandler
    ////DropHandler
    //public void OnDrag(PointerEventData eventData)
    //{
    //    transform.position = Input.mousePosition;
    //}

    //public void OnEndDrag(PointerEventData eventData)
    //{
    //    transform.localPosition = Vector3.zero;
    //}
}
