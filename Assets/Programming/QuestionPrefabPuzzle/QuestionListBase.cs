using System;
using UnityEngine;

[Serializable]
public class QuestionListBase
{ 
    public string Question;

    public string RightAnswer;

    public string WrongAnswer1;

    public string WrongAnswer2;

    public QuestionListBase(string quest, string right, string wrong1, string wrong2)
    {
        Question = quest;
        RightAnswer = right;
        WrongAnswer1 = wrong1;
        WrongAnswer2 = wrong2;
    }
}
