using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Set8
{
    public abstract class DataAccessHandler
    {
        public void Execute()
        {
            EstablishConnection();
            RetrieveData();
            ProcessData();
            CloseConnection();
        }
        public abstract void EstablishConnection();
        public abstract void RetrieveData();
        public abstract void ProcessData();
        public abstract void CloseConnection();
    }

    public class DatabaseColumnSummer : DataAccessHandler
    {
        public double Result { get; set; }
        private DatabaseMockupDataProvider _dataProvider;
        private Dictionary<int, List<double>> _data;

        public override void CloseConnection()
        {
            if (_dataProvider != null)
            {
                _data = null;
                _dataProvider = null;
            }
        }

        public override void EstablishConnection()
        {
            if (_dataProvider != null)
            {
                CloseConnection();
            }
            else
            {
                _dataProvider = new DatabaseMockupDataProvider();
                
            }
        }

        public override void ProcessData()
        {
            Random random = new Random();
            var length = _data[0].Count;
            var columnNo = random.Next(length);
            double sum = 0;
            for (int i = 0; i < _data.Count; i++)
            {
                sum += _data[i][columnNo];
            }
            Result = sum;
        }

        public override void RetrieveData()
        {
            _data = _dataProvider.GetData();
        }
    }

    public class DatabaseMockupDataProvider 
    {
        public DatabaseMockupDataProvider()
        {
        }

        public Dictionary<int, List<double>> GetData()
        {
            var mockdata = new Dictionary<int, List<double>>();
            mockdata.Add(0, new List<double> { 1, 2, 3, 4, 5 });
            mockdata.Add(1, new List<double> { 3, 4, 5, 6, 7 });
            mockdata.Add(2, new List<double> { 1, 2, 3, 4, 5 });
            mockdata.Add(3, new List<double> { 1, 2, 3, 4, 5 });
            mockdata.Add(4, new List<double> { 1, 2, 3, 4, 5 });
            return mockdata;
        }
    }

    public class XMLMockupDataProvider
    {
        public XMLMockupDataProvider()
        {
        }

        public XmlDocument GetData()
        {
            var doc = new XmlDocument();
            doc.LoadXml("<?xml version=\"1.0\"?> \n" +
                "<a>" +
                "   <b>bbb</b>" +
                "   <c>ccccc</c>" +
                "   <d>" +
                "       <e>fffffffffffffffffffffffff</e>" +
                "   </d>" +
                "</a>");
            return doc;
        }
    }

    public class XmlLongestNodeFinder : DataAccessHandler
    {
        private XMLMockupDataProvider _dataProvider;
        private XmlDocument _doc;
        public int Result { get; set; }
        public XmlLongestNodeFinder()
        {
        }

        public override void CloseConnection()
        {
            _dataProvider = null;
        }

        public override void EstablishConnection()
        {
            _dataProvider = new XMLMockupDataProvider();
        }

        public override void ProcessData()
        {
            Result = LongestName(_doc.FirstChild);
        }

        private int LongestName(XmlNode node)
        {
            int longest = node.Name.Length;

            foreach (var child in node.ChildNodes)
            {
                longest = Math.Max(longest, LongestName((XmlNode)child));
            }


            if (node.NextSibling != null)
            {
                longest = Math.Max(longest, LongestName(node.NextSibling));
            }

            return longest;
        }

        public override void RetrieveData()
        {
            _doc = _dataProvider.GetData();
        }
    }


}
