using Evolent.BusinessLayer.Helpers;
using Evolent.BusinessLayer.Interface;
using Evolent.BusinessLayer.Repository;
using Evolent.DataAccessLayer.Services;
using Evolent.Models.Response;
using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvolentContact.Controllers
{
    [Route("api/Contact")]
    public class ContactController : ControllerBase
    {
        private IContact _contact;
        private object p;
        private ContactDataAccess dbContext;

        //public ContactController(IContact contact)
        //{
        //    _contact = contact;
        //}

        public ContactController( ContactDataAccess dbContext)
        {
           
            this.dbContext = dbContext;
            _contact = new ContactRepository(dbContext);
        }

        [HttpPost("AddContact")]        
        public async Task<ResponseModel> AddContact([FromBody] Evolent.Models.ContactModel.Contact contactModel)
        {
            try
            {
                if (await _contact.Add(contactModel))
                {
                    return APIResponseObject.IsSuccess(System.Net.HttpStatusCode.Created, "Record saved successfully");
                }
                else
                {
                    return APIResponseObject.IsFailure("Failed to Add contact");
                }
            }
            catch (Exception ex)
            {
                return APIResponseObject.IsFailure(ex.Message);
            }
        }
        [HttpGet("GetContacts")]
        public async Task<ResponseModel> GetContacts()
        {
            try
            {
                var data = await _contact.Get();
                if (data!= null)
                {

                 //  var result = JsonConvert.SerializeObject(data);
                    return APIResponseObject.IsSuccess(data);
                }
                else
                {
                    return APIResponseObject.IsFailure("Failed to Get contact");
                }
            }
            catch (Exception ex)
            {
                return APIResponseObject.IsFailure(ex.Message);
            }
        }

        [HttpDelete("DeleteContact")]
        public async Task<ResponseModel> DeleteContact([FromQuery] int Id)
        {
            try
            {
                if (await _contact.Delete(Id))
                {
                    return APIResponseObject.IsSuccess(System.Net.HttpStatusCode.OK, "Record deleted successfully");
                }
                else
                {
                    return APIResponseObject.IsFailure("Failed to delete contact");
                }
            }
            catch (Exception ex)
            {
                return APIResponseObject.IsFailure(ex.Message);
            }
        }
    }
}
