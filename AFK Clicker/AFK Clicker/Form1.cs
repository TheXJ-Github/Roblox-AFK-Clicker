using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Point = System.Drawing.Point;

namespace AFK_Clicker
{   
    public partial class Form1 : Form
    {
        // dlls
        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(uint nInputs, Input[] pInputs, int cbSize);

        [DllImport("user32.dll")]
        private static extern IntPtr GetMessageExtraInfo();

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        // flags
        [Flags]
        public enum InputType
        {
            Mouse = 0,
            Keyboard = 1,
            Hardware = 2
        }
        [Flags]

        public enum KeyEventF
        {
            KeyDown = 0x0000,
            ExtendedKey = 0x0001,
            KeyUp = 0x0002,
            Unicode = 0x0004,
            Scancode = 0x0008
        }
        [Flags]

        public enum MouseEventF
        {
            Absolute = 0x8000,
            HWheel = 0x01000,
            Move = 0x0001,
            MoveNoCoalesce = 0x2000,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            VirtualDesk = 0x4000,
            Wheel = 0x0800,
            XDown = 0x0080,
            XUp = 0x0100
        }

        // structures
        [StructLayout(LayoutKind.Sequential)]
        public struct MouseInput
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct KeyboardInput
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct HardwareInput
        {
            public uint uMsg;
            public ushort wParamL;
            public ushort wParamH;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct InputUnion
        {
            [FieldOffset(0)] public MouseInput mi;
            [FieldOffset(0)] public KeyboardInput ki;
            [FieldOffset(0)] public HardwareInput hi;
        }

        public struct Input
        {
            public int type;
            public InputUnion u;
        }

        // begin everything else

        int Maximum_Cursor_Offset = 1;
        Point Activation_Position = new Point(0, 0);

        /// <summary>
        /// Gets the position of the user's cursor
        /// </summary>
        /// <returns>Point lpPoint</returns>
        public static Point GetCursorPosition()
        {
            return Cursor.Position;
        }

        /// <summary>
        /// Moves the cursor X and Y pixels
        /// </summary>
        /// <param name="lpPointShift"></param>
        public static void MoveCursor(Point lpPointShift)
        {
            Point cursorPoint = GetCursorPosition();
            Point newCursorPoint = new Point(cursorPoint.X + lpPointShift.X, cursorPoint.Y + lpPointShift.Y) ;

            Cursor.Position = newCursorPoint;
        }

        public static bool IsCursorBeyondOffset(Point activatePoint, int maxOffset)
        {
            if ((GetCursorPosition().X) < (activatePoint.X - maxOffset))
            {
                return true;
            }
            if ((GetCursorPosition().X) > (activatePoint.X + maxOffset))
            {
                return true;
            }

            if ((GetCursorPosition().Y) < (activatePoint.Y - maxOffset))
            {
                return true;
            }

            if ((GetCursorPosition().Y) > (activatePoint.Y + maxOffset))
            {
                return true;
            }

            return false;
        }

        public static void MouseLeftClick()
        {
            Input[] inputs = new Input[]
{
                new Input
                {
                    type = (int) InputType.Mouse,
                    u = new InputUnion
                    {
                        mi = new MouseInput
                        {
                            dx = 0,
                            dy = 0,
                            dwFlags = (uint)(MouseEventF.Move | MouseEventF.LeftDown),
                            dwExtraInfo = GetMessageExtraInfo()
                        }
                    }
                },
                    new Input
                    {
                        type = (int) InputType.Mouse,
                        u = new InputUnion
                        {
                            mi = new MouseInput
                            {
                                dwFlags = (uint)MouseEventF.LeftUp,
                                dwExtraInfo = GetMessageExtraInfo()
                            }
                        }
                    }
                };

            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
        }
        bool isClickerActive = false;

        private void AfkClick()
        {
            if (isClickerActive == false)
            {
                isClickerActive = true;
                bool performAutoclick = true;

                Activation_Position = GetCursorPosition();
                Maximum_Cursor_Offset = (int)upDown.Value;

                GraphicsDrawing.DrawRectangleOutline(Activation_Position, Maximum_Cursor_Offset);

                while (performAutoclick == true)
                {
                    Thread.Sleep(1000);
                    if (IsCursorBeyondOffset(Activation_Position, Maximum_Cursor_Offset))
                    {
                        performAutoclick = false;
                    }
                    else
                    {
                        MouseLeftClick();
                        GraphicsDrawing.DrawRectangleOutline(Activation_Position, Maximum_Cursor_Offset);
                    }
                }

                GraphicsDrawing.ClearDrawings();
                MessageBox.Show("The autoclicker has been turned off", "Roblox AFK Clicker");
                isClickerActive = false;
            }
        }

        private void KeyPressed()
        {
            if (isClickerActive == false)
            {
                AfkClick();
            }
        }

        public Form1()
        {
            InitializeComponent();

            KeyListener k = new KeyListener();
            k.onPress("F6", KeyPressed);
        }

        private void buttonClick_Click(object sender, EventArgs e)
        {
            MoveCursor(new Point(150, 150));
            AfkClick();
        }

        private void TryVisitLink(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://github.com/TheXJ-Github/RobloxAfkClicker");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link!\n" + ex, "Roblox AFK Clicker");
            }
        }

        private void ShowHelp(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(
                 "To activate the auto-clicker, you would either:"
                + "\nPress the 'Begin Clicking!' button"
                + "\nPress the F6 key"
                + "\n"
                + "\nWhen you do this, a red square will appear centered where your cursor is"
                + "\nWhat does the red square mean? It's how far your cursor can move without turning off the auto-clicker."
                + "\n" +
                "\nYou can customize the size of the red square, the option is above the button.",
                "Roblox AFK Clicker");
        }
    }

    public class GraphicsDrawing
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("User32.dll")]
        private static extern int ReleaseDC(IntPtr hWnd, IntPtr dc);

        [DllImport("user32.dll")]
        private static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

        public static void DrawRectangleOutline(Point lpCenter, int lpSize)
        {
            IntPtr hdc = GetDC(IntPtr.Zero);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromHdc(hdc);

            Pen pen = new Pen(Color.Red);

            // points for drawing
            Point p1 = new Point(lpCenter.X - lpSize, lpCenter.Y - lpSize);
            Point p2 = new Point(lpCenter.X - lpSize, lpCenter.Y - lpSize);

            // left
            p2.Y += (lpSize * 2);
            g.DrawLine(pen, p1, p2);

            // bottom
            p1.Y += (lpSize * 2);
            p2.X += (lpSize * 2);
            g.DrawLine(pen, p1, p2);

            // right
            p1.X += (lpSize * 2);
            p2.Y -= (lpSize * 2);
            g.DrawLine(pen, p1, p2);

            // top
            p1.Y -= (lpSize * 2);
            p2.X -= (lpSize * 2);
            g.DrawLine(pen, p1, p2);

            ReleaseDC(IntPtr.Zero, hdc);
        }

        public static void ClearDrawings()
        {
            InvalidateRect(IntPtr.Zero, IntPtr.Zero, false);
        }
    }
}
