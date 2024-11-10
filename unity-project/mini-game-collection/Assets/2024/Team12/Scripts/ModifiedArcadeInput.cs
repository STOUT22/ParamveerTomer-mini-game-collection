using System;
using UnityEngine;

namespace MiniGameCollection.Games2024.Team12
{
    public class ArcadeInput : MonoBehaviour
    {
        public static Player Player1 { get; private set; } = new Player(1);
        public static Player Player2 { get; private set; } = new Player(2);
        public static Player[] Players => new Player[] { Player1, Player2 };
        private static ArcadeInput Instance { get; set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        private void Update()
        {
            foreach (var player in Players)
            {
                // 8-way joystick (movement buttons)
                foreach (var button in player.Buttons)
                {
                    // Apply old input
                    button.PreviousState = button.CurrentState;
                    // Record current input for next update
                    bool state = button.Down;
                    button.CurrentState = state;
                }

                // Buttons
                foreach (var button in player.Buttons)
                {
                    // Apply old input
                    button.PreviousState = button.CurrentState;
                    // Record current input for next update
                    bool state = button.Down;
                    button.CurrentState = state;
                }
            }
        }

        public class Player
        {
            public Player(int id)
            {
                ID = id;
                // Axis for movement (joystick)
                if (id == 1)
                {
                    // Player 1: WASD keys
                    AxisX = new Axis("Horizontal");
                    AxisY = new Axis("Vertical");
                    Joystick8Way = new Axis2(AxisX, AxisY);
                    // Axis as button (WASD as directional buttons)
                    Left = new AxisButton("A", false);  // A key (left)
                    Right = new AxisButton("D", true);  // D key (right)
                    Up = new AxisButton("W", true);     // W key (up)
                    Down = new AxisButton("S", false);  // S key (down)
                }
                else
                {
                    // Player 2: Arrow keys
                    AxisX = new Axis("Horizontal");
                    AxisY = new Axis("Vertical");
                    Joystick8Way = new Axis2(AxisX, AxisY);
                    // Axis as button (Arrow keys as directional buttons)
                    Left = new AxisButton("LeftArrow", false);  // Left arrow key
                    Right = new AxisButton("RightArrow", true);  // Right arrow key
                    Up = new AxisButton("UpArrow", true);       // Up arrow key
                    Down = new AxisButton("DownArrow", false);  // Down arrow key
                }

                // Buttons for actions
                Action1 = new Button(id == 1 ? "e" : "l");  // E for Player 1, L for Player 2
                Action2 = new Button(id == 1 ? "r" : "k");  // R for Player 1, K for Player 2
            }

            public Button[] Buttons => new Button[] { Action1, Action2 };

            public static int ID { get; private set; }
            public Axis2 Joystick8Way { get; private set; }
            public Axis AxisX { get; private set; }
            public Axis AxisY { get; private set; }
            public Button Action1 { get; private set; }
            public Button Action2 { get; private set; }
            public AxisButton Up { get; private set; }
            public AxisButton Down { get; private set; }
            public AxisButton Left { get; private set; }
            public AxisButton Right { get; private set; }
        }

        public class Axis
        {
            public Axis(string inputName)
            {
                InputName = inputName;
            }

            public string InputName { get; private set; }
            public float Value => Input.GetAxis(InputName);

            public static implicit operator float(Axis axis)
            {
                return axis.Value;
            }
        }

        public class Axis2
        {
            public Axis2(Axis x, Axis y)
            {
                X = x;
                Y = y;
            }

            public Axis X { get; private set; }
            public Axis Y { get; private set; }

            public static implicit operator Vector2(Axis2 axis2)
            {
                return new Vector2(axis2.X.Value, axis2.Y.Value);
            }
        }

        public class AxisButton
        {
            public AxisButton(string inputName, bool isPositive)
            {
                InputName = inputName;
                AxisButtonDownFunction = isPositive ? CheckPositive : CheckNegative;
            }

            private readonly Func<bool> AxisButtonDownFunction;
            private bool CheckPositive() => Input.GetKey(InputName);
            private bool CheckNegative() => !Input.GetKey(InputName);
            private bool AxisButtonUp() => AxisButtonDownFunction();
            private bool AxisButtonDown() => AxisButtonUp();
            private bool AxisButtonPressed() => AxisButtonDown() && !PreviousState;
            private bool AxisButtonReleased() => AxisButtonUp() && PreviousState;

            public string InputName { get; private set; }
            public bool PreviousState { get; internal set; }
            public bool CurrentState { get; internal set; }
            public bool Down => AxisButtonDown();
            public bool Up => AxisButtonUp();
            public bool Pressed => AxisButtonPressed();
            public bool Released => AxisButtonReleased();
        }

        public class Button
        {
            public Button(string inputName)
            {
                InputName = inputName;
            }

            public string InputName { get; private set; }
            public bool PreviousState { get; internal set; }
            public bool CurrentState { get; internal set; }
            public bool Down => Input.GetKey(InputName);
            public bool Up => !Input.GetKey(InputName);
            public bool Pressed => Down && !PreviousState;
            public bool Released => Up && PreviousState;
        }
    }
}
