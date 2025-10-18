using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventClick : MonoBehaviour, IPointerClickHandler
{
    public static string tag;
    public static GameObject selectedObject;

    public void OnPointerClick(PointerEventData eventData)
    {
        tag = eventData.pointerPress.tag;
        selectedObject = eventData.pointerPress;
    }
}
