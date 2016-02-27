using AutoMapper;
using Company.Common;
using Company.Model.Common;
using Company.Service.Common;
using Company.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Company.WebApi.Controllers
{
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
         private readonly IEmployeeService service;
       
            public EmployeeController(IEmployeeService service)
        {
            this.service = service;
        }


            [Route("getById/{id}")]
            [HttpGet]
            public async Task<HttpResponseMessage> Get(int id)
            {
                try
                {
                    EmployeeModel result = Mapper.Map<EmployeeModel>(await service.GetAsync(id));

                    if (result == null)
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Error while getting task.");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, result);
                    }
                }
                catch (Exception ex)
                {

                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }

            [Route("{pageNumber}/{pageSize}")]
            [HttpGet]
            public async Task<HttpResponseMessage> Get(int pageNumber, int pageSize)
            {
                try
                {
                    if (pageNumber < 1 || pageSize < 1)
                    {
                        pageSize = 1;
                        pageNumber = 1;
                    }

                    GenericPaging filter = new GenericPaging(pageNumber, pageSize);

                    ICollection<EmployeeModel> result = Mapper.Map<ICollection<EmployeeModel>>(await service.GetRangeAsync(filter));

                    return Request.CreateResponse(HttpStatusCode.OK, result);

                }
                catch (Exception ex)
                {

                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }

            [Route("GetByName/{search}/{pageNumber}/{pageSize}")]
            [HttpGet]
            public async Task<HttpResponseMessage> Get(string search, int pageNumber, int pageSize)
            {
                try
                {
                    if (pageNumber < 1 || pageSize < 1)
                    {
                        pageSize = 1;
                        pageNumber = 1;
                    }

                    GenericPaging filter = new GenericPaging(pageNumber, pageSize);

                    ICollection<EmployeeModel> result = Mapper.Map<ICollection<EmployeeModel>>(await service.GetRangeAsync(filter, search));

                    return Request.CreateResponse(HttpStatusCode.OK, result);

                }
                catch (Exception ex)
                {

                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }

            [HttpPost]
            [Route("")]
            public async Task<HttpResponseMessage> Insert(EmployeeModel emp)
            {
                try
                {
                    int result = await service.AddAsync(Mapper.Map<IEmployee>(emp));

                    if (result == 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Add operation error.");
                    }

                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, result);
                    }
                }
                catch (Exception ex)
                {

                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }

            [HttpPut]
            [Route("Update/{id}")]
            public async Task<HttpResponseMessage> Update(int id, EmployeeModel model)
            
            {
                try
                {
                    int result = await service.UpdateAsync(Mapper.Map<IEmployee>(model));

                    if (result >= 1)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, model);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Error while trying to edit task.");
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }

            [HttpDelete]
            [Route("Delete/{id}")]
            public async Task<HttpResponseMessage> Delete(int id)
            {
                try
                {
                    int result = await service.DeleteAsync(id);

                    if (result == 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Delete operation failed.");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Task deleted");
                    }
                }
                catch (Exception ex)
                {

                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }

    }
}
