using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakBubbleController : MonoBehaviour
{
    [SerializeField] private GameObject[] _speakBubbles;

    public void HideAllBubbles()
    {
        for(int i = 0; i < _speakBubbles.Length; i++)
        {
            _speakBubbles[i].SetActive(false);
        }
    }
}
