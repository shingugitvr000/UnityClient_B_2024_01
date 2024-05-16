using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                   //UI 사용
using System;                           //문자열 관리 하기 위해 사용 
using STROYGAME;

public class StorySystem : MonoBehaviour
{
    public static StorySystem instance;             //싱글톤 

    public StoryModel currentStoryModel;
    public enum TEXTSYSTEM
    {
        NONE,
        DOING,
        SELECT,
        DONE
    }
    public float delay = 0.1f;                          //글자가 나타나는 데 걸리는 시간
    public string fullText;                             //전체 표시할 텍스트
    public string currentText = "";                     //현재까지 표시된 텍스트
    public Text textComponent;                          //텍스트 컴포넌트
    public Text storyIndex;                             //story 번호
    public Image imageComponent;                        //보여줄 이미지 

    public Button[] buttonWay = new Button[3];          //선택지 버튼
    public Text[] buttonWayText = new Text[3];          //버튼 텍스트 

    TEXTSYSTEM textSystem = TEXTSYSTEM.NONE;

    public void Awake()
    {
        instance = this;
    }
   
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < buttonWay.Length; i++)
        {
            int wayIndex = i;       //클로저(colsure) 문제 해결 하기 위해 변수 선언
            //클로저 문제 -> 람다식 또는 익명 함수가 외부 변수를 캡처할 때 발생 하는 문제 
            buttonWay[i].onClick.AddListener(()=> OnWayClick(wayIndex));  

        }

        StroyModelInit();
        StartCoroutine(ShowText());
    }

    public void StroyModelInit()                //받아온 모델 데이터 전달
    {
        fullText = currentStoryModel.storyText;
        storyIndex.text = currentStoryModel.storyNumber.ToString();

        for(int i = 0; i < currentStoryModel.options.Length; i++) 
        {
            buttonWayText[i].text = currentStoryModel.options[i].buttonText;
        }
    }

    public void CoShowText()
    {
        StroyModelInit();               //모델 Init
        ResetShow();                    //리셋
        StartCoroutine(ShowText());     
    }

    public void ResetShow()
    {
        textComponent.text = "";

        for(int i = 0; i < buttonWay.Length;i++)
        {
            buttonWay[i].gameObject.SetActive(false);
        }
    }

    IEnumerator ShowText()
    {
        textSystem = TEXTSYSTEM.DOING;
        if (currentStoryModel.MainImage != null)
        {
            //Texture2D -> Sprite 로 변환
            Rect rect = new Rect(0,0, currentStoryModel.MainImage.width , currentStoryModel.MainImage.height);
            Vector2 pivot = new Vector2(0.5f, 0.5f);        //스프라이트의 축(중심) 지정
            Sprite sprite = Sprite.Create(currentStoryModel.MainImage , rect, pivot);  

            imageComponent.sprite = sprite;
        }
        else
        {
            Debug.LogError("Texture를 가져올수 없습니다.");
        }

        for(int i = 0; i <= fullText.Length; i++) 
        {
            currentText = fullText.Substring(0, i);         //문자열 0부터 i까지 보여준다. 
            textComponent.text = currentText;
            yield return new WaitForSeconds(delay);
        }

        for(int i = 0; i < currentStoryModel.options.Length; i++) 
        {
            buttonWay[i].gameObject.SetActive(true);
            yield return new WaitForSeconds(delay);
        }

        textSystem = TEXTSYSTEM.NONE;
    }


    public void OnWayClick(int index)       //버튼 누를시 호출 되는 함수 
    {
        if (textSystem == TEXTSYSTEM.DOING)
            return;

        Debug.Log("OnWayClick : " + index);

        bool CheckEventTypeNone = false;                    //기본적으로 NONE 일때는 성공 판단 실패시 다시 함수 호출되는것을 막기 
        StoryModel playStoryMode = currentStoryModel;

        if (playStoryMode.options[index].eventCheck.type == StoryModel.EventCheck.EventType.NONE)
        {
            for (int i = 0; i < playStoryMode.options[index].eventCheck.successResult.Length; i++)
            {
                GameSystem.Instance.ApplyChoice(currentStoryModel.options[index].eventCheck.successResult[i]);
                CheckEventTypeNone = true;
            }
        }
    }

}
