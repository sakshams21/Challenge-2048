using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [System.Serializable]
    public struct Slots
    {
        public Image Img;
        public TextMeshProUGUI Txt;
        public int Value;
        public Vector2 Cell_Pos;
        public bool isfree;
    }

    [Header("Script Ref")]
    public NumberColors Color_ref;


    [Space(10f)]
    [Header("Slots Ref")]

    public Slots[] GridSlots;

    public int x1, x2, x3, x4;
    public int[,] Matrix_Blueprint = new int[4, 4] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };

    //---------METHODS AREA-------------------------
    public void ColorToDefault(Image img) => img.color = Color_ref.Number_Color[0];

    //for individual cells
    public void Assign_Value_Color(int value, int SlotIndex)
    {
        GridSlots[SlotIndex].Value = value;
        GridSlots[SlotIndex].Txt.text = value.ToString();
        GridSlots[SlotIndex].isfree = GridSlots[SlotIndex].Value == 0 ? true : false;
        GridSlots[SlotIndex].Img.color = Color_ref.Number_Color[(int)Mathf.Log(value, 2)];
    }

    public void ChangeColor_via_Slots(int value, Slots var_slot)
    {
        var_slot.Value = value;
        var_slot.Txt.text = value.ToString();
        var_slot.isfree = var_slot.Value == 0 ? true : false;
        var_slot.Img.color = Color_ref.Number_Color[(int)Mathf.Log(value, 2)];
    }


    //will check for all the cells
    private void Check_all_Slots()
    {
        for (int i = 0; i < GridSlots.Length; i++)
        {
            if (GridSlots[i].Value == 0)
            {
                Assign_Value_Color(0, i);
                GridSlots[i].isfree = true;
            }
            else
            {
                Assign_Value_Color(GridSlots[i].Value, i);
                GridSlots[i].isfree = false;
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
                for (int k = 0; k < GridSlots.Length; k++)
                {
                    if (GridSlots[k].Cell_Pos.x == i + 1 && GridSlots[k].Cell_Pos.y == j + 1)

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
        int[] localOperation_Array = new int[Matrix_Blueprint.GetLength(1)];
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
                    localOperation_Array.SetValue(localArray[i] * 2, count);
                    x = 0;
                    count++;
                    skip = true;
                }
                else
                {
                    localOperation_Array.SetValue(localArray[i], count);
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


        foreach (var item in localOperation_Array)
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
