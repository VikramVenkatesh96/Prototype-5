using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Draggable : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    #region Mouse Drag

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, screenPoint.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curPosition = new Vector3(Input.mousePosition.x, screenPoint.y, screenPoint.z);
        transform.position = Camera.main.ScreenToWorldPoint(curPosition) + offset;
    }

    #endregion

}
