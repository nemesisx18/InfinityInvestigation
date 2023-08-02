using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickAndSnap : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform dragTransform;
    private Canvas canvas;
    private RectTransform targetTransform;
    private float snapDistance = 20f; // Jarak minimum untuk menempel ke target point

    public RectTransform targetPoint; // Referensi langsung ke target point
    public Manager manager;
    public void OnBeginDrag(PointerEventData eventData)
    {
        dragTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, canvas.worldCamera, out Vector2 localPosition);
        dragTransform.localPosition = localPosition;

        // Jika ada target point, cek jarak dan lakukan snapping jika dekat
        if (targetPoint != null)
        {
            Vector3 targetPosition = targetPoint.position;
            Vector3 imagePosition = dragTransform.position;
            float distance = Vector3.Distance(targetPosition, imagePosition);

            if (distance <= snapDistance)
            {
                dragTransform.position = targetPosition;
                manager.puzzleDone++;
                GetComponent<ClickAndSnap>().enabled = false;
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dragTransform = null;
    }
}
