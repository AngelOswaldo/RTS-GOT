using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static bool seleccionGlobal;
    
    public static List<GameObject> npcControlados;

    [SerializeField]
    private Image selectionBoxImage;

    public static Rect selectionBoxRect;

    private Vector2 selectionStartPos;

    public delegate void SelectionAction();
    public static event SelectionAction OnBoxSelection;


    // Start is called before the first frame update
    void Start()
    { 
        seleccionGlobal = false;
    }

    // Update is called once per frame
    private void Awake()
    {
        npcControlados = new List<GameObject>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        selectionBoxImage.gameObject.SetActive(true);
        selectionBoxRect = new Rect();
        selectionStartPos = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.position.x < selectionStartPos.x)
        {

            selectionBoxRect.xMin = eventData.position.x;
            selectionBoxRect.xMax = selectionStartPos.x;

        }
        else {

            selectionBoxRect.xMin = selectionStartPos.x;
            selectionBoxRect.xMax = eventData.position.x;

        }

        if (eventData.position.y < selectionStartPos.y)
        {

            selectionBoxRect.yMin = eventData.position.y;
            selectionBoxRect.yMax = selectionStartPos.y;

        }
        else
        {

            selectionBoxRect.yMin = selectionStartPos.y;
            selectionBoxRect.yMax = eventData.position.y;

        }

        selectionBoxImage.rectTransform.offsetMin = selectionBoxRect.min;
        selectionBoxImage.rectTransform.offsetMax = selectionBoxRect.max;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }
}
