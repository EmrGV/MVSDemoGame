 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ManagerJoyStick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private Image touch;
    private Image touchhold;
    private Vector2 posInput;

    void Start()
    {
        touchhold = GetComponent<Image>();
        touch = transform.GetChild(0).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(touchhold.rectTransform, eventData.position, eventData.pressEventCamera, out posInput))
        {
            posInput.x = 2*posInput.x / (touchhold.rectTransform.sizeDelta.x);
            posInput.y = 2*posInput.y / (touchhold.rectTransform.sizeDelta.y);

            if (posInput.magnitude>1.0f)
            {
                posInput = posInput.normalized;
            }

            touch.rectTransform.anchoredPosition = new Vector2(posInput.x*(touchhold.rectTransform.sizeDelta.x/2),
                                                                posInput.y*(touchhold.rectTransform.sizeDelta.x/2));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);

    }
    public void OnPointerUp(PointerEventData eventData)
    {
        posInput = Vector2.zero;
        touch.rectTransform.anchoredPosition = Vector3.zero;

    }
    public float inputHorizontal()
    {
        if (posInput.x != 0)
        
            return posInput.x;
        else
            return Input.GetAxis("Horizontal");             
    }
    public float inputVertical()
    {
        if (posInput.y != 0)

            return posInput.x;
        else
            return Input.GetAxis("Vertical");
    }
}
