using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
   [SerializeField]private Vector2 startPos;
   [SerializeField]private Vector2 endPos;
   private int _minDistance;
   
   //detect swipe directions and execute proper operation
   private void Update()
   {
      if (Input.touchCount > 0)
      {
         
      }
   }


   private Enums.Swipe_Dir DetectSwipe()
   {
      float xdistance = endPos.x - startPos.x;
      float yDistance = endPos.y - startPos.y;

      if (Mathf.Abs(xdistance) >= _minDistance)//checking if its fullfilling basic requirement
      {
         return (xdistance > 0 ? Enums.Swipe_Dir.Right : Enums.Swipe_Dir.Left);
      }

      if (Mathf.Abs(yDistance)>=_minDistance)
      { 
         return (yDistance > 0 ? Enums.Swipe_Dir.Up : Enums.Swipe_Dir.Down);
      }

      return Enums.Swipe_Dir.None;
   }
}

public class Enums
{
   
   public enum Swipe_Dir
   {
      Up,
      Down,
      Left,
      Right,
      None
   }
}