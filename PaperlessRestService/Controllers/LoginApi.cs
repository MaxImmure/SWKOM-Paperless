/*
 * Paperless Rest Server
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 1.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using PaperlessRestService.Attributes;

using Microsoft.AspNetCore.Authorization;
using PaperlessRestService.Models;

namespace PaperlessRestService.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class LoginApiController : ControllerBase
    { 
        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api")]
        [ValidateModelState]
        [SwaggerOperation("ApiGet")]
        public virtual IActionResult ApiGet()
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200);

            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <response code="200">Success</response>
        [HttpPost]
        [Route("/api/groups")]
        [ValidateModelState]
        [SwaggerOperation("CreateGroup")]
        [SwaggerResponse(statusCode: 200, type: typeof(Object), description: "Success")]
        public virtual IActionResult CreateGroup([FromBody]ApiGroupsBody body)
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(Object));
            string exampleJson = null;
            exampleJson = "{ }";
            
                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<Object>(exampleJson)
                        : default(Object);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <response code="200">Success</response>
        [HttpPost]
        [Route("/api/users")]
        [ValidateModelState]
        [SwaggerOperation("CreateUser")]
        [SwaggerResponse(statusCode: 200, type: typeof(InlineResponse20015), description: "Success")]
        public virtual IActionResult CreateUser([FromBody]ApiUsersBody body)
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(InlineResponse20015));
            string exampleJson = null;
            exampleJson = "{\n  \"is_active\" : true,\n  \"is_superuser\" : true,\n  \"user_permissions\" : [ \"\", \"\" ],\n  \"is_staff\" : true,\n  \"last_name\" : \"last_name\",\n  \"groups\" : [ \"\", \"\" ],\n  \"password\" : \"password\",\n  \"id\" : 5,\n  \"date_joined\" : \"date_joined\",\n  \"first_name\" : \"first_name\",\n  \"email\" : \"email\",\n  \"username\" : \"username\",\n  \"inherited_permissions\" : [ \"inherited_permissions\", \"inherited_permissions\" ]\n}";
            
                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<InlineResponse20015>(exampleJson)
                        : default(InlineResponse20015);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">Success</response>
        [HttpDelete]
        [Route("/api/groups/{id}")]
        [ValidateModelState]
        [SwaggerOperation("DeleteGroup")]
        public virtual IActionResult DeleteGroup([FromRoute][Required]int? id)
        { 
            //TODO: Uncomment the next line to return response 204 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(204);

            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">Success</response>
        [HttpDelete]
        [Route("/api/users/{id}")]
        [ValidateModelState]
        [SwaggerOperation("DeleteUser")]
        public virtual IActionResult DeleteUser([FromRoute][Required]int? id)
        { 
            //TODO: Uncomment the next line to return response 204 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(204);

            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/groups")]
        [ValidateModelState]
        [SwaggerOperation("GetGroups")]
        [SwaggerResponse(statusCode: 200, type: typeof(InlineResponse20012), description: "Success")]
        public virtual IActionResult GetGroups([FromQuery]int? page, [FromQuery]int? pageSize)
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(InlineResponse20012));
            string exampleJson = null;
            exampleJson = "{\n  \"next\" : 6,\n  \"all\" : [ \"\", \"\" ],\n  \"previous\" : 1,\n  \"count\" : 0,\n  \"results\" : [ \"\", \"\" ]\n}";
            
                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<InlineResponse20012>(exampleJson)
                        : default(InlineResponse20012);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <response code="200">Success</response>
        [HttpPost]
        [Route("/api/token")]
        [ValidateModelState]
        [SwaggerOperation("GetToken")]
        public virtual IActionResult GetToken([FromBody]UserInfo body)
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200);

            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/users")]
        [ValidateModelState]
        [SwaggerOperation("GetUsers")]
        [SwaggerResponse(statusCode: 200, type: typeof(InlineResponse20014), description: "Success")]
        public virtual IActionResult GetUsers([FromQuery]int? page, [FromQuery]int? pageSize)
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(InlineResponse20014));
            string exampleJson = null;
            exampleJson = "{\n  \"next\" : 6,\n  \"all\" : [ 5, 5 ],\n  \"previous\" : 1,\n  \"count\" : 0,\n  \"results\" : [ {\n    \"is_active\" : true,\n    \"is_superuser\" : true,\n    \"user_permissions\" : [ \"\", \"\" ],\n    \"is_staff\" : true,\n    \"last_name\" : \"last_name\",\n    \"groups\" : [ \"\", \"\" ],\n    \"password\" : \"password\",\n    \"id\" : 5,\n    \"date_joined\" : \"date_joined\",\n    \"first_name\" : \"first_name\",\n    \"email\" : \"email\",\n    \"username\" : \"username\",\n    \"inherited_permissions\" : [ \"inherited_permissions\", \"inherited_permissions\" ]\n  }, {\n    \"is_active\" : true,\n    \"is_superuser\" : true,\n    \"user_permissions\" : [ \"\", \"\" ],\n    \"is_staff\" : true,\n    \"last_name\" : \"last_name\",\n    \"groups\" : [ \"\", \"\" ],\n    \"password\" : \"password\",\n    \"id\" : 5,\n    \"date_joined\" : \"date_joined\",\n    \"first_name\" : \"first_name\",\n    \"email\" : \"email\",\n    \"username\" : \"username\",\n    \"inherited_permissions\" : [ \"inherited_permissions\", \"inherited_permissions\" ]\n  } ]\n}";
            
                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<InlineResponse20014>(exampleJson)
                        : default(InlineResponse20014);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">Success</response>
        [HttpPost]
        [Route("/api")]
        [ValidateModelState]
        [SwaggerOperation("Root")]
        public virtual IActionResult Root()
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200);

            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/statistics")]
        [ValidateModelState]
        [SwaggerOperation("Statistics")]
        [SwaggerResponse(statusCode: 200, type: typeof(InlineResponse20011), description: "Success")]
        public virtual IActionResult Statistics()
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(InlineResponse20011));
            string exampleJson = null;
            exampleJson = "{\n  \"document_file_type_counts\" : [ {\n    \"mime_type\" : \"mime_type\",\n    \"mime_type_count\" : 5\n  }, {\n    \"mime_type\" : \"mime_type\",\n    \"mime_type_count\" : 5\n  } ],\n  \"documents_inbox\" : 6,\n  \"inbox_tag\" : 1,\n  \"documents_total\" : 0,\n  \"character_count\" : 5\n}";
            
                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<InlineResponse20011>(exampleJson)
                        : default(InlineResponse20011);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <response code="200">Success</response>
        [HttpPut]
        [Route("/api/groups/{id}")]
        [ValidateModelState]
        [SwaggerOperation("UpdateGroup")]
        [SwaggerResponse(statusCode: 200, type: typeof(InlineResponse20013), description: "Success")]
        public virtual IActionResult UpdateGroup([FromRoute][Required]int? id, [FromBody]GroupsIdBody body)
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(InlineResponse20013));
            string exampleJson = null;
            exampleJson = "{\n  \"permissions\" : [ \"permissions\", \"permissions\" ],\n  \"name\" : \"name\",\n  \"id\" : 0\n}";
            
                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<InlineResponse20013>(exampleJson)
                        : default(InlineResponse20013);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <response code="200">Success</response>
        [HttpPut]
        [Route("/api/users/{id}")]
        [ValidateModelState]
        [SwaggerOperation("UpdateUser")]
        [SwaggerResponse(statusCode: 200, type: typeof(InlineResponse20015), description: "Success")]
        public virtual IActionResult UpdateUser([FromRoute][Required]int? id, [FromBody]UsersIdBody body)
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(InlineResponse20015));
            string exampleJson = null;
            exampleJson = "{\n  \"is_active\" : true,\n  \"is_superuser\" : true,\n  \"user_permissions\" : [ \"\", \"\" ],\n  \"is_staff\" : true,\n  \"last_name\" : \"last_name\",\n  \"groups\" : [ \"\", \"\" ],\n  \"password\" : \"password\",\n  \"id\" : 5,\n  \"date_joined\" : \"date_joined\",\n  \"first_name\" : \"first_name\",\n  \"email\" : \"email\",\n  \"username\" : \"username\",\n  \"inherited_permissions\" : [ \"inherited_permissions\", \"inherited_permissions\" ]\n}";
            
                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<InlineResponse20015>(exampleJson)
                        : default(InlineResponse20015);            //TODO: Change the data returned
            return new ObjectResult(example);
        }
    }
}
