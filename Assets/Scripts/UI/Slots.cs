using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slots : MonoBehaviour , IDropHandler
{
    public GameObject item {
        get {
            if (transform.childCount > 0) {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }
    #region IdropHandler implementation 
    public void OnDrop(PointerEventData eventData)
    {
       if (!item)
        {
            DragHandling.item.transform.SetParent(transform);
        }
       else
        {
            transform.GetChild(0).SetParent(DragHandling.item.transform.parent);
            DragHandling.item.transform.SetParent(transform);
        }
    }
    #endregion
}﻿
