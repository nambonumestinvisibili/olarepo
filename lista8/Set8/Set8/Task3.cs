using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Set8
{

    public class DataAccessHandlerContext
    {
        private DataAccessHandlerStrategy _strategy;

        public DataAccessHandlerContext(DataAccessHandlerStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(DataAccessHandlerStrategy strategy)
        {
            _strategy = strategy;
        }

        public void ExecuteStrategy()
        {
            _strategy.EstablishConnection();
            _strategy.RetrieveData();
            _strategy.ProcessData();
            _strategy.CloseConnection();
        }
    }

    public interface DataAccessHandlerStrategy
    {
        public double Result { get; }
        void EstablishConnection();
        void RetrieveData();
        void ProcessData();
        void CloseConnection();

    }

    public class DatabaseColumnSummer2 : DataAccessHandlerStrategy
    {
        public double Result { get; set; }
        private DatabaseMockupDataProvider _dataProvider;
        private Dictionary<int, List<double>> _data;

        public void CloseConnection()
        {
            if (_dataProvider != null)
            {
                _data = null;
                _dataProvider = null;
            }
        }

        public void EstablishConnection()
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

        public void ProcessData()
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

        public void RetrieveData()
        {
            _data = _dataProvider.GetData();
        }
    }



    public class XmlLongestNodeFinder2 : DataAccessHandlerStrategy
    {
        private XMLMockupDataProvider _dataProvider;
        private XmlDocument _doc;
        public double Result { get; set; }

        public void CloseConnection()
        {
            _dataProvider = null;
        }

        public void EstablishConnection()
        {
            _dataProvider = new XMLMockupDataProvider();
        }

        public void ProcessData()
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

        public void RetrieveData()
        {
            _doc = _dataProvider.GetData();
        }
    }
}
