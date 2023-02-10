using System;
using System.Security.Principal;
using Core.Menu;

namespace GamingDesktopApp;
internal class Program
{
    static void Main(string[] args)
    {
        bool autorizationIn = true;
        string? mune = "";
        int? userId = null;
        Menu.MenuStart(autorizationIn, mune, userId);
    }
}
