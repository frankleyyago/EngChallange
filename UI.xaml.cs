using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace EngChallange
{
    /// <summary>
    /// Interaction logic for UI.xaml
    /// </summary>
    public partial class UI : Window
    {
        Document _doc;
        UIDocument _uidoc;

        ParametersScannerCmd parametersScannerCmd = new ParametersScannerCmd();

        public UI(Document doc, UIDocument uidoc)
        {
            InitializeComponent();
            _doc = doc;
            _uidoc = uidoc;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Isolate_Click(object sender, RoutedEventArgs e)
        {
            // Obtém os valores dos campos de texto
            string parameterName = ParamaterNameTextBox.Text.Trim();
            string parameterValue = ParameterValueTextBox.Text.Trim();

            // Verifica se o campo de nome do parâmetro foi preenchido
            if (!string.IsNullOrEmpty(parameterName))
            {
                parametersScannerCmd.SetTargetParameterName(parameterName);
                IList<Element> elementsWithParameter = parametersScannerCmd.GetByParameterName(_doc);
                parametersScannerCmd.IsolateSelectedElements(_doc, elementsWithParameter);
            }

            // Verifica se o campo de valor do parâmetro foi preenchido
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
            // Obtém os valores dos campos de texto
            string parameterName = ParamaterNameTextBox.Text.Trim();
            string parameterValue = ParameterValueTextBox.Text.Trim();
                        
            // Verifica se o campo de nome do parâmetro foi preenchido
            if (!string.IsNullOrEmpty(parameterName))
            {
                parametersScannerCmd.SetTargetParameterName(parameterName);
                IList<Element> elementsWithParameter = parametersScannerCmd.GetByParameterName(_doc);
                parametersScannerCmd.SelectElementsWithParameter(_doc, _uidoc, elementsWithParameter);
            }

            // Verifica se o campo de valor do parâmetro foi preenchido
            if (!string.IsNullOrEmpty(parameterValue))
            {
                parametersScannerCmd.SetTargetParameterValue(parameterValue);
                parametersScannerCmd.GetByParameterValue(_doc, _uidoc);
            }

            Close();
        }


    }
}
