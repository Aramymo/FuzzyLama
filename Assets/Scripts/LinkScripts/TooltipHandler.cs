using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TooltipHandler : MonoBehaviour
{
    [SerializeField] private GameObject _tooltipContainer;
    [SerializeField] private List<ToolTipInfos> _tooltipContentList;

    [SerializeField] private TMP_Text _tooltipDescriptionTMP;

    // Start is called before the first frame update
    void Awake()
    {
        _tooltipDescriptionTMP = _tooltipContainer.GetComponentInChildren<TMP_Text>();
    }
    private void OnEnable()
    {
        LinkHandlerTMP.OnClickedOnLinkEvent += GetTooltipInfo;
    }

    private void OnDisable()
    {
        LinkHandlerTMP.OnClickedOnLinkEvent -= GetTooltipInfo;
    }
    // Update is called once per frame
    void GetTooltipInfo(string keyword)
    {
        _tooltipDescriptionTMP.text = " ";
        foreach(var entry in _tooltipContentList)
        {
            if(entry.Keyword == keyword)
            {
                if(!_tooltipContainer.gameObject.activeInHierarchy)
                {
                    _tooltipContainer.gameObject.SetActive(true);
                }
                for(int i = 0; i < entry.complimentWords.Count; i++)
                {
                    _tooltipDescriptionTMP.text += entry.complimentWords[i] + " ";
                }
                return;
            }
        }
    }
    public List<string> GetComplimentWords(string keyword, List<string> lamasLikes)
    {
        foreach(var entry in _tooltipContentList)
        {
            if(entry.Keyword == keyword)
            {
                for(int i = 0; i < entry.complimentWords.Count; i++)
                {
                    lamasLikes.Add(entry.complimentWords[i]);
                }
            }
        }
        return lamasLikes;
    }

    public List<string> GenerateCompliment()
    {
        Dictionary<string,int> keywordsDictionary = new Dictionary<string, int>();
        List<string> workingComplimentWords = new List<string>();
        foreach(var entry in _tooltipContentList)
        {
            for(int i = 0; i < entry.complimentWords.Count; i++)
            {
                if(!keywordsDictionary.ContainsKey(entry.complimentWords[i]))
                {
                    keywordsDictionary.Add(entry.complimentWords[i],1);
                }
                else
                {
                    keywordsDictionary[entry.complimentWords[i]] += 1;
                }
            }
        }
        foreach(var keyword in keywordsDictionary)
        {
            if(keyword.Value >= 3)
            {
                workingComplimentWords.Add(keyword.Key);
            }
        }
        return workingComplimentWords;
    }
}
