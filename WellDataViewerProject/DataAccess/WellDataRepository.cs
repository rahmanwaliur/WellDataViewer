using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Xml;
using WellDataViewerProject.Model;

namespace WellDataViewerProject.DataAccess
{
    public class WellDataRepository
    {
        readonly List<WellData> _data;
        
        public WellDataRepository()
        {
            if (_data == null)
            {
                _data = new List<WellData>();
            }
 
        }

        private List<WellData> ReadXMLData()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.CheckFileExists = true;
            dlg.Filter = "XML Files (*.xml)|*.xml|All Files(*.*)|*.*";
            dlg.Multiselect = false;

            

            if (dlg.ShowDialog() != true) { return null; }

            XmlDocument XMLdoc = new XmlDocument();

            try
            {
                XMLdoc.Load(dlg.FileName);
            }
            catch (XmlException)
            {
                MessageBox.Show("The XML file is invalid");
                //return;
            }

            XmlNodeList nodeList = XMLdoc.DocumentElement.SelectNodes("/WellProductionData/WellProduction");

            foreach (XmlNode node in nodeList)
            {
                WellData wellData = new WellData();

                wellData.FilePath = dlg.FileName;
                wellData.RecordDate = node.SelectSingleNode("Date").InnerText;
                wellData.WellName = node.SelectSingleNode("WellName").InnerText;
                //wellData.OilProduced = node.SelectSingleNode("OilProduced").InnerText;
                wellData.OilProduced = Convert.ToInt32(Regex.Match(node.SelectSingleNode("OilProduced").InnerText, @"-?\d+").Value);
                //wellData.GasProduced = node.SelectSingleNode("GasProduced").InnerText;
                wellData.GasProduced = Convert.ToInt32(Regex.Match(node.SelectSingleNode("GasProduced").InnerText, @"-?\d+").Value);
                //wellData.WaterProduced = node.SelectSingleNode("WaterProduced").InnerText;
                wellData.WaterProduced = Convert.ToInt32(Regex.Match(node.SelectSingleNode("WaterProduced").InnerText, @"-?\d+").Value);
                wellData.WellStatus = node.SelectSingleNode("Status").InnerText;

               _data.Add(wellData);

            }
            return _data;
        }

        public List<WellData> GetXMLData()
        {
             List<WellData> _wellData;

            _wellData = ReadXMLData();

            return new List<WellData>(_wellData);
        }

    }
}
