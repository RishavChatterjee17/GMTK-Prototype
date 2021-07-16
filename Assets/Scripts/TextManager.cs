using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using System;
public class TextManager : MonoBehaviour
{
    private TextMeshProUGUI m_Text;
    public Button sendbutton;
    public static bool clicked = false;
    bool textMatch = false;
    [SerializeField] GameState startingState;
    GameState state;
    public TextMeshProUGUI accuracyText;
    string accuracy; 

    void Start()
    {
        state = startingState;
        m_Text = GetComponent<TextMeshProUGUI>();
        m_Text.text = state.GetStateText();

        sendbutton.onClick.AddListener(TaskOnClick);
    }

    public string GetEmailText()
    {
        return m_Text.text;
    }

    void TaskOnClick()
    {
        accuracy = Convert.ToString(TextComparison.accuracycount);
        textMatch = TextComparison.isMatch;

        accuracyText.text = "Accuracy is: " + accuracy;
    
        clicked = true;
    }
    void Update()
    {
        ManageStates();
    }

    void ManageStates()
    {
        var nextState = state.GetNextStates();
        if (clicked == true && textMatch == true)
        {
            state = nextState[0];
            clicked = false;
            textMatch = false;
        }
        else
        {
            state = nextState[1];
        }
        m_Text.text = state.GetStateText();
    }
}

