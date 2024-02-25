using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PreferencesControl : MonoBehaviour
{
    [SerializeField] private TMP_Text _positiveAtributes;
    [SerializeField] private FuzzyLogic _fuzzyLogic;
    [SerializeField] private LamaEntity _lamaEntity;
    [SerializeField]private TooltipHandler _tooltipHandler;
    [SerializeField]private TMP_InputField _inputField;
    private List<string> lamaLikes;
    private List<string> lamaDislikes;
    void Awake()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DisplayAtributeWindow(LamaEntity selectedLama)
    {
        _lamaEntity = selectedLama;
        _positiveAtributes.text = "Мне нравится ";
        lamaLikes =  selectedLama.GetLikes;
        lamaDislikes =  selectedLama.GetDislikes;
        for(int i = 0; i < lamaLikes.Count; i++)
        {
            _positiveAtributes.text += $"<color=#FF953B><link='{_lamaEntity.gameObject.name}'>{lamaLikes[i]}</link></color>";
            if(i < lamaLikes.Count - 2)
            {
                _positiveAtributes.text += ", ";
            }
            else if(i == lamaLikes.Count - 1)
            {
                _positiveAtributes.text += ". ";
            }
            else
            {
                _positiveAtributes.text += " и ";
            }
        }
        if(lamaDislikes.Count != 0)
        {
            _positiveAtributes.text += "Но мне не нравится ";
            for(int i = 0; i < lamaDislikes.Count; i++)
            {
                _positiveAtributes.text += $"<color=#FF0000><link='{_lamaEntity.gameObject.name}'>{lamaDislikes[i]}</link></color>";
            }
        }
    }
    public void DisplayGeneratedCompliment()
    {
        _inputField.text = " ";
        List<string> keywordsList = new List<string>();
        keywordsList = _tooltipHandler.GenerateCompliment();
        Debug.Log(keywordsList[Random.Range(0,keywordsList.Count)]);
        _inputField.text = $"{keywordsList[Random.Range(0,keywordsList.Count)]} - это то, что мне понравилось больше всего";
        
    }

}
