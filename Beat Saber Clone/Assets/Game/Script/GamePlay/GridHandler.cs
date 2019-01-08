using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GridHandler : MonoBehaviour
{
    [SerializeField] private GameObject gridObj;
    [SerializeField] private GameObject gridObj1;

    [SerializeField] private List<Button> gridButtons;
    [SerializeField] private List<Button> gridButtons1;
    private GameObject checkCurrentButton;
    private GameObject checkCurrentButton1;


    private void Start()
    {
        for (int i = 0; i < gridObj.transform.childCount; i++)
        {
            gridButtons.Add(gridObj.transform.GetChild(i).GetComponent<Button>());
        }
        for (int i = 0; i < gridObj1.transform.childCount; i++)
        {
            gridButtons1.Add(gridObj1.transform.GetChild(i).GetComponent<Button>());
        }
    }

    public void ChangeButton(GameObject _object)
    {
        if(_object != checkCurrentButton)
        {
            for (int i = 0; i < gridButtons.Count; i++)
            {
                if (_object.transform.gameObject.GetComponent<Button>() != gridButtons[i])
                    gridButtons[i].interactable = false;
                else
                    gridButtons[i].interactable = true;
            }
        }
    }

    public void ChangeButtonNull()
    {
        for (int i = 0; i < gridButtons.Count; i++)
        {
            gridButtons[i].interactable = false;
        }
    }

    public void ChangeButton1(GameObject _object)
    {
        if (_object != checkCurrentButton1)
        {
            for (int i = 0; i < gridButtons1.Count; i++)
            {
                if (_object.transform.gameObject.GetComponent<Button>() != gridButtons1[i])
                    gridButtons1[i].interactable = false;
                else
                    gridButtons1[i].interactable = true;
            }
        }
    }

    public void ChangeButton1Null()
    {
        for (int i = 0; i < gridButtons1.Count; i++)
        {
            gridButtons1[i].interactable = false;
        }
    }
}
