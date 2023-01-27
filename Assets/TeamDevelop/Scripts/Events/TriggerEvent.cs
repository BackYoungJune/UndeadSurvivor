using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    //--------------------------------------------------------					
    // 외부 참조 함수 & 프로퍼티					
    //--------------------------------------------------------		




    //--------------------------------------------------------					
    // 내부 필드 변수					
    //--------------------------------------------------------	
    [SerializeField] private string TriggerTagName;
    [SerializeField] UnityEvent EnterEvent;
    [SerializeField] UnityEvent StayEvent;
    [SerializeField] UnityEvent ExitEvent;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(TriggerTagName)) 
        {
            EnterEvent.Invoke();
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(TriggerTagName))
        {
            StayEvent.Invoke();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(TriggerTagName))
        {
            ExitEvent.Invoke();
        }
    }

}
