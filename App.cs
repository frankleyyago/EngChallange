using System;
using Autodesk.Revit.UI;
using System.IO;
using System.Reflection;
using System.Windows.Media.Imaging;

namespace EngChallange
{
    internal class App : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            //Create a ribbon tab
            application.CreateRibbonTab("EngChallange");

            //Retrieve the path of the current executing assembly
            string path = Assembly.GetExecutingAssembly().Location;
            //Create buttons
            PushButtonData button1 = new PushButtonData("Button1", "Test", path, "EngChallange.ParametersScannerCmd");

            //Create a panel
            RibbonPanel panel1 = application.CreateRibbonPanel("EngChallange", "Retrieve information");

            //Retrieve the path of the icon image
            Uri imagePath = new Uri(Path.Combine(Path.GetDirectoryName(path), "Resources", "Icon.ico"));
            BitmapImage image = new BitmapImage(imagePath);

            //Add the button to the panel
            PushButton pushButton1 = panel1.AddItem(button1) as PushButton;

            //Add image to the button
            pushButton1.LargeImage = image;

            return Result.Succeeded;
        }
    }
}
