using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MobileJoystickController : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] RectTransform background;
    [SerializeField] RectTransform stick;

    public Vector2 pointPosition;

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");

        pointPosition = new Vector2(
            (eventData.position.x - background.position.x ) / ( background.rect.size.x / 2 - stick.rect.size.x / 2),
            (eventData.position.y - background.position.y) / (background.rect.size.y / 2 - stick.rect.size.y / 2)
            );
        //if (pointPosition.magnitude > 1.0f) pointPosition.Normalize();
        pointPosition = pointPosition.magnitude > 1.0f ? pointPosition.normalized : pointPosition;
        Debug.Log("x; " + pointPosition.x + " y: " + pointPosition.y   );

        stick.transform.position = new Vector2(
            pointPosition.x * (background.rect.size.x / 2 - stick.rect.size.x / 2) + background.position.x,
            pointPosition.y * (background.rect.size.y / 2 - stick.rect.size.y / 2) + background.position.y
            );
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        pointPosition = new Vector2(0.0f, 0.0f);
        stick.transform.position = background.position;
    }
}

