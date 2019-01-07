using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GridHandler : MonoBehaviour
{
    [SerializeField] private List<Button> gridButtons;
    private GameObject checkCurrentButton;


    private void Start()
    {
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            gridButtons.Add(this.gameObject.transform.GetChild(i).GetComponent<Button>());
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



}
