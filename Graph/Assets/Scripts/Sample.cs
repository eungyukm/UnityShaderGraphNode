using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{
    private List<int> n1 = new List<int>();
    private List<int> n2 = new List<int>();
    private List<int> r1 = new List<int>();

    private void OnEnable()
    {
        Debug.Log("OnEnable!!");
        int x = 3;
        x.ToString();
        x.Print();

        string z = "Hello";
        Debug.Log(z.StringToFormat());
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable!!");
    }

    void Start()
    {
        // 0 1 2 2 2 7
        n1.Add(0);
        n1.Add(1);
        n1.Add(2);
        n1.Add(2);
        n1.Add(2);
        n1.Add(7);
        
        n2.Add(2);
        n2.Add(1);
        n2.Add(2);
        n2.Add(1);
        n2.Add(2);
        n2.Add(1);
        
        
        // 입력 숫자
        PrintAll(n1);
        
        // 비교
        r1.Add(1);
        r1.Add(1);
        r1.Add(2);
        r1.Add(2);
        r1.Add(2);
        r1.Add(8);
        
        // 흰색 피스는 개수가 올바르지 않았다.
        // 체스는 총 16개의 피스를 사용하며, 킹 1개, 퀸 1개, 룩 2개, 비숍 2개, 나이트 2개, 폰 8개로 구성되어 있다.
        // 동혁이가 발견한 흰색 피스의 개수가 주어졌을 때, 몇 개를 더하거나 빼야 올바른 세트가 되는지 구하는 프로그램을 작성하시오.
        Debug.Log("sub");
        for (int i = 0; i < n1.Count; i++)
        {
            int sub = r1[i] - n1[i];
            Debug.Log(sub);
        }
        
        Debug.Log("sub 2");
        for (int i = 0; i < n2.Count; i++)
        {
            int sub = r1[i] - n2[i];
            Debug.Log(sub);
        }
        
    }

    private void PrintAll(List<int> intList)
    {
        foreach (int i in intList)
        {
            Debug.Log(i);
        }
    }
}
