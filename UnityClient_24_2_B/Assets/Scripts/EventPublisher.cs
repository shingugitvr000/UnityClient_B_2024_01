using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPublisher : MonoBehaviour
{
    public EventChannel eventChannel;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))     //스베이스바를 누를 때 이벤트 발생
        {
            eventChannel.RaiseEvent();
        }
    }
}
