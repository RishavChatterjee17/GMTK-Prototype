using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextComparison : MonoBehaviour
{
    private string inputText;
    char[] inputChar, matchChar;
    private string matchText;
    TMP_InputField inputField;
    public TextManager emailText;
    public int passingAccuracy = 60;
    public static int accuracycount = 0;
    public static bool isMatch = false;
    public static int maxLength = 1;

    void Start()
    {
        inputField = GetComponent<TMP_InputField>();
        inputChar = new char[] {};
        matchChar = new char[] {};
    }

    void Update()
    {
        inputText = inputField.text;
        // Debug.Log((inputText));
        inputChar = inputText.ToCharArray();

        matchText = emailText.GetEmailText();
        // Debug.Log((matchText));
        matchChar = matchText.ToCharArray();

        isMatch = CompareText(inputChar, matchChar);

        // Debug.Log("textComparison" + (isMatch));

        maxLength = matchChar.Length <= inputChar.Length ? matchChar.Length : inputChar.Length;
        // Debug.Log("Max length: " + (maxLength));

    }

    public bool CompareText(char[] a, char[] b)
    {
        accuracycount = 0;

        for (int i = 0; i < (b.Length <= a.Length ? b.Length : a.Length); i++)
        {
            if (a[i] == b[i])
            {
                // Debug.Log("both texts are identical");
                accuracycount++;
            }
            else
            {
                // Debug.Log("not identical");
                accuracycount--;
            }
        }

        if (accuracycount > passingAccuracy)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
