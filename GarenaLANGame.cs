using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;

namespace GarenaLANGame
{
    class Room
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lp1, string lp2);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, String windowTitle);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, string lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, StringBuilder lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SendMessage(IntPtr hWnd, uint Msg, int wParam, StringBuilder lParam);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SendMessage(int hWnd, int Msg, int wparam, int lparam);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wparam, int lparam);

        const int WM_SETTEXT = 0x000c;
        const int WM_LBUTTONDOWN = 0x201;
        const int WM_LBUTTONUP = 0x202;
        const int WM_GETTEXT = 0x000D;
        const int WM_GETTEXTLENGTH = 0x000E;
        const int EM_GETLINECOUNT = 0xBA;
        const int EM_LINEINDEX = 0xBB;
        const int EM_LINELENGTH = 0xC1;
        const int EM_GETLINE = 0xc4;


        private static IntPtr NextWindowElement(IntPtr h, string fasdClass, string fasdWindow, int level)
        {
            IntPtr h2 = IntPtr.Zero;

            for (int i = 0; i < level; i++)
            {
                h2 = FindWindowEx(h, h2, fasdClass, fasdWindow);
            }

            return h2;
        }

        private IntPtr hGarena;
        private IntPtr hWnd2;
        private IntPtr hChatSent;
        private IntPtr hChatReceived;
        private IntPtr hButtonSend;
        private IntPtr hButtonBanlist;
        private IntPtr hButtonStartGame;
        private IntPtr hTitle;

        public Room()
        {
            this.hGarena = FindWindow("SkinDialog", "Garena LAN Game");
            if (this.hGarena.Equals(IntPtr.Zero))
            {
                Environment.Exit(0);
            }
            this.hWnd2 = NextWindowElement(hGarena, "#32770", null, 3);
            this.hTitle = NextWindowElement(hGarena, "Static", null, 1);
            this.hChatSent = NextWindowElement(hWnd2, "RichEdit20W", null, 2);
            this.hChatReceived = NextWindowElement(hWnd2, "RichEdit20W", null, 1);
            this.hButtonSend = NextWindowElement(hWnd2, "Button", null, 35);
        }

        public void startGame()
        {
            this.hButtonStartGame = NextWindowElement(hWnd2, "Button", null, 34);
            SendMessage(hButtonStartGame, WM_LBUTTONDOWN, IntPtr.Zero, IntPtr.Zero);
            SendMessage(hButtonStartGame, WM_LBUTTONUP, IntPtr.Zero, IntPtr.Zero);
        }

        public void addBan()
        {
            Thread.Sleep(2000);

            Console.WriteLine("Adding new ban");

            IntPtr hBanlist = NextWindowElement(IntPtr.Zero, "SkinDialog", null, 4);

            if (hBanlist.Equals(IntPtr.Zero))
            {
                Console.WriteLine("Banlist Window not found!");
            }

            IntPtr hTextUsername = NextWindowElement(hBanlist, "Edit", null, 1);
            IntPtr hTextReason = NextWindowElement(hBanlist, "Edit", null, 2);

            if (hTextUsername.Equals(IntPtr.Zero))
            {
                Console.WriteLine("hTextUsername Window not found!");
            }

            IntPtr hButtonAdd = NextWindowElement(hBanlist, "Button", null, 2);
            if (hButtonAdd.Equals(IntPtr.Zero))
            {
                Console.WriteLine("hButtonAdd Window not found!");
            }

            IntPtr hButtonCancel = NextWindowElement(hBanlist, "Button", null, 1);
            if (hButtonCancel.Equals(IntPtr.Zero))
            {
                Console.WriteLine("hButtonCancel Window not found!");
            }

            SendMessage(hTextUsername, WM_SETTEXT, IntPtr.Zero, "BG.ShielD");
            SendMessage(hTextReason, WM_SETTEXT, IntPtr.Zero, "Bot");
            SendMessage(hButtonAdd, WM_LBUTTONDOWN, IntPtr.Zero, IntPtr.Zero);
            SendMessage(hButtonAdd, WM_LBUTTONUP, IntPtr.Zero, IntPtr.Zero);
            Console.WriteLine("New ban added");
            Thread.Sleep(500);

            SendMessage(hTextUsername, WM_SETTEXT, IntPtr.Zero, "s7yler");
            SendMessage(hTextReason, WM_SETTEXT, IntPtr.Zero, "Noob");
            SendMessage(hButtonAdd, WM_LBUTTONDOWN, IntPtr.Zero, IntPtr.Zero);
            SendMessage(hButtonAdd, WM_LBUTTONUP, IntPtr.Zero, IntPtr.Zero);
            Console.WriteLine("New ban added");
            Thread.Sleep(500);

            SendMessage(hTextUsername, WM_SETTEXT, IntPtr.Zero, "Sandwich_BG");
            SendMessage(hTextReason, WM_SETTEXT, IntPtr.Zero, "Mega Slab");
            SendMessage(hButtonAdd, WM_LBUTTONDOWN, IntPtr.Zero, IntPtr.Zero);
            SendMessage(hButtonAdd, WM_LBUTTONUP, IntPtr.Zero, IntPtr.Zero);
            Console.WriteLine("New ban added");
            Thread.Sleep(500);

            SendMessage(hTextUsername, WM_SETTEXT, IntPtr.Zero, "PureDamage");
            SendMessage(hTextReason, WM_SETTEXT, IntPtr.Zero, "Oshte Po-Slab");
            SendMessage(hButtonAdd, WM_LBUTTONDOWN, IntPtr.Zero, IntPtr.Zero);
            SendMessage(hButtonAdd, WM_LBUTTONUP, IntPtr.Zero, IntPtr.Zero);
            Console.WriteLine("New ban added");
            Thread.Sleep(500);

            Console.WriteLine("Closing banlist");
            SendMessage(hButtonCancel, WM_LBUTTONDOWN, IntPtr.Zero, IntPtr.Zero);
            SendMessage(hButtonCancel, WM_LBUTTONUP, IntPtr.Zero, IntPtr.Zero);
        }

        public void openBanlist()
        {
            this.hButtonBanlist = NextWindowElement(hWnd2, "Button", null, 32);

            Thread tBan = new Thread(addBan);
            tBan.Start();

            Console.WriteLine("Opening banlist");
            SendMessage(hButtonBanlist, WM_LBUTTONDOWN, IntPtr.Zero, IntPtr.Zero);
            SendMessage(hButtonBanlist, WM_LBUTTONUP, IntPtr.Zero, IntPtr.Zero);

            Console.WriteLine("Done.");
        }

        public void openGameSettings()
        {
            IntPtr hButtonSettings = NextWindowElement(hWnd2, "Button", null, 33);
            SendMessage(hButtonSettings, WM_LBUTTONDOWN, IntPtr.Zero, IntPtr.Zero);
            SendMessage(hButtonSettings, WM_LBUTTONUP, IntPtr.Zero, IntPtr.Zero);
        }

        public void sendToChat(string text)
        {
            SendMessage(hChatSent, WM_SETTEXT, IntPtr.Zero, text);
            SendMessage(hButtonSend, WM_LBUTTONDOWN, IntPtr.Zero, IntPtr.Zero);
            SendMessage(hButtonSend, WM_LBUTTONUP, IntPtr.Zero, IntPtr.Zero);
        }

        public string getLine(int i)
        {
            int linesCount = SendMessage(hChatReceived, EM_GETLINECOUNT, 0, 0);

            if (i <= linesCount - 1)
            {
                int n = SendMessage(hChatReceived, EM_LINELENGTH, SendMessage(hChatReceived, EM_LINEINDEX, i, 0), 0);

                StringBuilder sb = new StringBuilder(" ", n);
                sb[0] = (char)(n + 1);

                SendMessage(hChatReceived, EM_GETLINE, i, sb);

                return sb.ToString();
            }
            return null;
        }


        public string getChat()
        {
            StringBuilder content = new StringBuilder();

            Int32 size = SendMessage((int)hChatReceived, WM_GETTEXTLENGTH, 0, 0).ToInt32();

            if (size > 0)
            {
                content = new StringBuilder(size + 1);
                SendMessage(hChatReceived, (int)WM_GETTEXT, content.Capacity, content);
            }

            return content.ToString();
        }

        public string getRoomName()
        {
            this.hTitle = NextWindowElement(hGarena, "Static", null, 1);
            if (this.hTitle != null)
            {
                Int32 size = SendMessage((int)this.hTitle, WM_GETTEXTLENGTH, 0, 0).ToInt32();
                StringBuilder title = new StringBuilder(size + 1);
                SendMessage(hTitle, (int)WM_GETTEXT, title.Capacity, title);
                string roomName = title.ToString();
                int index = roomName.LastIndexOf('(');
                if (index != -1)
                {
                    roomName = roomName.Substring(0, index);
                }

                return roomName.Trim();
            }
            return null;
        }
    }
}
