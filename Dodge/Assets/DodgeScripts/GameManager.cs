using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //UI관련 라이브러리
using UnityEngine.SceneManagement; //씬 관리 관련 라이브러리
public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; //게임오버 시 활성화할 텍스트 게임 오브젝트
    public Text timeText; //생존 시간을 표시할 테긋트 컴포넌트
    public Text recordText;//최고 기록을 표시할 텍스트 컴포넌트

    private float surviveTime; //생존 시간
    private bool isGameover;    //게임오버 상태

    
    // Start is called before the first frame update
    void Start()
    {
        //생존 시간과 게임오버 상태 초기화
        surviveTime = 0;
        isGameover =false;
    }

    // Update is called once per frame
    void Update()
    {
        //게임오버가 아닌 동안        
        if(!isGameover)
        {
            //생존 시간 갱신
            surviveTime += Time.deltaTime;
            //갱신할 생존 시간을 timeText 텍스트 컴포넌트를 이용해 표시
            timeText.text = $"잡히면 징역: {(int)surviveTime}개월";
        }
        else
        {
            //게임오버 상태에서 R키를 누른 경우
            if(Input.GetKeyDown(KeyCode.R))
            {
                //SampleScene 씬을 로드
                SceneManager.LoadScene("SampleScene");
            }
            if(Input.GetKeyDown(KeyCode.Q))
            {
#if UNITY_EDITOR

                UnityEditor.EditorApplication.isPlaying = false;
#endif
#if UNITY_EDITOR == false
                Application.Quit();
#endif
            }
        }
    }

    public void EndGame()
    {
        //현재 상태를 게임오버 상태로 전환
        isGameover = true;
        //게임오버 텍스트 게임 오브젝트를 활성화
        gameoverText.SetActive(true);

        //Besttime 키로 저장된 이전까지의 최고 기록 가져오기
        float bestTime = PlayerPrefs.GetFloat("징역");

        //이전까지의 최고 기록보다 현재 생존 시간이 더 크다면
        if(bestTime < surviveTime  )
        {
            //최고 기록 값을 현재 생존 시간 값으로 변경
            bestTime = surviveTime;
            //변견됭 최고 기록을 BestTime 키로 저장
            PlayerPrefs.SetFloat("징역",bestTime);
        }

        //최고 기록을 recordText 텍스트 컴포넌트를 이용해 표시
        recordText.text = $"징역 {Mathf.FloorToInt(bestTime)} 개월 ";
        // + (int)bestTime;    
    }
}
