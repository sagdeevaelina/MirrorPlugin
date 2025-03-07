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
	public class MirroredElementDto
	{
		public string Category { get; }
		public int Id { get; }
		public string Name { get; }
		public string Level { get; }
		public ElementId ElementId { get; }
		public MirroredElementDto(int id, ElementId elementId, string name, string category, string level_name) {
			this.Id = id;
			this.ElementId = elementId;
			this.Name = name;
			this.Level = level_name;
			this.Category = category;
		}
		public override string ToString()
		{
			return $"{Id}) {Category}/{Name} - {Level}";
		}

	}
}
