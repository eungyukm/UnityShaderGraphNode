using UnityEngine;

// 확장 메서드는 이미 정의가 되어 있는 클래스에 확장 가능한 문법을 말합니다.

// 1. public static class
public static class IntExtension
{
    // 2. public static 함수이름(this 변수, 매개변수)
    public static void Print(this int value)
    {
        Debug.Log(value);
    }
}

// 1. public static class
public static class StringExtension
{
    // 2. public static 함수이름(this 변수, 매개변수)
    public static string StringToFormat(this string value)
    {
        return "[" + value + "]";
    }
}