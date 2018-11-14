using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallTouch : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public BallSlingController Ball;

    public void OnPointerDown(PointerEventData eventData)
    {
        Ball.MouseDown();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Ball.MouseUp();
    }
}
