using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UFSButton : Button
{

    public bool SendPosition = false;

    public event Action Click;

    public event Action Hover;

    public event Action<Vector2, Camera> ClickPosition;

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);

        if (!interactable)
            return;
        if (SendPosition)
        {
            ClickPosition.Raise(eventData.position, eventData.pressEventCamera);
        }
        Click.Raise();

    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        Hover.Raise();
    }

}
