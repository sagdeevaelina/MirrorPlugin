using Autodesk.Revit.UI;
using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using System.Windows.Media.Imaging;


namespace RevitPlugIn
{
	internal class App : IExternalApplication
	{
		public Result OnShutdown(UIControlledApplication application)
		{
			return Result.Succeeded;
		}

		public Result OnStartup(UIControlledApplication application)
		{
			string tab_name = "Test";
			string panel_name = "General";

			string assembly_path = Assembly.GetExecutingAssembly().Location;
			string assembly_dir = new FileInfo(assembly_path).DirectoryName;
			string image_path = Path.Combine(assembly_dir, @"icon.png");
			application.CreateRibbonTab(tab_name);
			RibbonPanel panel = application.CreateRibbonPanel(tab_name, panel_name);
			PushButtonData item_data = new PushButtonData(
				"MirroredElems",
				"Show mirrored elements",
				assembly_path,
				"RevitPlugIn.MirroredElements"
				);
			BitmapImage icon = new BitmapImage(new Uri(image_path));
			item_data.LargeImage = icon;
			panel.AddItem(item_data);
			return Result.Succeeded;
		}
	}
}
