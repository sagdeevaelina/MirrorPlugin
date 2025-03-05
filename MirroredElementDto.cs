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
		private int _id;
		private ElementId _elementId;
		private string _name;
		private string _level_name;
		private string _category;
		public string Category { get { return _category; } }
		public int Id {  get { return _id; } }
		public string Name { get { return _name; } }
		public string Level { get { return _level_name; } }
		public ElementId ElementId { get { return _elementId; } }
		public MirroredElementDto(int id, ElementId elementId, string name, string category, string level_name) {
			this._id = id;
			this._elementId = elementId;
			this._name = name;
			this._level_name = level_name;
			this._category = category;
		}
		public override string ToString()
		{
			return $"{Id}) {Category}/{Name} - {Level}";
		}

	}
}
