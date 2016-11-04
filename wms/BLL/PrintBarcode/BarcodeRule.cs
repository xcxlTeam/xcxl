using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BLL.PrintBarcode
{
    public class BarcodeRule
    {
        private List<string> _fields;

        public List<string> Fields
        {
            get { return _fields; }
            set { _fields = value; }
        }

        public string BuilderBarcode(Object obj)
        {
            string barcode = "";
            Type type = obj.GetType();
            foreach(string str in Fields)
            {
                PropertyInfo propertyInfo = type.GetProperty(str);
                barcode += (string)propertyInfo.GetValue(obj, null) + "@";
            }
            return barcode.Substring(0,barcode.Length -1);//去除最后的@
        }

        public void AnalysisBarcode(string barcode, ref Object obj)
        {
            Type type = obj.GetType();
            string[] array = barcode.Split('@');
            int index = 0;
            foreach (string str in Fields)
            {
                PropertyInfo propertyInfo = type.GetProperty(str);
                propertyInfo.SetValue(obj, array[index], null);
                index++;
            }
        }
    }
}
