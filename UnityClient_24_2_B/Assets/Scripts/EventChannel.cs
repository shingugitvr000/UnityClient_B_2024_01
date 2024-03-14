using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;           //이벤트 사용


[CreateAssetMenu(fileName = "NewEventChannel" , menuName = "Events/Event Channel")]

public class EventChannel : ScriptableObject
{
    public UnityEvent OnEventRaised;

    public void RaiseEvent()
    {
        if(OnEventRaised != null)
        {
            OnEventRaised.Invoke();
        }
    }
}
