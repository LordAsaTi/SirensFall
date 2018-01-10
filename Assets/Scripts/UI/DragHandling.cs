using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandling : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public static GameObject item; // i changed itembeigdraged to item. 
    Transform startParent;
    Vector3 startPosition;
    bool start = true;
    //Sprite sprite; 
    public void OnBeginDrag(PointerEventData eventData)
    {
        item = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        //item.GetComponent<LayoutElement>().ignoreLayout = true;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;       //muss für touch funktionieren
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        //collider abfage; und parent setzen
        item = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (transform.parent == startParent)
        {
            transform.position = startPosition;
        }
        //item.GetComponent<LayoutElement>().ignoreLayout = false;
    }
}
