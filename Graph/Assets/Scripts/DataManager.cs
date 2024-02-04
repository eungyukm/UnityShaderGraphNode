using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;
// 1. UnityAction을 사용하기 위해 using을 선언
using UnityEngine.Events;

public class DataManager : MonoBehaviour
{
    #region SingleTon

    private static DataManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    #endregion
    // 데이터 로드 패스 (폴더 이름/Json 파일 이름)
    private const string commonStoryPath = "Datas/CoommonStoryData";
    private const string selectDataPath = "Datas/SelectData";
    private const string yesDataPath = "Datas/YesData";
    private const string noDataPath = "Datas/NoData";
    
    // 딕셔너리 Key와 Value는 자료구조
    // 첫번째 key
    // 두번째 Value
    private Dictionary<int, CommonStory> dicCommonStory;
    private Dictionary<int, SelectData> dicSelectData;
    private Dictionary<int, YesData> dicYesData;
    private Dictionary<int, NoData> dicNoData;
    
    private int storyNumber = 1000;
    
    // 2. UnityAction 함수를 등록할 수 있는 변수
    public UnityAction functionAction;

    public UnityAction<int> intAction;
    public UnityAction<int, int> doubleIntAction;
    
    public Button button;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            // 3 UnityAction 호출
            functionAction();
        }
    }

    #region 데이터 로드
    void Start()
    {
        // Class Array To Dictionary
        // dictionary 생성
        dicCommonStory = new Dictionary<int, CommonStory>();
        dicSelectData = new Dictionary<int, SelectData>();
        dicYesData = new Dictionary<int, YesData>();
        dicNoData = new Dictionary<int, NoData>();
        
        LoadDatas();

        functionAction += Func1;
        functionAction += Func2;
        functionAction += Func3;

        button.onClick.AddListener(Func1);
        // 익명함수로 Unity Action을 구성하였습니다.
        button.onClick.AddListener(() =>
        {
            // 함수 본체
            Debug.Log("익명함수");
        });
        
        // 익명함수를 intActon에 등록하는 문법
        intAction = (x) =>
        {
            Debug.Log("x : " + x);
        };

        doubleIntAction = DoubleIntFunc;
    }

    private void DoubleIntFunc(int x, int y)
    {
        
    }

    private void Func1()
    {
        Debug.Log("Func1!");
    }
    private void Func2()
    {
        Debug.Log("Func2!");
    }
    private void Func3()
    {
        Debug.Log("Func3!");
    }
    
    // 데이터 로드
    private void LoadDatas()
    {
        // 1. 데이터 패스로 Resources 폴더에서 데이터 로드
        TextAsset commonStroyAsset = Resources.Load<TextAsset>(commonStoryPath);
        Debug.Log("commonStroyAsset : " + commonStroyAsset.text);
        
        TextAsset selectDataAsset = Resources.Load<TextAsset>(selectDataPath);
        Debug.Log("selectDataAsset : " + selectDataAsset.text);
        
        TextAsset yesDataAsset = Resources.Load<TextAsset>(yesDataPath);
        Debug.Log("yesDataAsset : " + yesDataAsset.text);
        
        TextAsset noDataAsset = Resources.Load<TextAsset>(noDataPath);
        Debug.Log("noDataAsset : " + noDataAsset.text);
        
        // 2. 클래스 배열을 JsonConvert.DeserializeObject를 통해 배열 만든다. (Json Text -> Class Array)
        CommonStory[] commonStory = JsonConvert.DeserializeObject<CommonStory[]>(commonStroyAsset.text);
        SelectData[] selectData = JsonConvert.DeserializeObject<SelectData[]>(selectDataAsset.text);
        
        // 3. 배열을 딕셔너리로 추가하는 과정
        foreach (var data  in commonStory)
        {
            dicCommonStory.Add(data.idx, data);
        }
        
        Debug.Log("dicCommonStry Count : " + dicCommonStory.Count);
        
        // 3. 배열을 딕셔너리로 만드는 과정 (ToDictionary라는 함수를 통해서 만든 것)
        dicSelectData = selectData.ToDictionary(x => x.idx, x => x);
        Debug.Log("dicSelectData Count : " + dicSelectData.Count);
        
        
        // 2-3 람다 문법을 익명함수(이름이 없는 함수)를 사용하여, 한줄의 코드 내에 함수를 사용하는 문법
        dicYesData = JsonConvert.DeserializeObject<YesData[]>(yesDataAsset.text).
            ToDictionary(x => x.idx, x => x);
        Debug.Log("dicYesData : " + dicYesData.Count);

        dicNoData = JsonConvert.DeserializeObject<NoData[]>(noDataAsset.text).
            ToDictionary(x => x.idx, x => x);
        Debug.Log("dicNoData : " + dicNoData.Count);
    }

    #endregion

    public void OnClickEvent()
    {
        Debug.Log(dicCommonStory[storyNumber].story);
        storyNumber = dicCommonStory[storyNumber].next;
    }
}

public class CommonStory
{
    public int idx;
    public string story;
    public int next;
}

public class SelectData
{
    public int idx;
    public string story;
    public int yes;
    public int no;
}

public class YesData
{
    public int idx;
    public string story;
    public int next;
}

public class NoData
{
    public int idx;
    public string story;
    public int next;
}