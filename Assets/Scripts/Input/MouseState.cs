using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace kmgr.fieldgame.Assets.Scripts.Input
{
    public class MouseState
    {
        public Vector2 Position { get; set; }
        public bool[] ButtonsPushed { get; set; }

        public MouseState()
        {
            Position = new Vector2();
            ButtonsPushed = new bool[2];
        }
    }
}
