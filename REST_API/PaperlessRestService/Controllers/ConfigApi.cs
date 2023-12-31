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
    public class ConfigApiController : ControllerBase
    { 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/logs/{id}")]
        [ValidateModelState]
        [SwaggerOperation("GetLog")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<string>), description: "Success")]
        public virtual IActionResult GetLog([FromRoute][Required]string id)
        {
            string[] log = new string[] { "line1", "line2", "line3" };
            return this.Ok(log);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/logs")]
        [ValidateModelState]
        [SwaggerOperation("GetLogs")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<string>), description: "Success")]
        public virtual IActionResult GetLogs()
        {
            return this.Ok(new string[] { "All", "AppTier", "Worker" });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="fullPerms"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/storage_paths")]
        [ValidateModelState]
        [SwaggerOperation("GetStoragePaths")]
        [SwaggerResponse(statusCode: 200, type: typeof(InlineResponse20022), description: "Success")]
        public IActionResult GetStoragePaths()
        {
            var result = new
            {
                count = 0,
                // next = null,
                // previous = null,
                all = new string[0],
                results = new string[0]
            };

            return this.Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("/api/ui_settings")]
        [ValidateModelState]
        [SwaggerOperation("GetUISettings")]
        [SwaggerResponse(statusCode: 200, type: typeof(InlineResponse20025), description: "Success")]
        public IActionResult GetUISettings()
        {
            string result = @"{
            ""display_name"": ""max"",
            ""user"": {
                ""id"": 3,
                ""username"": ""max"",
                ""is_superuser"": true,
                ""groups"": []
            },
            ""settings"": {
                ""update_checking"": {
                    ""enabled"": false,
                    ""backend_setting"": ""default""
                },
                ""bulk_edit"": {
                    ""apply_on_close"": false,
                    ""confirmation_dialogs"": true
                },
                ""documentListSize"": 50,
                ""slim_sidebar"": false,
                ""dark_mode"": {
                    ""use_system"": true,
                    ""enabled"": ""false"",
                    ""thumb_inverted"": ""false""
                },
                ""theme"": {
                    ""color"": """"
                },
                ""document_details"": {
                    ""native_pdf_viewer"": true
                },
                ""date_display"": {
                    ""date_locale"": """",
                    ""date_format"": ""mediumDate""
                },
                ""notifications"": {
                    ""consumer_new_documents"": true,
                    ""consumer_success"": true,
                    ""consumer_failed"": true,
                    ""consumer_suppress_on_dashboard"": true
                },
                ""comments_enabled"": true,
                ""language"": """"
            },
            ""permissions"": [
                ""view_userobjectpermission"",
                ""delete_failure"",
                ""view_uisettings"",
                ""change_user"",
                ""delete_task"",
                ""change_group"",
                ""change_savedviewfilterrule"",
                ""add_ormq"",
                ""view_contenttype"",
                ""add_mailaccount"",
                ""add_storagepath"",
                ""add_document"",
                ""change_uisettings"",
                ""view_paperlesstask"",
                ""change_log"",
                ""add_comment"",
                ""add_log"",
                ""view_user"",
                ""change_groupobjectpermission"",
                ""delete_mailrule"",
                ""view_taskresult"",
                ""add_correspondent"",
                ""view_savedview"",
                ""change_correspondent"",
                ""change_groupresult"",
                ""delete_group"",
                ""add_savedview"",
                ""delete_note"",
                ""view_permission"",
                ""add_savedviewfilterrule"",
                ""change_comment"",
                ""add_session"",
                ""change_processedmail"",
                ""add_taskresult"",
                ""change_document"",
                ""add_group"",
                ""view_log"",
                ""change_note"",
                ""add_success"",
                ""change_contenttype"",
                ""add_permission"",
                ""change_mailrule"",
                ""delete_schedule"",
                ""view_savedviewfilterrule"",
                ""view_task"",
                ""add_token"",
                ""delete_user"",
                ""delete_contenttype"",
                ""add_user"",
                ""add_chordcounter"",
                ""add_note"",
                ""add_failure"",
                ""view_session"",
                ""add_documenttype"",
                ""view_correspondent"",
                ""add_paperlesstask"",
                ""change_taskresult"",
                ""delete_chordcounter"",
                ""view_token"",
                ""delete_savedview"",
                ""delete_groupobjectpermission"",
                ""view_schedule"",
                ""add_processedmail"",
                ""change_tag"",
                ""change_userobjectpermission"",
                ""delete_documenttype"",
                ""delete_processedmail"",
                ""view_mailaccount"",
                ""delete_token"",
                ""delete_savedviewfilterrule"",
                ""add_tokenproxy"",
                ""add_mailrule"",
                ""view_documenttype"",
                ""delete_tag"",
                ""add_contenttype"",
                ""add_task"",
                ""add_schedule"",
                ""change_token"",
                ""change_ormq"",
                ""delete_permission"",
                ""delete_storagepath"",
                ""view_tokenproxy"",
                ""delete_logentry"",
                ""delete_correspondent"",
                ""delete_tokenproxy"",
                ""change_success"",
                ""delete_document"",
                ""change_logentry"",
                ""view_failure"",
                ""add_uisettings"",
                ""change_permission"",
                ""change_savedview"",
                ""delete_groupresult"",
                ""add_groupresult"",
                ""view_logentry"",
                ""delete_paperlesstask"",
                ""change_task"",
                ""view_storagepath"",
                ""view_groupobjectpermission"",
                ""delete_success"",
                ""view_groupresult"",
                ""add_groupobjectpermission"",
                ""delete_log"",
                ""view_ormq"",
                ""add_logentry"",
                ""view_success"",
                ""delete_ormq"",
                ""change_paperlesstask"",
                ""delete_uisettings"",
                ""change_failure"",
                ""change_session"",
                ""view_mailrule"",
                ""add_userobjectpermission"",
                ""view_tag"",
                ""delete_mailaccount"",
                ""delete_taskresult"",
                ""delete_session"",
                ""change_mailaccount"",
                ""view_comment"",
                ""view_note"",
                ""change_tokenproxy"",
                ""change_storagepath"",
                ""view_chordcounter"",
                ""change_schedule"",
                ""change_chordcounter"",
                ""view_processedmail"",
                ""add_tag"",
                ""view_group"",
                ""view_document"",
                ""delete_comment"",
                ""delete_userobjectpermission"",
                ""change_documenttype""
            ]
        }";

            return Ok(result);
        }
    }
}
