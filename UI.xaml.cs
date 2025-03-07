using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RevitPlugIn
{
	/// <summary>
	/// Interaction logic for UI.xaml
	/// </summary>
	public partial class UI : Window
	{
		UIDocument UIDoc;
		List<MirroredElementDto> MirroredElements;
		public UI(UIDocument doc, List<MirroredElementDto> mirrored_elements)
		{	
			InitializeComponent();
			UIDoc = doc;
			MirroredElements = mirrored_elements;
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
				mirroredListUI.ItemsSource = MirroredElements;
        }

		private void On_Select(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{

			var selectedItems = mirroredListUI.SelectedItems;
			var selectedIndices = selectedItems.Cast<MirroredElementDto>()
											   .Select(item => mirroredListUI.Items.IndexOf(item))
											   .ToList();

			List<ElementId> elementIds = new List<ElementId>(selectedIndices.Count);

			selectedIndices.ForEach(item => elementIds.Add(MirroredElements[item].ElementId));

			using (Transaction transact = new Transaction(UIDoc.Document))
			{
				transact.Start("Change Selection...");
				UIDoc.Selection.SetElementIds(elementIds);
				transact.Commit();
			}
			
		}
	}
}
