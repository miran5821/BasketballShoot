using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractionCylinder : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    [SerializeField] int index;
    [SerializeField] GameObject cylinder;
    [SerializeField] float rotateAngle;
    bool isPressed;
    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        GameManager.Instance.isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        GameManager.Instance.isPressed = false;
    }

    private void Update()
    {
        if (isPressed&&GameManager.Instance.isPressed)
        {
            if (index == 1)
                cylinder.transform.Rotate(0,rotateAngle* Time.deltaTime, 0);
            else
                cylinder.transform.Rotate(0,-rotateAngle * Time.deltaTime, 0);
        }
    }
}
