using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.ERelationalOperator;
using System.Threading.Tasks;

namespace Repository.Helper
{
    public static class QueryBuliderHelper
    {

        public static string CreateQuery(dynamic fields, dynamic filter, dynamic sort, long? start = null, long? count = null)
        {
            string query = String.Empty;
            StringBuilder querybilder = new StringBuilder();
            StringBuilder qbSelect = new StringBuilder();
            StringBuilder qbWhere = new StringBuilder();
            StringBuilder qbOrderBy = new StringBuilder();
            string selectString = String.Empty;
            string fromString = String.Empty;
            string filterString = String.Empty;
            string sortString = String.Empty;
            string listafinal = String.Empty;
            string offset = String.Empty;
            string fetch = String.Empty;
            string serverversion = "11";
            var listbasic = Activator.CreateInstance(typeof(List<>).MakeGenericType(fields.GetType().GetGenericArguments()[0]));
            var listfinal = Activator.CreateInstance(typeof(List<>).MakeGenericType(fields.GetType().GetGenericArguments()[0]));

            serverversion = CommonFunctions.GetServerVersion();


            Type enumType = fields.GetType().GetGenericArguments()[0];

            foreach (dynamic polje in Enum.GetValues(enumType))
            {

                listbasic.Add((dynamic)polje);
            }

            listfinal = Enumerable.Except(listbasic, fields);



            // SELECT DIO
            if (Enumerable.Any(fields))
            {
                foreach (var polje in fields)
                {
                    qbSelect.Append(polje.ToString() + ", ");
                    qbSelect.Append(System.Environment.NewLine);
                }

                foreach (var polje in listfinal)
                {
                    qbSelect.Append(" NULL AS " + polje.ToString() + ", ");

                    if (polje == Enumerable.Last(listfinal))
                    {
                        qbSelect.Remove(qbSelect.ToString().Length - 2, 2);
                    }

                    qbSelect.Append(System.Environment.NewLine);


                }
            }

            else
            {
                foreach (var polje in listbasic)
                {
                    qbSelect.Append(polje.ToString() + ", ");

                    if (polje == Enumerable.Last(listbasic))
                    {
                        qbSelect.Remove(qbSelect.ToString().Length - 2, 2);
                    }

                    qbSelect.Append(System.Environment.NewLine);
                }

            }

            selectString = qbSelect.ToString();


            // FROM DIO
            fromString = filter.GetType().ToString();
            int zadnjatocka = fromString.LastIndexOf(".");
            fromString = fromString.Substring(zadnjatocka + 1, (fromString.Length - 2) - zadnjatocka);



            // WHERE DIO
            if (Enumerable.Any(filter))
            {
                string filterstring = String.Empty;
                bool stringtype = false;
                dynamic stringvalue = string.Empty;


                foreach (var polje in filter)
                {

                    stringtype = polje.Tip;

                    if (polje.Operator == null)
                        filterstring = GetOperator(ERelationalOperator.Equal);
                    else
                        filterstring = GetOperator(polje.Operator);


                    if (stringtype == true)
                        stringvalue = "'" + polje.Value + "'";
                    else
                        stringvalue = polje.Value;

                    qbWhere.Append(polje.Field.ToString() + filterstring + stringvalue + " AND ");

                    if (polje == Enumerable.Last(filter))
                    {
                        qbWhere.Remove(qbWhere.ToString().Length - 5, 5);
                    }

                    qbWhere.Append(System.Environment.NewLine);
                }


                filterString = qbWhere.ToString();

            }


            // ORDER BY DIO
            if (Enumerable.Any(sort))
            {
                foreach (var polje in sort)
                {
                    if (polje.Descending == false)
                        qbOrderBy.Append(polje.Field + ", ");
                    else
                        qbOrderBy.Append(polje.Field + " ASC, ");

                }

                sortString = qbOrderBy.ToString();
                sortString = sortString.Remove(sortString.Length - 2);
            }

            // PAGING DIO
            if (count > 1 || start > 0)
            {


                switch (serverversion)
                {
                    case "11":
                        offset = ((Convert.ToInt64(start) - 1) * Convert.ToInt64(count)).ToString();
                        fetch = Convert.ToInt64(count).ToString();
                        break;

                    case "10":
                        offset = ((Convert.ToInt64(start) - 1) * Convert.ToInt64(count) + 1).ToString();
                        fetch = (Convert.ToInt64(start) * Convert.ToInt64(count)).ToString();
                        break;
                }

            }


            // QUERY BUILDER DIO
            switch (serverversion)
            {
                case "11":
                    querybilder.Append("SELECT ");
                    querybilder.Append(System.Environment.NewLine);
                    querybilder.Append(selectString);
                    querybilder.Append(System.Environment.NewLine);
                    querybilder.Append(" FROM ");
                    querybilder.Append(System.Environment.NewLine);
                    querybilder.Append(fromString);
                    querybilder.Append(System.Environment.NewLine);

                    if (!String.IsNullOrEmpty(filterString))
                    {
                        querybilder.Append(System.Environment.NewLine);
                        querybilder.Append(" WHERE ");
                        querybilder.Append(System.Environment.NewLine);
                        querybilder.Append(filterString);
                        querybilder.Append(System.Environment.NewLine);
                    }


                    if (!String.IsNullOrEmpty(sortString))
                    {
                        querybilder.Append(" ORDER BY ");
                        querybilder.Append(System.Environment.NewLine);
                        querybilder.Append(sortString);
                        querybilder.Append(System.Environment.NewLine);
                    }

                    else
                    {
                        querybilder.Append(" ORDER BY ");
                        querybilder.Append(System.Environment.NewLine);
                        querybilder.Append(Enumerable.ElementAt(listbasic, 0) + " DESC ");
                        querybilder.Append(System.Environment.NewLine);
                    }


                    if (!String.IsNullOrEmpty(offset) && !String.IsNullOrEmpty(fetch))
                    {
                        querybilder.Append(System.Environment.NewLine);
                        querybilder.Append(" OFFSET ");
                        querybilder.Append(System.Environment.NewLine);
                        querybilder.Append(offset + " ROWS " + " FETCH NEXT " + fetch + " ROWS ONLY ");
                    }

                    break;



                case "10":
                    querybilder.Append("SELECT * FROM");
                    querybilder.Append(System.Environment.NewLine);
                    querybilder.Append(" (SELECT ROW_NUMBER() over (ORDER BY ");

                    if (!String.IsNullOrEmpty(sortString))
                    {
                        querybilder.Append(sortString);
                    }

                    else
                    {
                        querybilder.Append(Enumerable.ElementAt(listbasic, 0));
                    }


                    querybilder.Append(") AS RowID, ");
                    querybilder.Append(System.Environment.NewLine);
                    querybilder.Append(selectString);
                    querybilder.Append(System.Environment.NewLine);
                    querybilder.Append(" FROM ");
                    querybilder.Append(System.Environment.NewLine);
                    querybilder.Append(fromString);
                    querybilder.Append(System.Environment.NewLine);


                    if (!String.IsNullOrEmpty(filterString))
                    {
                        querybilder.Append(System.Environment.NewLine);
                        querybilder.Append(" WHERE ");
                        querybilder.Append(System.Environment.NewLine);
                        querybilder.Append(filterString + ") sve ");
                        querybilder.Append(System.Environment.NewLine);
                    }

                    else
                    {
                        querybilder.Append(System.Environment.NewLine);
                        querybilder.Append(") sve ");
                        querybilder.Append(System.Environment.NewLine);
                    }



                    if (!String.IsNullOrEmpty(offset) && !String.IsNullOrEmpty(fetch))
                    {
                        querybilder.Append(System.Environment.NewLine);
                        querybilder.Append(" WHERE RowID BETWEEN " + offset + " AND " + fetch);
                        querybilder.Append(System.Environment.NewLine);
                    }


                    if (!String.IsNullOrEmpty(sortString))
                    {
                        querybilder.Append(System.Environment.NewLine);
                        querybilder.Append(" ORDER BY ");
                        querybilder.Append(System.Environment.NewLine);
                        querybilder.Append(sortString);
                    }



                    break;
            }


            query = querybilder.ToString();

            return query;
        }

        public static string GetOperator(ERelationalOperator op)
        {
            string operatorString = op.ToString().Trim();

            switch (op)
            {
                case ERelationalOperator.Equal: operatorString = " = "; break;
                case ERelationalOperator.NotEqual: operatorString = " != "; break;
                case ERelationalOperator.Greater: operatorString = " > "; break;
                case ERelationalOperator.Less: operatorString = " < "; break;
                case ERelationalOperator.GreaterEqual: operatorString = " >= "; break;
                case ERelationalOperator.LessEqual: operatorString = " <= "; break;
                case ERelationalOperator.Like: operatorString = " LIKE "; break;
                case ERelationalOperator.NotLike: operatorString = " NOT LIKE "; break;
            }

            return operatorString;

        }

    }
}
