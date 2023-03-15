using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Script
{
    public class GameManager : MonoBehaviour
    {
        [Header("Script Ref")] 
        [SerializeField] private NumberColors ColorRef;

        [Space(10f)] [Header("Slots Ref")]
        [SerializeField] private Slots[] GridSlots;
        
        #region Private variables
        
        private Slots[] _gridsToArray= new Slots[4];

        #endregion

        //changes color according to the value
        private void Assign_Value_Color(int value, Slots slot)
        {
            slot.Value = value;
            slot.SlotTxt.text = value.ToString();
            
            //it checks what 2 power it has (eg 8= 2^3 then it will take index 3rd from Color Ref)
            slot.SlotImg.color = ColorRef.Number_Color[(int)Mathf.Log(value, 2)];
        }


        //will check for all the cells and apply the color as well
        private void Check_all_Slots()
        {
            foreach (var item in GridSlots)
            {
                Assign_Value_Color(item.Value, item);
            }
        }

        private void ResetAllSlots()
        {
            foreach (var item in GridSlots)
            {
                Assign_Value_Color(0, item);
            }
        }


        private void ConvertToArray(Enums.Swipe_Dir swipeDir)
        {
            var tempList1= new List<Slots>();
            var tempList2= new List<Slots>();
            var tempList3= new List<Slots>();
            var tempList4= new List<Slots>();

            switch (swipeDir)
            {
                case Enums.Swipe_Dir.Up:
                    for (var index = GridSlots.Length-1; index >=0; index--)
                    {
                        var item = GridSlots[index];
                        switch (item.SlotCoordinate.y)
                        {
                            case 1:
                                tempList1.Add(item);
                                break;
                            case 2:
                                tempList2.Add(item);
                                break;
                            case 3:
                                tempList3.Add(item);
                                break;
                            case 4:
                                tempList4.Add(item);
                                break;
                            default:
                                return;
                        }
                    }
                    break;
                case Enums.Swipe_Dir.Down:
                    foreach (var item in GridSlots)
                    {
                        switch (item.SlotCoordinate.y)
                        {
                            case 1:
                                tempList1.Add(item);
                                break;
                            case 2:
                                tempList2.Add(item);
                                break;
                            case 3:
                                tempList3.Add(item);
                                break;
                            case 4:
                                tempList4.Add(item);
                                break;
                            default:
                                return;
                        }
                    }
                    break;
                case Enums.Swipe_Dir.Left:
                    for (var index = GridSlots.Length-1; index >=0; index--)
                    {
                        var item = GridSlots[index];
                        switch (item.SlotCoordinate.x)
                        {
                            case 1:
                                tempList1.Add(item);
                                break;
                            case 2:
                                tempList2.Add(item);
                                break;
                            case 3:
                                tempList3.Add(item);
                                break;
                            case 4:
                                tempList4.Add(item);
                                break;
                            default:
                                return;
                        }
                    }
                    break;
                case Enums.Swipe_Dir.Right:
                    foreach (var item in GridSlots)
                    {
                        switch (item.SlotCoordinate.x)
                        {
                            case 1:
                                tempList1.Add(item);
                                break;
                            case 2:
                                tempList2.Add(item);
                                break;
                            case 3:
                                tempList3.Add(item);
                                break;
                            case 4:
                                tempList4.Add(item);
                                break;
                            default:
                                return;
                        }
                    }
                    break;
                case Enums.Swipe_Dir.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(swipeDir), swipeDir, null);
            }
            
        }

        //main algo here
        private void ExecuteOperation(List<Slots> arr)
        {
            
        }
    }
}
