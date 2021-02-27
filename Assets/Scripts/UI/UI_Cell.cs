using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Cell : MonoBehaviour
{
    [SerializeField]
    UI_SweetPotato potatoPrefab = null;

    UI_SweetPotato created = null;
    public void OnClicked()
    {
        //already has
        if (null != created)
            return;

        created = Instantiate(potatoPrefab, this.transform);
    }
}
