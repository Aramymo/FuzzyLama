using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(TMP_Text))]
public class LinkHandlerTMP : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Camera cameraToUse;

    public delegate void ClickOnLinkEvent(string keyword);
    public static event ClickOnLinkEvent OnClickedOnLinkEvent;
    private Canvas _canvasToCheck;
    private TMP_Text _textBox;
    public void OnPointerClick(PointerEventData eventData)
    {
        Vector3 mousePosition = new Vector3(eventData.position.x,eventData.position.y,0);
        var linkTaggedText = TMP_TextUtilities.FindIntersectingLink(_textBox,mousePosition,cameraToUse);
        if(linkTaggedText != -1)
        {
            TMP_LinkInfo linkInfo = _textBox.textInfo.linkInfo[linkTaggedText];
            OnClickedOnLinkEvent?.Invoke(linkInfo.GetLinkText());
        }
    }

    void Awake()
    {
        _textBox = GetComponent<TMP_Text>();
        _canvasToCheck = GetComponentInParent<Canvas>();
        if (_canvasToCheck.renderMode == RenderMode.ScreenSpaceOverlay)
        {
            cameraToUse = null;
        }
        else
        {
            cameraToUse = _canvasToCheck.worldCamera;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
