﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace TiX.Utilities
{
    public sealed class ShellHelper
    {
        private static readonly IntPtr CustomParam = new IntPtr(0x7A8E);
        private const int SendTimeout    = 500;
        private const int RecieveTimeout = 500;

        private readonly string m_uniqueName;
        public ShellHelper(string uniqueName)
        {
            this.m_uniqueName = uniqueName;
        }

        private IList<byte[]>   m_data = new List<byte[]>();
        private DateTime        m_timeOut;
        private DateTime          TimeOut
        {
            get { lock (m_data) return this.m_timeOut; }
            set { lock (m_data) this.m_timeOut = value; }
        }

        public IList<byte[]> GetOrSend(byte[] data)
        {
            bool createdNew;
            var mutex = new Mutex(true, this.m_uniqueName, out createdNew);

            this.m_data.Add(data);

            if (createdNew || mutex.WaitOne(0))
            {
                this.TimeOut = DateTime.UtcNow.AddMilliseconds(RecieveTimeout);
                
                var proc = new NativeMethods.WndProc(this.CustomProc);
                var hwnd = this.CreateWindow(proc);
    
                // 마와레 마와레
                // 메시지 루프를 돌아요
                {
                    var msg = new NativeMethods.MSG();

                    while (DateTime.UtcNow <= this.TimeOut)
                    {
                        if (NativeMethods.PeekMessage(ref msg, IntPtr.Zero, 0, 0, NativeMethods.PM_REMOVE))
                        {
                            NativeMethods.TranslateMessage(ref msg);
                            NativeMethods.DispatchMessage(ref msg);
                        }
                    }
                }

                NativeMethods.DestroyWindow(hwnd);

                mutex.Dispose();
            }
            else
            {
                mutex.Dispose();

                bool succ = false;
                
                // 일정 시간동안 윈도우 찾고 데이터 전송함. 전송에 실패하면 새로운 인스턴스를 띄움
                var endTime = DateTime.UtcNow.AddMilliseconds(SendTimeout);
                IntPtr hwnd;
                do
                {
                    hwnd = NativeMethods.FindWindow(this.m_uniqueName, null);
                    if (hwnd != IntPtr.Zero)
                    {
                        if (SendData(hwnd, data))
                        {
                            succ = true;
                            break;
                        }
                    }
                    Thread.Sleep(50);
                } while (endTime < DateTime.UtcNow);
                
                if (succ)
                    return null;
            }

            return this.m_data;
        }

        private IntPtr CreateWindow(NativeMethods.WndProc proc)
        {
            var wndClass			= new NativeMethods.WNDCLASS();
            wndClass.lpszClassName	= this.m_uniqueName;
            wndClass.lpfnWndProc	= Marshal.GetFunctionPointerForDelegate(proc);

            var resRegister	= NativeMethods.RegisterClass(ref wndClass);
            var resError	= Marshal.GetLastWin32Error();

            if (resRegister == 0 && resError != NativeMethods.ERROR_CLASS_ALREADY_EXISTS)
                throw new Exception();

            return NativeMethods.CreateWindowEx(0, this.m_uniqueName, null, 0, 0, 0, 0, 0, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
        }

        private IntPtr CustomProc(IntPtr hwnd, uint msg, IntPtr wParam, IntPtr lParam)
        {
            if (msg == NativeMethods.WM_COPYDATA && wParam == CustomParam)
            {
                try
                {
                    var data = (NativeMethods.COPYDATASTRUCT)Marshal.PtrToStructure(lParam, typeof(NativeMethods.COPYDATASTRUCT));

                    if (data.dwData == CustomParam)
                    {
                        var buff = new byte[data.cbData];
                        Marshal.Copy(data.lpData, buff, 0, data.cbData);

                        lock (this.m_data)
                        {
                            this.m_data.Add(buff);

                            this.TimeOut = DateTime.UtcNow.AddMilliseconds(RecieveTimeout);
                        }
                    }

                    return CustomParam;
                }
                catch
                { }
            }

            return NativeMethods.DefWindowProc(hwnd, msg, wParam, lParam);
        }

		private bool SendData(IntPtr hwnd, byte[] data)
		{
            var lpData = IntPtr.Zero;
			try
			{
				lpData = Marshal.AllocHGlobal(data.Length);
				Marshal.Copy(data, 0, lpData, data.Length);

                var lParam = IntPtr.Zero;
                try
                {
                    lParam = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NativeMethods.COPYDATASTRUCT)));
                    var copydata = new NativeMethods.COPYDATASTRUCT();
                    copydata.dwData = CustomParam;
                    copydata.cbData = data.Length;
                    copydata.lpData = lpData;

                    Marshal.StructureToPtr(copydata, lParam, true);

                    if (NativeMethods.SendMessage(hwnd, NativeMethods.WM_COPYDATA, CustomParam, lParam) == CustomParam)
                        return true;
                }
                catch
                { }
                finally
                {
                    if (lParam != IntPtr.Zero) Marshal.FreeHGlobal(lParam);
                }
			}
			catch
			{ }
			finally
			{
				if (lpData != IntPtr.Zero) Marshal.FreeHGlobal(lpData);
			}

            return false;
		}

        private static class NativeMethods
        {
            public delegate IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool PeekMessage(
                [In] ref MSG lpMsg,
                IntPtr hwnd,
                uint wMsgFilterMin,
                uint wMsgFilterMax,
                uint wRemoveMsg);

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool TranslateMessage(
                [In] ref MSG lpMsg);

            [DllImport("user32.dll")]
            public static extern IntPtr DispatchMessage(
                [In] ref MSG lpmsg);

            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            public static extern IntPtr FindWindow(
                string lpClassName,
                string lpWindowName);

            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            public static extern IntPtr SendMessage(
                IntPtr hWnd,
                uint Msg,
                IntPtr wParam,
                IntPtr lParam);

            [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern ushort RegisterClass(
                ref WNDCLASS pcWndClassEx);

            [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern IntPtr CreateWindowEx(
                int dwExStyle,
                string lpClassName,
                string lpWindowName,
                int dwStyle,
                int x,
                int y,
                int nWidth,
                int nHeight,
                IntPtr hWndParent,
                IntPtr hMenu,
                IntPtr hInstance,
                IntPtr lpParam);

            [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern IntPtr DefWindowProc(
                IntPtr hWnd,
                uint msg,
                IntPtr wParam,
                IntPtr lParam);

            [DllImport("user32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool DestroyWindow(
                IntPtr hWnd);

            //////////////////////////////////////////////////

            [StructLayout(LayoutKind.Sequential)]
            public struct WNDCLASS
            {
                public int		style;
                public IntPtr	lpfnWndProc;
                public int		cbClsExtra;
                public int		cbWndExtra;
                public IntPtr	hInstance;
                public IntPtr	hIcon;
                public IntPtr	hCursor;
                public IntPtr	hbrBackground;
                [MarshalAs(UnmanagedType.LPTStr)]
                public string	lpszMenuName;
                [MarshalAs(UnmanagedType.LPTStr)]
                public string	lpszClassName;
            }

		    [StructLayout(LayoutKind.Sequential)]
		    public struct COPYDATASTRUCT
		    {
			    public IntPtr	dwData;
			    public int		cbData;
			    public IntPtr	lpData;
		    }

            [StructLayout(LayoutKind.Sequential)]
            public struct MSG
            {
                public int      hwnd;
                public int      message;
                public int      wParam;
                public int      lParam;
                public int      time;
                public POINTAPI pt;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct POINTAPI
            {
                public int x;
                public int y;
            }

            //////////////////////////////////////////////////

            public const uint ERROR_CLASS_ALREADY_EXISTS = 1410;
            public const uint WM_COPYDATA = 0x4A;
            public const uint PM_REMOVE = 0x1;
        }
    }
}
