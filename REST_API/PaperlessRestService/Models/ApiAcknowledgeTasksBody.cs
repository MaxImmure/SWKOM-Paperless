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
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace PaperlessRestService.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class ApiAcknowledgeTasksBody : IEquatable<ApiAcknowledgeTasksBody>
    { 
        /// <summary>
        /// Gets or Sets Tasks
        /// </summary>
        [Required]

        [DataMember(Name="tasks")]
        public List<int?> Tasks { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ApiAcknowledgeTasksBody {\n");
            sb.Append("  Tasks: ").Append(Tasks).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((ApiAcknowledgeTasksBody)obj);
        }

        /// <summary>
        /// Returns true if ApiAcknowledgeTasksBody instances are equal
        /// </summary>
        /// <param name="other">Instance of ApiAcknowledgeTasksBody to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ApiAcknowledgeTasksBody other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Tasks == other.Tasks ||
                    Tasks != null &&
                    Tasks.SequenceEqual(other.Tasks)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    if (Tasks != null)
                    hashCode = hashCode * 59 + Tasks.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(ApiAcknowledgeTasksBody left, ApiAcknowledgeTasksBody right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ApiAcknowledgeTasksBody left, ApiAcknowledgeTasksBody right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
