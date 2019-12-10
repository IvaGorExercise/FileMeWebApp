using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Helper
{
    public class ErrorLogHandle
    {
        // Prikaz poruka za greške koje vraća baza
        public static String GetCustomErrorMesage(string originalnaporukacut)
        {
            string userfrendlyporuka = String.Empty;
            int slucaj = 0;


            if (originalnaporukacut.Contains("The INSERT statement conflicted"))
                slucaj = 1;
            else if (originalnaporukacut.Contains("Cannot insert the value NULL"))
                slucaj = 2;
            else if (originalnaporukacut.Contains("The transaction ended in the trigger"))
                slucaj = 3;
            else if (originalnaporukacut.Contains("Object reference not set to an instance of an object"))
                slucaj = 4;
            else if (originalnaporukacut.Contains("The EXECUTE permission"))
                slucaj = 5;
            else if (originalnaporukacut.Contains("Login failed for user"))
                slucaj = 6;
            else if (originalnaporukacut.Contains("The SELECT permission"))
                slucaj = 7;
            else if (originalnaporukacut.Contains("Violation of UNIQUE KEY constraint"))
                slucaj = 8;
            else if (originalnaporukacut.Contains("System.Transactions.TransactionAbortedException: The transaction has aborted."))
                slucaj = 9;
            else if (originalnaporukacut.Contains("System.TimeoutException: Transaction Timeout"))
                slucaj = 10;
            else if (originalnaporukacut.Contains("Invalid object name"))
                slucaj = 11;
            else if (originalnaporukacut.Contains("The DELETE statement conflicted"))
                slucaj = 12;
            if (originalnaporukacut.Contains("The UPDATE statement conflicted"))
                slucaj = 13;
            else if (originalnaporukacut.Contains("The DELETE permission"))
                slucaj = 14;


            switch (slucaj)
            {
                case 1:
                    userfrendlyporuka = ErrorMessage.UserFriendlyMessage.InsertConflict;
                    break;

                case 2:
                    userfrendlyporuka = ErrorMessage.UserFriendlyMessage.InsertNullValue;
                    break;

                case 3:
                    userfrendlyporuka = ErrorMessage.UserFriendlyMessage.TransactionEnded;
                    break;

                case 4:
                    userfrendlyporuka = ErrorMessage.UserFriendlyMessage.ObjectReferenceNotSet;
                    break;

                case 5:
                    userfrendlyporuka = ErrorMessage.UserFriendlyMessage.ExecutePermission;
                    break;

                case 6:
                    userfrendlyporuka = ErrorMessage.UserFriendlyMessage.LoginFailed;
                    break;

                case 7:
                    userfrendlyporuka = ErrorMessage.UserFriendlyMessage.SelectPermission;
                    break;

                case 8:
                    userfrendlyporuka = ErrorMessage.UserFriendlyMessage.UniqueKeyConstraint;
                    break;

                case 9:
                    userfrendlyporuka = ErrorMessage.UserFriendlyMessage.TransactionAbortedException;
                    break;

                case 10:
                    userfrendlyporuka = ErrorMessage.UserFriendlyMessage.TimeoutException;
                    break;

                case 11:
                    userfrendlyporuka = ErrorMessage.UserFriendlyMessage.InvalidObjectName;
                    break;

                case 12:
                    userfrendlyporuka = ErrorMessage.UserFriendlyMessage.DeleteConflicted;
                    break;

                case 13: ;
                    userfrendlyporuka = ErrorMessage.UserFriendlyMessage.UpdateConflicted;
                    break;

                case 14:
                    userfrendlyporuka = ErrorMessage.UserFriendlyMessage.DeletePermission;
                    break;
            }


            return userfrendlyporuka;
        }

   

    }

    public static class ErrorMessage
    {
        public static class UserFriendlyMessage
        {
            public static string InsertConflict = "INSERT statement conflicted";
            public static string InsertNullValue = "Cannot insert the value NULL";
            public static string TransactionEnded = "The transaction ended in the trigger";
            public static string ObjectReferenceNotSet = "Object reference not set to an instance of an object";
            public static string ExecutePermission = "The EXECUTE permission";
            public static string LoginFailed = "Login failed for user";
            public static string SelectPermission = "The SELECT permission";
            public static string UniqueKeyConstraint = "Violation of UNIQUE KEY constraint";
            public static string TransactionAbortedException = "System.Transactions.TransactionAbortedException: The transaction has aborted.";
            public static string TimeoutException = "TimeoutException";
            public static string InvalidObjectName = "Invalid object name";
            public static string DeleteConflicted = "The DELETE statement conflicted";
            public static string UpdateConflicted = "The DELETE statement conflicted";
            public static string DeletePermission = "The DELETE permission";

        }

      
    }
}
