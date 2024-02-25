using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LamaEntity : MonoBehaviour
{
    [SerializeField] private List<string> _keywordsPositive;
    [SerializeField] private List<string> _keywordsNegative;
    [SerializeField] private List<string> _likes;
    [SerializeField] private List<string> _dislikes;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _speakBubble;
    [SerializeField] private TooltipHandler _tooltipHandler;

    public List<string> GetLikes
    {
        get{ return _likes;}
    }

    public List<string> GetDislikes
    {
        get{ return _dislikes;}
    }

    // Start is called before the first frame update
    void Start()
    {
        if(_dislikes.Count != 0)
        {
            for(int i = 0; i < _dislikes.Count; i++)
            {
                _keywordsNegative = _tooltipHandler.GetComplimentWords(_dislikes[i], _keywordsNegative);
            }
        }
        for(int i = 0; i < _likes.Count; i++)
        {
            _keywordsPositive = _tooltipHandler.GetComplimentWords(_likes[i], _keywordsPositive);
        }
    }

    public int CheckForLikes(string _compliment, int counter)
    {
            for(int i = 0; i < _keywordsPositive.Count; i++)
            {
                if(_compliment.Contains(_keywordsPositive[i],System.StringComparison.CurrentCultureIgnoreCase))
                {
                    //_tooltipHandler.GetComplimentWords();
                    counter++;
                    Debug.Log($"{gameObject.name} really liked ur compliment");
                    return counter;
                    //_animator.Play("LamaLove_Clip");
                }
            }
            return counter;
    }

    public int CheckForDislikes(string _compliment, int counter)
    {
            Debug.Log($"{gameObject.name} check for dislikes");
            for(int i = 0; i < _keywordsNegative.Count; i++)
            {
                if(_compliment.Contains(_keywordsNegative[i],System.StringComparison.CurrentCultureIgnoreCase))
                {
                    counter--;
                    Debug.Log("Lamas did not like ur compliment");
                }
            }
            return counter;
    }
    
}
