using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.ApplicationServices;

namespace EngChallange
{
    [Transaction(TransactionMode.Manual)]
    public class ParametersScannerCmd : IExternalCommand
    {
        UIApplication _uiapp;
        Application _app;
        UIDocument _uidoc;
        Document _doc;        

        string _targetParameterName = string.Empty;
        string _targetParameterValue = string.Empty;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            _uiapp = commandData.Application;
            _app = _uiapp.Application;
            _uidoc = _uiapp.ActiveUIDocument;
            _doc = _uidoc.Document;

            UI parameterScanner = new UI(_doc, _uidoc);
            parameterScanner.ShowDialog();

            return Result.Succeeded;
        }

        #region GetByParameterName()
        /// <summary>
        /// Retrieve a list of elements that have a specific parameter value.
        /// </summary>
        public IList<Element> GetByParameterName(Document doc)
        {
            FilteredElementCollector c = new FilteredElementCollector(doc, doc.ActiveView.Id)
                .WhereElementIsNotElementType();

            IList<Element> elementsWithParameter = new List<Element>();

            foreach(Element e in c)
            {
                Parameter param = e.LookupParameter(_targetParameterName);

                if (param == null)
                {
                    ElementId typeId = e.GetTypeId();
                    Element typeE = doc.GetElement(typeId);

                    if (typeE != null)
                    {
                        param = typeE.LookupParameter(_targetParameterName);
                    }
                }

                if (param != null)
                {
                    elementsWithParameter.Add(e);
                }
            }

            return elementsWithParameter;
        }
        #endregion

        #region SelectElementsWithParameter()
        public void SelectElementsWithParameter(Document doc, UIDocument uidoc, IList<Element> elementsWithParameter)
        {
            if (elementsWithParameter == null || !elementsWithParameter.Any())
            {
                TaskDialog.Show("None found", $"Any paramater \"{_targetParameterName}\" found. Please try another one!");
                return;
            }

            IList<ElementId> eId = elementsWithParameter.Select(e => e.Id).ToList();

            uidoc.Selection.SetElementIds(eId);
        }
        #endregion

        #region GetByParameterValue()
        /// <summary>
        /// Return all the parameter values  
        /// deemed relevant for the given element
        /// in string form.
        /// </summary>
        public IList<Element> GetByParameterValue(Document doc, UIDocument uidoc)
        {
            FilteredElementCollector c = new FilteredElementCollector(doc, doc.ActiveView.Id)
                .WhereElementIsNotElementType();

            IList<Element> elementsWithParameter = new List<Element>();

            IList<ElementId> elementsWithTargetValue = new List<ElementId>();

            foreach (Element e in c)
            {
                IList<Parameter> ps = e.GetOrderedParameters();

                foreach (Parameter p in ps)
                {
                    if (p.AsValueString() != null && p.AsValueString() == _targetParameterValue)
                    {
                        elementsWithTargetValue.Add(e.Id);
                        elementsWithParameter.Add(e);
                        break;
                    }
                }
            }

            uidoc.Selection.SetElementIds(elementsWithTargetValue);

            return elementsWithParameter;
        }
        #endregion

        #region SetParameterNameAndValue
        /// <summary>
        /// Set global variables
        /// </summary>
        /// <param name="parameterName">Name value</param>
        public void SetTargetParameterName(string parameterName)
        {
            _targetParameterName = parameterName;
        }

        /// <summary>
        /// Set global variables
        /// </summary>
        /// <param name="parameterValue">Parameter value</param>
        public void SetTargetParameterValue(string parameterValue)
        {
            _targetParameterValue = parameterValue;
        }
        #endregion
                
        #region IsolateSelectedElements()
        public void IsolateSelectedElements(Document doc, IList<Element> elements)
        {           

            using (Transaction tx = new Transaction(doc, "Isolate Elements"))
            {
                tx.Start();

                View activeView = doc.ActiveView;

                if (elements == null || !elements.Any())
                {
                    return;
                }

                IList<ElementId> elementIds = elements.Select(e => e.Id).ToList();

                activeView.IsolateElementsTemporary(elementIds);

                tx.Commit();
            }
        }
        #endregion
    }
}
