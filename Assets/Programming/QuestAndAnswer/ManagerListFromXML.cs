using UnityEngine;
using System.Collections.Generic;
using System.Xml;

public class ManagerListFromXML : MonoBehaviour {

    [SerializeField]
    public List<QuestionListBase> Quest = new List<QuestionListBase>();

    [SerializeField]
    public List<ButtonSavingList> ButtonsData = new List<ButtonSavingList>();



    private const string  pathButtonDB = "ButtonsDB";
    public static ManagerListFromXML Instance
    {
        get;
        private set;
    }
    public void Init()
    {
        Instance = this;
        LoadXMLButtonSaveData();
    }

    public void LoadXMLData(string FileName)
    {
        Quest.Clear();
        TextAsset textAsset = (TextAsset)Resources.Load(FileName, typeof(TextAsset));
        XmlDocument doc = new XmlDocument();
        Debug.Log(textAsset.text);
        doc.LoadXml(textAsset.text);
        
        foreach (XmlNode node in doc.DocumentElement)
        {
            string quest = node.Attributes[0].Value;
            string righ1 = node.Attributes[1].Value;
            string wrong1 = node.Attributes[2].Value;
            string wrong2 = node.Attributes[3].Value;

            Quest.Add(new QuestionListBase(quest, righ1, wrong1, wrong2));
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        Init();
    }

    public void LoadXMLButtonSaveData()
    {

        TextAsset textAsset = (TextAsset)Resources.Load(pathButtonDB, typeof(TextAsset));
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(textAsset.text);
        

        foreach (XmlNode node in doc.DocumentElement)
        {
            string id = node.Attributes[0].Value;
            int need = int.Parse(node["Needed"].InnerText);
            ButtonsData.Add(new ButtonSavingList(id, need));
        }

    }

}
