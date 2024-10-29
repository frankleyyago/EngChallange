using System.Collections.Generic;
using System.Windows;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace EngChallange
{
    /// <summary>
    /// Interaction logic for UI.xaml
    /// </summary>
    public partial class UI : Window
    {
        //Global variables.
        Document _doc;
        UIDocument _uidoc;

        //Create a new instance of object.
        ParametersScannerCmd parametersScannerCmd = new ParametersScannerCmd();

        public UI(Document doc, UIDocument uidoc)
        {
            InitializeComponent();
            _doc = doc;
            _uidoc = uidoc;
        }

        private void Isolate_Click(object sender, RoutedEventArgs e)
        {
            //Get UI values
            string parameterName = ParamaterNameTextBox.Text.Trim();
            string parameterValue = ParameterValueTextBox.Text.Trim();

            //Set the global variables and call SelectElementsWithParameter
            if (!string.IsNullOrEmpty(parameterName))
            {
                parametersScannerCmd.SetTargetParameterName(parameterName);
                IList<Element> elementsWithParameter = parametersScannerCmd.GetByParameterName(_doc);
                parametersScannerCmd.IsolateSelectedElements(_doc, elementsWithParameter);
            }

            //Set the global variables and call GetByParameterValue
            if (!string.IsNullOrEmpty(parameterValue))
            {
                parametersScannerCmd.SetTargetParameterValue(parameterValue);
                IList<Element> elementsWithParameter = parametersScannerCmd.GetByParameterValue(_doc, _uidoc);
                parametersScannerCmd.IsolateSelectedElements(_doc, elementsWithParameter);
            }

            Close();
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            //Get UI values
            string parameterName = ParamaterNameTextBox.Text.Trim();
            string parameterValue = ParameterValueTextBox.Text.Trim();
                        
            //Set the global variables and call SelectElementsWithParameter
            if (!string.IsNullOrEmpty(parameterName))
            {
                parametersScannerCmd.SetTargetParameterName(parameterName);
                IList<Element> elementsWithParameter = parametersScannerCmd.GetByParameterName(_doc);
                parametersScannerCmd.SelectElementsWithParameter(_doc, _uidoc, elementsWithParameter);
            }

            //Set the global variables and call GetByParameterValue
            if (!string.IsNullOrEmpty(parameterValue))
            {
                parametersScannerCmd.SetTargetParameterValue(parameterValue);
                parametersScannerCmd.GetByParameterValue(_doc, _uidoc);
            }

            Close();
        }

    }
}
