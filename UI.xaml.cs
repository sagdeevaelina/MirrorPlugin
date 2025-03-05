using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Collections.Generic;
using System.Windows;

namespace RevitPlugIn
{
	/// <summary>
	/// Interaction logic for UI.xaml
	/// </summary>
	public partial class UI : Window
	{
		UIDocument UIDoc;
		List<MirroredElementDto> Result;
		public UI(UIDocument doc, List<MirroredElementDto> mirrored_elements)
		{	
			InitializeComponent();
			UIDoc = doc;
			Result = mirrored_elements;
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
				mirroredList.ItemsSource = Result;
        }

		private void On_Select(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			ElementId elementId = Result[mirroredList.SelectedIndex].ElementId;
			using (Transaction transact = new Transaction(UIDoc.Document))
			{
				transact.Start("Change Selection...");
				UIDoc.Selection.SetElementIds(new List<ElementId> { elementId });
				transact.Commit();
			}
			
		}
	}
}
