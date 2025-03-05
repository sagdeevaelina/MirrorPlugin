using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RevitPlugIn
{
	[Transaction(TransactionMode.Manual)]
	public class MirroredElements : IExternalCommand
	{
		static AddInId AddInId = new AddInId(new Guid("3A352736-BAD4-47A4-A9EC-BF79963F5AC7"));

		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			UIDocument UIdoc = commandData.Application.ActiveUIDocument;
			Document doc = UIdoc.Document;
			CollectFamilyInstances(doc, UIdoc);
			return Result.Succeeded;
		}

		public void CollectFamilyInstances(Document doc, UIDocument UIdoc)
		{

			FilteredElementCollector collector = new FilteredElementCollector(doc);
			ICollection<Element> familyInstances = collector.OfClass(typeof(FamilyInstance)).ToElements();


			int countMirrored = 0;
			string level_name;
			MirroredElementDto m_dto;
			Element current_level;


			ICollection<ElementId> elementId = new List<ElementId>();
			List<MirroredElementDto> mirrored_elements = new List<MirroredElementDto>();

			foreach (FamilyInstance familyInstance in familyInstances)
			{
				if (familyInstance.Mirrored)
				{
					elementId.Add(familyInstance.Id);
					current_level = doc.GetElement(familyInstance.LevelId);
					if (current_level != null)
					{
						level_name = current_level.Name;
					} 
					else
					{
						level_name = "-";
					}
					m_dto = new MirroredElementDto(++countMirrored, familyInstance.Id, 
						familyInstance.Name, familyInstance.Category.Name, level_name);
					mirrored_elements.Add(m_dto);
				}
			}

			UIdoc.Selection.SetElementIds(elementId);
				
			UI wpfForm = new UI(UIdoc, mirrored_elements);
			wpfForm.ShowDialog();

		}
	}
}
