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
using PaperlessRestService.BusinessLogic;
using PaperlessRestService.BusinessLogic.Entities;
using Document = PaperlessRestService.BusinessLogic.Entities.Document;
using PaperlessRestService.BusinessLogic.ExceptionHandling;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.IO;

namespace PaperlessRestService.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class DocumentsApiController : ControllerBase
    {
        private readonly IErrorHandler errorHandler;
        private readonly BLActionExecuterMiddleware actionExecuter;
        private readonly ILogger<DocumentsApiController> logger;

        public DocumentsApiController(
            IErrorHandler errorHandler,
            BLActionExecuterMiddleware actionExecuter,
            ILogger<DocumentsApiController> logger)
        {
            this.errorHandler = errorHandler;
            this.actionExecuter = actionExecuter;
            this.logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <response code="200">Success</response>
        [HttpPost]
        [Route("/api/documents/bulk_edit")]
        [ValidateModelState]
        [SwaggerOperation("BulkEdit")]
        public virtual IActionResult BulkEdit([FromBody] DocumentsBulkEditBody body)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200);

            throw new NotImplementedException();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name=""></param>
        /// <response code="200">Success</response>
        [HttpPost]
        [Route("/api/documents/post_document")]
        [ValidateModelState]
        [SwaggerOperation("PostDocument")]
        [Consumes("multipart/form-data")]
        public virtual IActionResult PostDocument([FromForm] DocumentsPostDocumentBody body, [FromServices] IUploadDocumentLogic uploadDocumentLogic)
        {
            Document doc = new Document()
            {
                Id = Guid.NewGuid().GetHashCode(),
                Title = body.Title,
                Created_Date = body.Created.GetValueOrDefault(),
                //Document_Type = body.Document.First().ContentType,
                Added = DateTime.Now
            };

            using (MemoryStream ms = new())
            {
                body.Document.First().CopyTo(ms);

                doc.Data = ms.ToArray();
            }

            try
            {
                actionExecuter.Execute(() =>
                {
                    uploadDocumentLogic.UploadDocument(doc);
                });

                return Ok($"/api/documents/{doc.Id}");
            }
            catch (Exception ex)
            {
                errorHandler.HandleError(ex, logger);
                return ControllerResponseFactory.CreateErrorResponse("Fehler beim uploaden des Dokuments");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">Success</response>
        [HttpDelete]
        [Route("/api/documents/{id}")]
        [ValidateModelState]
        [SwaggerOperation("DeleteDocument")]
        public virtual IActionResult DeleteDocument([FromServices] IDocumentCRUDLogic documentComp, [FromRoute][Required] int? id)
        {
            //TODO: Uncomment the next line to return response 204 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(204);

            if (id == 0)
            {
                return ControllerResponseFactory.CreateBadRequestResponse("Invalid document id");
            }

            documentComp.DeleteDocument(id.Value);

            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="original"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/documents/{id}/download")]
        [ValidateModelState]
        [SwaggerOperation("DownloadDocument")]
        [SwaggerResponse(statusCode: 200, type: typeof(byte[]), description: "Success")]
        public virtual IActionResult DownloadDocument([FromRoute][Required] int? id, [FromQuery] bool? original)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(byte[]));
            string exampleJson = null;
            exampleJson = "\"\"";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<byte[]>(exampleJson)
            : default(byte[]);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="page"></param>
        /// <param name="fullPerms"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/documents/{id}")]
        [ValidateModelState]
        [SwaggerOperation("GetDocument")]
        [SwaggerResponse(statusCode: 200, type: typeof(InlineResponse2003), description: "Success")]
        public virtual IActionResult GetDocument(
            [FromServices] IDocumentCRUDLogic documentComp,
            [FromRoute][Required] int? id,
            [FromQuery] int? page,
            [FromQuery] bool? fullPerms)
        {
            if (id == 0)
            {
                return ControllerResponseFactory.CreateBadRequestResponse("Invalid document id");
            }

            var document = documentComp.GetDocument(id.Value);

            if (document == null)
            {
                return ControllerResponseFactory.CreateBadRequestResponse("Document not found");
            }

            return ControllerResponseFactory.CreateSuccessResponse(document);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/documents/{id}/metadata")]
        [ValidateModelState]
        [SwaggerOperation("GetDocumentMetadata")]
        [SwaggerResponse(statusCode: 200, type: typeof(InlineResponse2007), description: "Success")]
        public virtual IActionResult GetDocumentMetadata([FromRoute][Required] int? id)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(InlineResponse2007));
            string exampleJson = null;
            exampleJson = "{\n  \"archive_size\" : 6,\n  \"archive_metadata\" : [ {\n    \"prefix\" : \"prefix\",\n    \"namespace\" : \"namespace\",\n    \"value\" : \"value\",\n    \"key\" : \"key\"\n  }, {\n    \"prefix\" : \"prefix\",\n    \"namespace\" : \"namespace\",\n    \"value\" : \"value\",\n    \"key\" : \"key\"\n  } ],\n  \"original_metadata\" : [ \"\", \"\" ],\n  \"original_filename\" : \"original_filename\",\n  \"original_mime_type\" : \"original_mime_type\",\n  \"archive_checksum\" : \"archive_checksum\",\n  \"original_checksum\" : \"original_checksum\",\n  \"lang\" : \"lang\",\n  \"media_filename\" : \"media_filename\",\n  \"has_archive_version\" : true,\n  \"archive_media_filename\" : \"archive_media_filename\",\n  \"original_size\" : 0\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<InlineResponse2007>(exampleJson)
            : default(InlineResponse2007);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/documents/{id}/preview")]
        [ValidateModelState]
        [SwaggerOperation("GetDocumentPreview")]
        [SwaggerResponse(statusCode: 200, type: typeof(byte[]), description: "Success")]
        public virtual IActionResult GetDocumentPreview([FromRoute][Required] int? id)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(byte[]));
            string exampleJson = null;
            exampleJson = "\"\"";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<byte[]>(exampleJson)
            : default(byte[]);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/documents/{id}/suggestions")]
        [ValidateModelState]
        [SwaggerOperation("GetDocumentSuggestions")]
        [SwaggerResponse(statusCode: 200, type: typeof(InlineResponse2006), description: "Success")]
        public virtual IActionResult GetDocumentSuggestions([FromRoute][Required] int? id)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(InlineResponse2006));
            string exampleJson = null;
            exampleJson = "{\n  \"storage_paths\" : [ \"\", \"\" ],\n  \"document_types\" : [ \"\", \"\" ],\n  \"dates\" : [ \"\", \"\" ],\n  \"correspondents\" : [ \"\", \"\" ],\n  \"tags\" : [ \"\", \"\" ]\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<InlineResponse2006>(exampleJson)
            : default(InlineResponse2006);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/documents/{id}/thumb")]
        [ValidateModelState]
        [SwaggerOperation("GetDocumentThumb")]
        [SwaggerResponse(statusCode: 200, type: typeof(byte[]), description: "Success")]
        public virtual IActionResult GetDocumentThumb([FromRoute][Required] int? id)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(byte[]));
            string exampleJson = null;
            exampleJson = "\"\"";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<byte[]>(exampleJson)
            : default(byte[]);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="query"></param>
        /// <param name="ordering"></param>
        /// <param name="tagsIdAll"></param>
        /// <param name="documentTypeId"></param>
        /// <param name="storagePathIdIn"></param>
        /// <param name="correspondentId"></param>
        /// <param name="truncateContent"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/documents")]
        [ValidateModelState]
        [SwaggerOperation("GetDocuments")]
        [SwaggerResponse(statusCode: 200, type: typeof(InlineResponse2002), description: "Success")]
        public virtual IActionResult GetDocuments([FromQuery] int? page, [FromQuery] int? pageSize, [FromQuery] string query, [FromQuery] string ordering, [FromQuery] List<int?> tagsIdAll, [FromQuery] int? documentTypeId, [FromQuery] int? storagePathIdIn, [FromQuery] int? correspondentId, [FromQuery] bool? truncateContent)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(InlineResponse2002));
            string exampleJson = null;
            exampleJson = "{\n  \"next\" : 6,\n  \"all\" : [ 5, 5 ],\n  \"previous\" : 1,\n  \"count\" : 0,\n  \"results\" : [ {\n    \"owner\" : 4,\n    \"user_can_change\" : true,\n    \"archive_serial_number\" : 2,\n    \"notes\" : [ {\n      \"note\" : \"note\",\n      \"created\" : \"created\",\n      \"document\" : 1,\n      \"id\" : 7,\n      \"user\" : 1\n    }, {\n      \"note\" : \"note\",\n      \"created\" : \"created\",\n      \"document\" : 1,\n      \"id\" : 7,\n      \"user\" : 1\n    } ],\n    \"added\" : \"added\",\n    \"created\" : \"created\",\n    \"title\" : \"title\",\n    \"content\" : \"content\",\n    \"tags\" : [ 3, 3 ],\n    \"storage_path\" : 9,\n    \"archived_file_name\" : \"archived_file_name\",\n    \"modified\" : \"modified\",\n    \"correspondent\" : 2,\n    \"original_file_name\" : \"original_file_name\",\n    \"id\" : 5,\n    \"created_date\" : \"created_date\",\n    \"document_type\" : 7\n  }, {\n    \"owner\" : 4,\n    \"user_can_change\" : true,\n    \"archive_serial_number\" : 2,\n    \"notes\" : [ {\n      \"note\" : \"note\",\n      \"created\" : \"created\",\n      \"document\" : 1,\n      \"id\" : 7,\n      \"user\" : 1\n    }, {\n      \"note\" : \"note\",\n      \"created\" : \"created\",\n      \"document\" : 1,\n      \"id\" : 7,\n      \"user\" : 1\n    } ],\n    \"added\" : \"added\",\n    \"created\" : \"created\",\n    \"title\" : \"title\",\n    \"content\" : \"content\",\n    \"tags\" : [ 3, 3 ],\n    \"storage_path\" : 9,\n    \"archived_file_name\" : \"archived_file_name\",\n    \"modified\" : \"modified\",\n    \"correspondent\" : 2,\n    \"original_file_name\" : \"original_file_name\",\n    \"id\" : 5,\n    \"created_date\" : \"created_date\",\n    \"document_type\" : 7\n  } ]\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<InlineResponse2002>(exampleJson)
            : default(InlineResponse2002);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <response code="200">Success</response>
        [HttpPost]
        [Route("/api/documents/selection_data")]
        [ValidateModelState]
        [SwaggerOperation("SelectionData")]
        [SwaggerResponse(statusCode: 200, type: typeof(InlineResponse2005), description: "Success")]
        public virtual IActionResult SelectionData([FromBody] DocumentsSelectionDataBody body)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(InlineResponse2005));
            string exampleJson = null;
            exampleJson = "{\n  \"selected_storage_paths\" : [ null, null ],\n  \"selected_document_types\" : [ null, null ],\n  \"selected_correspondents\" : [ {\n    \"document_count\" : 6,\n    \"id\" : 0\n  }, {\n    \"document_count\" : 6,\n    \"id\" : 0\n  } ],\n  \"selected_tags\" : [ null, null ]\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<InlineResponse2005>(exampleJson)
            : default(InlineResponse2005);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <response code="200">Success</response>
        [HttpPut]
        [Route("/api/documents/{id}")]
        [ValidateModelState]
        [SwaggerOperation("UpdateDocument")]
        [SwaggerResponse(statusCode: 200, type: typeof(InlineResponse2004), description: "Success")]
        public virtual IActionResult UpdateDocument([FromRoute][Required] int? id, [FromBody] DocumentsIdBody body)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(InlineResponse2004));
            string exampleJson = null;
            exampleJson = "{\n  \"owner\" : 7,\n  \"user_can_change\" : true,\n  \"archive_serial_number\" : 2,\n  \"notes\" : [ \"\", \"\" ],\n  \"added\" : \"added\",\n  \"created\" : \"created\",\n  \"title\" : \"title\",\n  \"content\" : \"content\",\n  \"tags\" : [ 5, 5 ],\n  \"storage_path\" : 5,\n  \"archived_file_name\" : \"archived_file_name\",\n  \"modified\" : \"modified\",\n  \"correspondent\" : 6,\n  \"original_file_name\" : \"original_file_name\",\n  \"id\" : 0,\n  \"created_date\" : \"created_date\",\n  \"document_type\" : 1\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<InlineResponse2004>(exampleJson)
            : default(InlineResponse2004);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

    }
}
