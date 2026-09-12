using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HudDoPainel : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    private RectTransform painel;
    private Vector2 offset;

    void Start()
    {
        painel = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            painel.parent as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out offset
        );

        offset -= painel.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 posicao;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            painel.parent as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out posicao
        );

        painel.anchoredPosition = posicao - offset;
    }
}
