using System;
using System.Security.Principal;
using Core.Menu;
using Core.Models;

namespace GamingDesktopApp;
internal class Program
{
    static void Main(string[] args)
    {
        bool autorizationIn = false;
        string? mune = "";
        User? user = null;
        Menu.MenuStart(autorizationIn, mune, user);
    }
}
