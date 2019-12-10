using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public static class T4
    {
        public static bool IsTable(string entityName)
        {
            bool result = true;

            if (entityName.Length > 5)
            {
                if (entityName.Substring(0, 5).ToUpper().Equals("VIEW_"))
                {
                    result = false;
                }
            }

            if (entityName.Length > 4)
            {
                if (entityName.Substring(0, 4).ToUpper().Equals("USP_"))
                {
                    result = false;
                }
            }

            if (entityName.Length > 4)
            {
                if (entityName.Substring(0, 4).ToUpper().Equals("FNS_"))
                {
                    result = false;
                }
            }

            return result;
        }

        public static bool IsView(string entityName)
        {
            bool result = false;

            if (entityName.Length > 5)
            {
                if (entityName.Substring(0, 5).ToUpper().Equals("VIEW_"))
                {
                    result = true;
                }
            }

            return result;
        }

        public static bool IsProcedure(string entityName)
        {
            bool result = false;

            if (entityName.Length > 4)
            {
                if (entityName.Substring(0, 4).ToUpper().Equals("USP_"))
                {
                    result = true;
                }
            }

            return result;
        }

        public static bool IsFunction(string entityName)
        {
            bool result = false;

            if (entityName.Length > 4)
            {
                if (entityName.Substring(0, 4).ToUpper().Equals("FNS_"))
                {
                    result = true;
                }
            }

            return result;
        }

        public static string ClassName(string entityName)
        {
            string name = entityName;

            if (entityName.Length > 5)
            {
                if (entityName.Substring(0, 5).ToUpper().Equals("VIEW_"))
                {
                    name = entityName.Substring(5);
                }
            }

            if (entityName.Length > 4)
            {
                if (entityName.Substring(0, 4).ToUpper().Equals("USP_"))
                {
                    name = entityName.Substring(4);
                }
            }

            if (entityName.Length > 4)
            {
                if (entityName.Substring(0, 4).ToUpper().Equals("FNS_"))
                {
                    name = entityName.Substring(4);
                }
            }

            return name;
        }

        public static string ClassNameFull(string entityName)
        {
            string name = entityName;

            if (entityName.Length > 5)
            {
                if (entityName.Substring(0, 5).ToUpper().Equals("VIEW_"))
                {
                    name = "View." + entityName.Substring(5);
                }
            }

            if (entityName.Length > 4)
            {
                if (entityName.Substring(0, 4).ToUpper().Equals("USP_"))
                {
                    name = "Procedure." + entityName.Substring(4);
                }
            }

            if (entityName.Length > 4)
            {
                if (entityName.Substring(0, 4).ToUpper().Equals("FNS_"))
                {
                    name = "Function." + entityName.Substring(4);
                }
            }

            return name;
        }

        public static string InterfaceName(string entityName)
        {
            string name = entityName;

            if (entityName.Length > 5)
            {
                if (entityName.Substring(0, 5).ToUpper().Equals("VIEW_"))
                {
                    name = entityName.Substring(5);
                }
            }

            if (entityName.Length > 4)
            {
                if (entityName.Substring(0, 4).ToUpper().Equals("USP_"))
                {
                    name = entityName.Substring(4);
                }
            }

            if (entityName.Length > 4)
            {
                if (entityName.Substring(0, 4).ToUpper().Equals("FNS_"))
                {
                    name = entityName.Substring(4);
                }
            }

            name = "I" + name;

            return name;
        }

        public static string InterfaceNameFull(string entityName)
        {
            string name = entityName;
            bool done = false;

            if (entityName.Length > 5)
            {
                if (entityName.Substring(0, 5).ToUpper().Equals("VIEW_"))
                {
                    name = "View.I" + entityName.Substring(5);
                    done = true;
                }
            }

            if (entityName.Length > 4)
            {
                if (entityName.Substring(0, 4).ToUpper().Equals("USP_"))
                {
                    name = "Procedure.I" + entityName.Substring(4);
                    done = true;
                }
            }

            if (entityName.Length > 4)
            {
                if (entityName.Substring(0, 4).ToUpper().Equals("FNS_"))
                {
                    name = "Function.I" + entityName.Substring(4);
                    done = true;
                }
            }

            if (!done) name = "I" + name;

            return name;
        }

        public static string NameSpace(string entityName, string nameSpace = "")
        {
            string name = "";

            if (entityName.Length > 5)
            {
                if (entityName.Substring(0, 5).ToUpper().Equals("VIEW_"))
                {
                    name = "View";
                }
            }

            if (entityName.Length > 4)
            {
                if (entityName.Substring(0, 4).ToUpper().Equals("USP_"))
                {
                    name = "Procedure";
                }
            }

            if (entityName.Length > 4)
            {
                if (entityName.Substring(0, 4).ToUpper().Equals("FNS_"))
                {
                    name = "Function";
                }
            }

            if (nameSpace != null)
            {
                if (nameSpace.Length > 0)
                {
                    if (name.Length > 0)
                    {
                        name = nameSpace + "." + name;
                    }
                    else
                    {
                        name = nameSpace;
                    }
                }
            }

            return name;
        }

        public static string CleanType(string type, bool nullabletype = false)
        {
            type = type.Trim();

            bool nullable = (type.StartsWith("Nullable<") && type.EndsWith(">")) || (!type.StartsWith("Nullable<") && type.EndsWith("?"));

            if (nullable)
            {
                type = type.Replace("Nullable<", "");
                type = type.Remove(type.Length - 1);
            }

            switch (type)
            {
                case "Boolean": type = "bool"; break;
                case "Byte": type = "byte"; break;
                case "Int16": type = "short"; break;
                case "Int32": type = "int"; break;
                case "Int64": type = "long"; break;
                case "Decimal": type = "decimal"; break;
                case "Single": type = "single"; break;
                case "Double": type = "double"; break;
                case "String": type = "string"; break;
                case "System.Byte": type = "byte"; break;
                case "System.Int16": type = "short"; break;
                case "System.Int32": type = "int"; break;
                case "System.Int64": type = "long"; break;
                case "System.Decimal": type = "decimal"; break;
                case "System.Single": type = "single"; break;
                case "System.Double": type = "double"; break;
                case "System.String": type = "string"; break;
                case "System.DateTime": type = "DateTime"; break;
                case "System.DateTimeOffset": type = "DateTimeOffset"; break;
                case "System.TimeSpan": type = "TimeSpan"; break;
                case "System.Guid": type = "Guid"; break;
            }

            if ((nullable) || (!nullable && nullabletype && type != "string"))
            {
                if (type.EndsWith("[]"))
                {
                    //type = type.Substring(0,type.Length-2) + "?[]";
                }
                else
                {
                    type = type + "?";
                }
            }

            return type;
        }

        public static bool BasicType(string type)
        {
            type = type.Trim();

            bool nullable = (type.StartsWith("Nullable<") && type.EndsWith(">")) || (!type.StartsWith("Nullable<") && type.EndsWith("?"));

            if (nullable)
            {
                type = type.Replace("Nullable<", "");
                type = type.Remove(type.Length - 1);
            }

            switch (type)
            {
                case "bool":
                case "byte":
                case "short":
                case "int":
                case "long":
                case "decimal":
                case "single":
                case "double":
                case "string":
                case "Boolean":
                case "Byte":
                case "Int16":
                case "Int32":
                case "Int64":
                case "Decimal":
                case "Single":
                case "Double":
                case "String":
                case "DateTime":
                case "DateTimeOffset":
                case "TimeSpan":
                case "Guid":
                case "System.Byte":
                case "System.Int16":
                case "System.Int32":
                case "System.Int64":
                case "System.Decimal":
                case "System.Single":
                case "System.Double":
                case "System.String":
                case "System.DateTime":
                case "System.DateTimeOffset":
                case "System.TimeSpan":
                case "System.Guid":
                    return true;
                default:
                    return false;
            }
        }

        public static string ToParamName(string name)
        {
            string n = "";

            if (name.StartsWith("ID"))
            {
                if (name.Length > 2)
                {
                    n = "id" + name.Substring(2);
                }
                else
                {
                    n = "id";
                }
            }
            else
            {
                n = name.Substring(0, 1).ToLower() + name.Substring(1);
            }

            return n;
        }
    }
}
