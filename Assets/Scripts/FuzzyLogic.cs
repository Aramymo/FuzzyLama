using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FuzzyLogic : MonoBehaviour
{
    private LamaEntity[] _lamas;

    [SerializeField] private GameObject _gfxContainer;
    private Animator[] _animator;
    private int _likeCounter;
    
    // Start is called before the first frame update
    void Start()
    {
        _lamas = GetComponentsInChildren<LamaEntity>();
        _animator = _gfxContainer.GetComponentsInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FuzzyCheckCompliment(TMP_InputField inputField)
    {
        string compliment = inputField.text;
        _likeCounter = 0;
        for(int i = 0; i < _lamas.Length; i++)
        {
            _likeCounter = _lamas[i].CheckForDislikes(compliment, _likeCounter);
        }
        Debug.Log($"LIKE AFTER DISLIKES {_likeCounter}");
        if (_likeCounter < 0)
        {
            for(int i = 0; i < _animator.Length; i++)
            {
                _animator[i].Play("LamaSad_Clip");
            }
        }
        else
        {
            for(int i = 0; i < _lamas.Length; i++)
            {
                _likeCounter = _lamas[i].CheckForLikes(compliment, _likeCounter);
            }
            Debug.Log($"_lamas.Count {_likeCounter}");
            if(_likeCounter >= 3)
            {
                for(int i = 0; i < _animator.Length; i++)
                {
                    _animator[i].Play("LamaLove_Clip");
                }
            }
            else
            {
                for(int i = 0; i < _animator.Length; i++)
                {
                    _animator[i].Play("LamaOkay_Clip");
                }
            }
        }
    }
}
