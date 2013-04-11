using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RemoteControlPC
{
    class GlobalConstants
    {
        public const String PCPORT = "1992";
        public const String SCPORT = "1993";

        public const String SERVERSTATUSINLISTEN = "Server is listening!";
        public const String OK = "OK";
        public const String CMDPORT = "命令端口";
        public const String PORTINVALID = "端口无效";
        public const String PORT1556 = "1987";
        public const String PORT1555 = "1988";
        public const String PORTINVALID1555 = "无效，系统将指定1024到65535之间的端口!";
        public const String PORTINVALID1556 = "无效，系统将指定1024到65535之间的端口!";
        public const String PROMPTSELECTADDRESS = "请选择一个IP地址，在链接之前!";
        public const String BROKENLISTEN = "您已经断开了服务器的端口监听!";
        public const int BYTESIZE = 1024;
        public const int MAXLISTENSOCKETS = 20;
        public const int SOCKETSENDBUFFERSIZE = 600 * 1024;
        public const String DOLLAR = "$";
        public const String POUND = "#";
        public const String MOVEMOUSE = "moveMouse";
        public const String MOVEADD = "moveAdd";
        public const String MOUSEDOWN = "mouseDown";
        public const String MOUSEUP = "mouseUp";
        public const String CLICK = "click";
        public const String MOUSEWHEEL = "mouse_wheel";
        public const String KEYDOWN = "keydown";
        public const String KEYUP = "keyup";
        public const String CLOSECURRENT = "close_current";
        public const String COLON = ":";
        public const String ALTF4 = "%{F4}";
        public const String F5 = "F5";
        public const String F5VALUE = "{F5}";
        public const String ENTER = "enter";
        public const String ENTERVALUE = "{ENTER}";
        public const String RIGHTCLICK = "rightClick";
        public const String NEXT = "nex";
        public const String NEXTVALUE = "{RIGHT}";
        public const String ESC = "ESC";
        public const String ESCVALUE = "{ESC}";
        public const String PRE = "pre";
        public const String PREVALUE = "{LEFT}";
        public const String UP = "up";
        public const String UPVALUE = "{UP}";
        public const String DOWN = "down";
        public const String DOWNVALUE = "{DOWN}";
        public const String LOCKSCREEN = "lock_screen";
        public const String DOUBLECLICK = "doubleClick";
    }
}
