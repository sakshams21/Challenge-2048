using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//Movement of cell animation will be done in this script
public class CellAnimation : MonoBehaviour
{

    public void MoveCell(GameObject ObjecToMove, Vector3 EndCell)
    {
        ObjecToMove.transform.DOLocalMove(EndCell, 0.25f, true).SetEase(Ease.Linear);
    }


}
