using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExCharacter : MonoBehaviour
{
    public float speed = 5.0f;   
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    //virtual 키워드 상속 받은 클래스에서 재정의 할수 있음
    protected virtual void Move()
    {
        transform.Translate(
            Vector3.forward * speed * Time.deltaTime);
    }

    public void DestroyChatacter()
    {
        Destroy(gameObject);
    }
}
