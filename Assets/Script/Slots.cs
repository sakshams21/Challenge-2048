using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class Slots : MonoBehaviour
    {
        public Image SlotImg;
        public TextMeshProUGUI SlotTxt;
        [SerializeField]private Vector2 SlotPos;

        public (int x, int y) SlotCoordinate => ((int)SlotPos.x, (int)SlotPos.y);
        public int Value;
    }
}