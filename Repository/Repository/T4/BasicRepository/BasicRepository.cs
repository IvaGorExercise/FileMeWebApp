

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Diagnostics;
using Repository;
using System.Data.Objects;
using Repository.Extension;
using Repository.Helper;
using System.Data;

namespace Repository.Repository.T4
{

	public partial class BasicRepository
	{

 		#region Fields
    	internal FileMeEntities _context;
    	#endregion
    
    	#region Constructor
    	public BasicRepository(FileMeEntities context)
    	{
       	this._context = context;
    	}
   		#endregion


		#region MethodForAll
		public void SaveChanges()
        {
            _context.SaveChanges();
        }
		#endregion
	
	
 		#region ErrorLogRepository

 		public IEnumerable<ErrorLog> GetData(List<Model.Field.ErrorLog> fields, List<Model.Filter.ErrorLog>  filter, List<Model.Sort.ErrorLog>  sort, long? start = null, long? count = null)
        {
           string query = String.Empty;
           query = QueryBuliderHelper.CreateQuery(fields, filter, sort, start, count);
           return _context.Database.SqlQuery<ErrorLog>(query);
        }


		public IEnumerable<ErrorLog> ErrorLogGridData(string filterExpression, string sortingExpression, int startIndex, int count)
		{
		   if (!String.IsNullOrEmpty(filterExpression))
                return _context.ErrorLog
                    .Where(filterExpression)
                    .OrderBy(sortingExpression)
                    .Skip(startIndex)
                    .Take(count);
            else
                return _context.ErrorLog
                    .OrderBy(sortingExpression)
                    .Skip(startIndex)
                    .Take(count);
		}
		
		public int ErrorLogGetCount(string filterExpression) 
		{
			if (!String.IsNullOrEmpty(filterExpression))

                return _context.ErrorLog.Where(filterExpression).Count();

            else
                return _context.ErrorLog.Count();
		}
		
							

	 	public ErrorLog ErrorLogFindByKey(int key)
        {
            return _context.ErrorLog.SingleOrDefault(p => p.ID_ErrorLog == key);
        }

	

		public ErrorLog ErrorLog_Insert(ErrorLog item)
        {
            ErrorLog inserted;
            inserted =_context.ErrorLog.Add(item);
            SaveChanges();
            return inserted;
        }

		public bool ErrorLog_Update(ErrorLog item)
        {
           bool proof = false;
           _context.Entry(item).State = EntityState.Modified;
           SaveChanges();
           proof = true;
           return proof;
        }

		public bool ErrorLog_Delete(int key)
        {
            bool proof = false;
            ErrorLog ob = _context.ErrorLog.Find(key);
           _context.ErrorLog.Remove(ob);
            SaveChanges();
            proof = true;
            return proof;
        }

		public IEnumerable<ErrorLog> ErrorLog_Select()
        {
           return _context.ErrorLog;
        }

		#endregion

	
 		#region PitanjeRepository

 		public IEnumerable<Pitanje> GetData(List<Model.Field.Pitanje> fields, List<Model.Filter.Pitanje>  filter, List<Model.Sort.Pitanje>  sort, long? start = null, long? count = null)
        {
           string query = String.Empty;
           query = QueryBuliderHelper.CreateQuery(fields, filter, sort, start, count);
           return _context.Database.SqlQuery<Pitanje>(query);
        }


		public IEnumerable<Pitanje> PitanjeGridData(string filterExpression, string sortingExpression, int startIndex, int count)
		{
		   if (!String.IsNullOrEmpty(filterExpression))
                return _context.Pitanje
                    .Where(filterExpression)
                    .OrderBy(sortingExpression)
                    .Skip(startIndex)
                    .Take(count);
            else
                return _context.Pitanje
                    .OrderBy(sortingExpression)
                    .Skip(startIndex)
                    .Take(count);
		}
		
		public int PitanjeGetCount(string filterExpression) 
		{
			if (!String.IsNullOrEmpty(filterExpression))

                return _context.Pitanje.Where(filterExpression).Count();

            else
                return _context.Pitanje.Count();
		}
		
																

	 	public Pitanje PitanjeFindByKey(int key)
        {
            return _context.Pitanje.SingleOrDefault(p => p.ID_Pitanje == key);
        }

	

		public Pitanje Pitanje_Insert(Pitanje item)
        {
            Pitanje inserted;
            inserted =_context.Pitanje.Add(item);
            SaveChanges();
            return inserted;
        }

		public bool Pitanje_Update(Pitanje item)
        {
           bool proof = false;
           _context.Entry(item).State = EntityState.Modified;
           SaveChanges();
           proof = true;
           return proof;
        }

		public bool Pitanje_Delete(int key)
        {
            bool proof = false;
            Pitanje ob = _context.Pitanje.Find(key);
           _context.Pitanje.Remove(ob);
            SaveChanges();
            proof = true;
            return proof;
        }

		public IEnumerable<Pitanje> Pitanje_Select()
        {
           return _context.Pitanje;
        }

		#endregion

	
 		#region UserProfileRepository

 		public IEnumerable<UserProfile> GetData(List<Model.Field.UserProfile> fields, List<Model.Filter.UserProfile>  filter, List<Model.Sort.UserProfile>  sort, long? start = null, long? count = null)
        {
           string query = String.Empty;
           query = QueryBuliderHelper.CreateQuery(fields, filter, sort, start, count);
           return _context.Database.SqlQuery<UserProfile>(query);
        }


		public IEnumerable<UserProfile> UserProfileGridData(string filterExpression, string sortingExpression, int startIndex, int count)
		{
		   if (!String.IsNullOrEmpty(filterExpression))
                return _context.UserProfile
                    .Where(filterExpression)
                    .OrderBy(sortingExpression)
                    .Skip(startIndex)
                    .Take(count);
            else
                return _context.UserProfile
                    .OrderBy(sortingExpression)
                    .Skip(startIndex)
                    .Take(count);
		}
		
		public int UserProfileGetCount(string filterExpression) 
		{
			if (!String.IsNullOrEmpty(filterExpression))

                return _context.UserProfile.Where(filterExpression).Count();

            else
                return _context.UserProfile.Count();
		}
		
									

	 	public UserProfile UserProfileFindByKey(int key)
        {
            return _context.UserProfile.SingleOrDefault(p => p.UserId == key);
        }

	

		public UserProfile UserProfile_Insert(UserProfile item)
        {
            UserProfile inserted;
            inserted =_context.UserProfile.Add(item);
            SaveChanges();
            return inserted;
        }

		public bool UserProfile_Update(UserProfile item)
        {
           bool proof = false;
           _context.Entry(item).State = EntityState.Modified;
           SaveChanges();
           proof = true;
           return proof;
        }

		public bool UserProfile_Delete(int key)
        {
            bool proof = false;
            UserProfile ob = _context.UserProfile.Find(key);
           _context.UserProfile.Remove(ob);
            SaveChanges();
            proof = true;
            return proof;
        }

		public IEnumerable<UserProfile> UserProfile_Select()
        {
           return _context.UserProfile;
        }

		#endregion

	
 		#region webpages_MembershipRepository

 		public IEnumerable<webpages_Membership> GetData(List<Model.Field.webpages_Membership> fields, List<Model.Filter.webpages_Membership>  filter, List<Model.Sort.webpages_Membership>  sort, long? start = null, long? count = null)
        {
           string query = String.Empty;
           query = QueryBuliderHelper.CreateQuery(fields, filter, sort, start, count);
           return _context.Database.SqlQuery<webpages_Membership>(query);
        }


		public IEnumerable<webpages_Membership> webpages_MembershipGridData(string filterExpression, string sortingExpression, int startIndex, int count)
		{
		   if (!String.IsNullOrEmpty(filterExpression))
                return _context.webpages_Membership
                    .Where(filterExpression)
                    .OrderBy(sortingExpression)
                    .Skip(startIndex)
                    .Take(count);
            else
                return _context.webpages_Membership
                    .OrderBy(sortingExpression)
                    .Skip(startIndex)
                    .Take(count);
		}
		
		public int webpages_MembershipGetCount(string filterExpression) 
		{
			if (!String.IsNullOrEmpty(filterExpression))

                return _context.webpages_Membership.Where(filterExpression).Count();

            else
                return _context.webpages_Membership.Count();
		}
		
														

	 	public webpages_Membership webpages_MembershipFindByKey(int key)
        {
            return _context.webpages_Membership.SingleOrDefault(p => p.UserId == key);
        }

	

		public webpages_Membership webpages_Membership_Insert(webpages_Membership item)
        {
            webpages_Membership inserted;
            inserted =_context.webpages_Membership.Add(item);
            SaveChanges();
            return inserted;
        }

		public bool webpages_Membership_Update(webpages_Membership item)
        {
           bool proof = false;
           _context.Entry(item).State = EntityState.Modified;
           SaveChanges();
           proof = true;
           return proof;
        }

		public bool webpages_Membership_Delete(int key)
        {
            bool proof = false;
            webpages_Membership ob = _context.webpages_Membership.Find(key);
           _context.webpages_Membership.Remove(ob);
            SaveChanges();
            proof = true;
            return proof;
        }

		public IEnumerable<webpages_Membership> webpages_Membership_Select()
        {
           return _context.webpages_Membership;
        }

		#endregion

	
 		#region webpages_RolesRepository

 		public IEnumerable<webpages_Roles> GetData(List<Model.Field.webpages_Roles> fields, List<Model.Filter.webpages_Roles>  filter, List<Model.Sort.webpages_Roles>  sort, long? start = null, long? count = null)
        {
           string query = String.Empty;
           query = QueryBuliderHelper.CreateQuery(fields, filter, sort, start, count);
           return _context.Database.SqlQuery<webpages_Roles>(query);
        }


		public IEnumerable<webpages_Roles> webpages_RolesGridData(string filterExpression, string sortingExpression, int startIndex, int count)
		{
		   if (!String.IsNullOrEmpty(filterExpression))
                return _context.webpages_Roles
                    .Where(filterExpression)
                    .OrderBy(sortingExpression)
                    .Skip(startIndex)
                    .Take(count);
            else
                return _context.webpages_Roles
                    .OrderBy(sortingExpression)
                    .Skip(startIndex)
                    .Take(count);
		}
		
		public int webpages_RolesGetCount(string filterExpression) 
		{
			if (!String.IsNullOrEmpty(filterExpression))

                return _context.webpages_Roles.Where(filterExpression).Count();

            else
                return _context.webpages_Roles.Count();
		}
		
					

	 	public webpages_Roles webpages_RolesFindByKey(int key)
        {
            return _context.webpages_Roles.SingleOrDefault(p => p.RoleId == key);
        }

	

		public webpages_Roles webpages_Roles_Insert(webpages_Roles item)
        {
            webpages_Roles inserted;
            inserted =_context.webpages_Roles.Add(item);
            SaveChanges();
            return inserted;
        }

		public bool webpages_Roles_Update(webpages_Roles item)
        {
           bool proof = false;
           _context.Entry(item).State = EntityState.Modified;
           SaveChanges();
           proof = true;
           return proof;
        }

		public bool webpages_Roles_Delete(int key)
        {
            bool proof = false;
            webpages_Roles ob = _context.webpages_Roles.Find(key);
           _context.webpages_Roles.Remove(ob);
            SaveChanges();
            proof = true;
            return proof;
        }

		public IEnumerable<webpages_Roles> webpages_Roles_Select()
        {
           return _context.webpages_Roles;
        }

		#endregion


	}
}





