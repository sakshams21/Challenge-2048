using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    [System.Serializable]
    public struct Slots
    {
        [FormerlySerializedAs("Img")] public Image img;
        [FormerlySerializedAs("Txt")] public TextMeshProUGUI txt;
        [FormerlySerializedAs("Value")] public int value;
        [FormerlySerializedAs("Cell_Pos")] public Vector2 cellPos;
        public bool isfree;
    }

    [FormerlySerializedAs("Color_ref")] [Header("Script Ref")]
    public NumberColors colorRef;


    [FormerlySerializedAs("GridSlots")]
    [Space(10f)]
    [Header("Slots Ref")]

    public Slots[] gridSlots;

    public int x1, x2, x3, x4;
    public int[,] Matrix_Blueprint = new int[4, 4] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };

    //---------METHODS AREA-------------------------
    public void ColorToDefault(Image img) => img.color = colorRef.Number_Color[0];

    //for individual cells
    public void Assign_Value_Color(int value, int SlotIndex)
    {
        gridSlots[SlotIndex].value = value;
        gridSlots[SlotIndex].txt.text = value.ToString();
        gridSlots[SlotIndex].isfree = gridSlots[SlotIndex].value == 0 ? true : false;
        gridSlots[SlotIndex].img.color = colorRef.Number_Color[(int)Mathf.Log(value, 2)];
    }

    public void ChangeColor_via_Slots(int value, Slots var_slot)
    {
        var_slot.value = value;
        var_slot.txt.text = value.ToString();
        var_slot.isfree = var_slot.value == 0 ? true : false;
        var_slot.img.color = colorRef.Number_Color[(int)Mathf.Log(value, 2)];
    }


    //will check for all the cells
    private void Check_all_Slots()
    {
        for (int i = 0; i < gridSlots.Length; i++)
        {
            if (gridSlots[i].value == 0)
            {
                Assign_Value_Color(0, i);
                gridSlots[i].isfree = true;
            }
            else
            {
                Assign_Value_Color(gridSlots[i].value, i);
                gridSlots[i].isfree = false;
            }
        }
    }

    //resets matrix to zero
    public void Reset_Matrix()
    {
        for (int i = 0; i < Matrix_Blueprint.GetLength(0); i++)
        {
            for (int j = 0; j < Matrix_Blueprint.GetLength(1); j++)
            {
                Matrix_Blueprint[i, j] = 0;
            }
        }
    }

    //update the displayed cells with latest matrix
    public void UpdateCells()
    {
        for (int i = 0; i < Matrix_Blueprint.GetLength(0); i++)
        {
            for (int j = 0; j < Matrix_Blueprint.GetLength(1); j++)
            {
                for (int k = 0; k < gridSlots.Length; k++)
                {
                    if (gridSlots[k].cellPos.x == i + 1 && gridSlots[k].cellPos.y == j + 1)

                        Assign_Value_Color(Matrix_Blueprint[i, j], k);
                }
            }
        }
    }

    public void AssignValue_Matrix(int xCOR, int yCOR, int value)
    {
        Matrix_Blueprint[xCOR, yCOR] = value;
    }

    [ContextMenu("matrixtest")]
    //matrix manager when player swipes left
    public void SwipeLeft()
    {
        int[,] DummyMatrix = new int[Matrix_Blueprint.GetLength(0), Matrix_Blueprint.GetLength(1)];
        int[] localArray = new int[Matrix_Blueprint.GetLength(1)];
        int[] localOperationArray = new int[Matrix_Blueprint.GetLength(1)];
        int count = 0;
        int x = 0;
        bool skip = false;
        //storing one row of the matrix in a local array

        Matrix_Blueprint[0, 0] = x1;
        Matrix_Blueprint[0, 1] = x2;
        Matrix_Blueprint[0, 2] = x3;
        Matrix_Blueprint[0, 3] = x4;

        for (int j = 0; j < Matrix_Blueprint.GetLength(1); j++)
        {
            localArray[j] = Matrix_Blueprint[0, j];
        }
        //operating ont he local array
        for (int i = 0; i < localArray.Length; i++)
        {


            if (localArray[i] == 0)
            {

                continue;
            }

            if (i != 0 && !skip)
            {
                if (x == localArray[i])
                {
                    localOperationArray.SetValue(localArray[i] * 2, count);
                    x = 0;
                    count++;
                    skip = true;
                }
                else
                {
                    localOperationArray.SetValue(localArray[i], count);
                    x = localArray[i];
                    count++;
                }
            }
            else
            {
                x = localArray[i];
                skip = false;
            }


        }


        foreach (var item in localOperationArray)
        {

            print(item);
        }



    }













    [ContextMenu("pow2")]
    public void test()
    {
        print(Mathf.Log(0, 2));
    }
}
