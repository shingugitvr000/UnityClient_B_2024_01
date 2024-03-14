using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSubscriber : MonoBehaviour
{
    public EventChannel eventChannel;

    private void OnEnable() //오브젝트가 활성화 되었을때 이벤트 등록
    {
        eventChannel.OnEventRaised.AddListener(OnEventRaised);
    }

    private void OnDisable() //오브젝트가 비활성화 되었을때 이벤트 삭제
    {
        eventChannel.OnEventRaised.RemoveListener(OnEventRaised);
    }

    void OnEventRaised()
    {
        Debug.Log("Event On : " + gameObject.name);
    }
}
