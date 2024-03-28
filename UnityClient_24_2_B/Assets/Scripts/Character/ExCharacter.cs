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

    //virtual Ű���� ��� ���� Ŭ�������� ������ �Ҽ� ����
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
