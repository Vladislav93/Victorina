using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public class QuestionForListDB : ScriptableObject
{
    [SerializeField]
    public List<QuestionListBase> _QuestionList = new List<QuestionListBase>(); 
}
