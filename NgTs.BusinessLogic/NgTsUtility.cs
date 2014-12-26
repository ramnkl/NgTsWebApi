using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgTs.BusinessLogic
{
    public class NgTsUtility
    {

        #region Static Public members

        public static string GetDelimitedString(List<long> lstLongs)
        {
            StringBuilder sbText = new StringBuilder();

            foreach (long value in lstLongs)
            {
                sbText.Append(value.ToString());
                sbText.Append(",");
            }

            return sbText.ToString();
        }

        #region Date helpers

        public static DateTime GetLesser(DateTime left, DateTime right)
        {
            if (left < right)
            {
                return left;
            }

            return right;
        }

        public static DateTime GetGreatest(DateTime left, DateTime right)
        {
            if (left > right)
            {
                return left;
            }

            return right;
        }

        public static bool IsInRange(DateTime left, DateTime right, DateTime date)
        {
            return (date >= left && date <= right);
        }

        public static bool IsInRange(DateTime left1, DateTime right1, DateTime left2, DateTime right2)
        {
            return
                (
                    IsInRange(left1, right1, left2) ||
                    IsInRange(left1, right1, right2) ||
                    IsInRange(left2, right2, left1) ||
                    IsInRange(left2, right2, right1)
                );
        }

        public static string GetElidedString(string text, int maxLength)
        {
            if (true == string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            if (text.Length > maxLength)
            {
                return text.Substring(0, maxLength).TrimEnd() + "...";
            }

            return text;
        }

        #endregion

        static public T GetObject<T>(ref T value)
            where T : new()
        {
            if (null == value)
            {
                value = new T();
            }

            return value;
        }

        static public T GetObject<T>(ref T value, string scope) //Have to change the argument properly to transactionscope.
            where T : new()
        {
            if (null == value)
            {
                if (scope == null)
                {
                    value = new T();
                }
                else    //Needed for Indexing
                {
                    object[] args = new object[1];
                    args[0] = scope;
                    value = (T)Activator.CreateInstance(typeof(T), args);
                }

            }

            return value;
        }








        #region Build Information Properties

        static private Version _FileVersion = null;


        static private Version _ProductVersion = null;
        //static public Version ProductVersion
        //{
        //    get
        //    {
        //        if (_ProductVersion == null)
        //        {
        //            AssemblyInformationalVersionAttribute assemblyVersion = Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyInformationalVersionAttribute)) as AssemblyInformationalVersionAttribute;
        //            if (assemblyVersion != null)
        //            {
        //                _ProductVersion = new Version(assemblyVersion.InformationalVersion);
        //            }
        //            if (_ProductVersion == null)
        //            {
        //                _ProductVersion = new Version(1, 0, 0, 0);
        //            }
        //        }
        //        return _ProductVersion;
        //    }
        //}

        static private Version _AssemblyVersion = null;
        //static public Version AssemblyVersion
        //{
        //    get
        //    {
        //        if (_AssemblyVersion == null)
        //        {
        //            AssemblyVersionAttribute assemblyVersion = Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyVersionAttribute)) as AssemblyVersionAttribute;
        //            if (assemblyVersion != null)
        //            {
        //                _AssemblyVersion = new Version(assemblyVersion.Version);
        //            }
        //            if (_AssemblyVersion == null)
        //            {
        //                _AssemblyVersion = new Version(1, 0, 0, 0);
        //            }
        //        }
        //        return _AssemblyVersion;
        //    }
        //}

        //static private string _BuildNumber = null;
        //static public string BuildNumber
        //{
        //    get
        //    {
        //        if (_BuildNumber == null)
        //        {
        //            AssemblyTitleAttribute asmTitle = Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(),
        //                                typeof(AssemblyTitleAttribute)) as AssemblyTitleAttribute;
        //            if (asmTitle != null)
        //            {
        //                _BuildNumber = asmTitle.Title;
        //            }

        //            if (_BuildNumber == null)
        //            {
        //                _BuildNumber = string.Empty;
        //            }
        //        }

        //        return _BuildNumber;
        //    }
        //}

        //static private string _BuildDescription = null;
        //static public string BuildDescription
        //{
        //    get
        //    {
        //        if (_BuildDescription == null)
        //        {
        //            AssemblyDescriptionAttribute asmDescription = Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(),
        //                                typeof(AssemblyDescriptionAttribute)) as AssemblyDescriptionAttribute;
        //            if (asmDescription != null)
        //            {
        //                _BuildDescription = asmDescription.Description;
        //            }

        //            if (_BuildDescription == null)
        //            {
        //                _BuildDescription = string.Empty;
        //            }
        //        }

        //        return _BuildDescription;
        //    }
        //}

        //static private string _ProductName = null;
        //static public string ProductName
        //{
        //    get
        //    {
        //        if (_ProductName == null)
        //        {
        //            AssemblyProductAttribute asmProduct = Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(),
        //                            typeof(AssemblyProductAttribute)) as AssemblyProductAttribute;
        //            if (asmProduct != null)
        //            {
        //                _ProductName = asmProduct.Product;
        //            }
        //            if (_ProductName == null)
        //            {
        //                _ProductName = string.Empty;
        //            }
        //        }
        //        return _ProductName;
        //    }
        //}

        //static public string Location
        //{
        //    get
        //    {
        //        return System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        //    }
        //}

        #endregion

        #endregion



        #region Variables

        public static int CoppaAge = 10;

        #endregion
    }
}
