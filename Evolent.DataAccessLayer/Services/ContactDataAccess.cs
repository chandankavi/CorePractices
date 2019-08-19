using Evolent.DataAccessLayer.Helpers;
using Evolent.Models.ContactModel;
using Evolent.Models.DBModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Evolent.DataAccessLayer.Services
{
    public class ContactDataAccess :DbContext
    {
        private readonly ObjectContext _context = null;
        private DbContextOptions<ContactDataAccess> options;

        public DbSet<Contact> Contact { get; set; }

        //public ContactDataAccess(IOptions<Settings> settings, IConfiguration configuration)
        //{
        //    _context = new ObjectContext(settings, configuration);
        //}

        public ContactDataAccess(DbContextOptions<ContactDataAccess> options):base(options)
        {
            this.options = options;
        }

        //public async Task<bool> AddContact(Contact contact)
        //{
        //    using (_context._connection)
        //    {
        //        try
        //        {
        //            SqlCommand cmd = new SqlCommand("sp_AddUpdateEvolentContact", _context._connection);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            GetCommandParameters(contact, cmd);
        //            _context._connection.Open();

        //            if (await cmd.ExecuteNonQueryAsync() < 1)
        //            {
        //                return false;
        //            }
        //            else
        //            {
        //                return true;
        //            }
                    
        //        }
        //        catch (Exception e)
        //        {
        //            throw e;
        //        }
        //        finally
        //        {
        //            _context._connection.Close();
        //        }
        //    }
        //}

        //public async Task<bool> DeleteContact(Contact contact)
        //{
        //    using (_context._connection)
        //    {
        //        try
        //        {
        //            SqlCommand cmd = new SqlCommand("sp_InactiveEvolentContact", _context._connection);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@Id",contact.Id);
        //            _context._connection.Open();

        //            if (await cmd.ExecuteNonQueryAsync() < 1)
        //            {
        //                return false;
        //            }
        //            else
        //            {
        //                return true;
        //            }

        //        }
        //        catch (Exception e)
        //        {
        //            throw e;
        //        }
        //        finally
        //        {
        //            _context._connection.Close();
        //        }
        //    }
        //}

        //public async Task<Contact> GetContact()
        //{
        //    using (_context._connection)
        //    {
        //        try
        //        {
        //            SqlCommand cmd = new SqlCommand("sp_GetAllContacts", _context._connection);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            _context._connection.Open();
        //            DataTable dt = new DataTable();
        //            dt.Load(await cmd.ExecuteReaderAsync());

        //            if (dt != null && dt.Rows.Count > 0)
        //            {
        //                Contact customerInformation = (from DataRow row in dt.Rows

        //                                               select new Contact
        //                                               {
        //                                                   FirstName = row["FirstName"].ToString(),
        //                                                   LastName = row["LastName"].ToString(),
        //                                                   Email = row["Email"].ToString(),
        //                                                   Phone = row["Phonenumber"].ToString(),
        //                                                   Status = (Status)Convert.ToUInt32(row["Status"])
        //                                               }).First();

        //                return customerInformation;
        //            }

        //            else
        //                return null;
        //        }
        //        catch (Exception e)
        //        {
        //            throw;
        //        }
        //    }
        //}

        //private static void GetCommandParameters(Contact user, SqlCommand cmd)
        //{
        //    cmd.Parameters.AddWithValue("@Id", user.Id);
        //    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
        //    cmd.Parameters.AddWithValue("@LastName", user.LastName);
        //    cmd.Parameters.AddWithValue("@Email", user.Email);           
        //    cmd.Parameters.AddWithValue("@PhoneNumber", user.Phone);
        //    cmd.Parameters.AddWithValue("@Status", user.Status);      
        //}


    }
}
