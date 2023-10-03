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
    public partial class ApicorrespondentsidPermissions : IEquatable<ApicorrespondentsidPermissions>
    { 
        /// <summary>
        /// Gets or Sets View
        /// </summary>
        [Required]

        [DataMember(Name="view")]
        public ApicorrespondentsidPermissionsView View { get; set; }

        /// <summary>
        /// Gets or Sets Change
        /// </summary>
        [Required]

        [DataMember(Name="change")]
        public ApicorrespondentsidPermissionsView Change { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ApicorrespondentsidPermissions {\n");
            sb.Append("  View: ").Append(View).Append("\n");
            sb.Append("  Change: ").Append(Change).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ApicorrespondentsidPermissions)obj);
        }

        /// <summary>
        /// Returns true if ApicorrespondentsidPermissions instances are equal
        /// </summary>
        /// <param name="other">Instance of ApicorrespondentsidPermissions to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ApicorrespondentsidPermissions other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    View == other.View ||
                    View != null &&
                    View.Equals(other.View)
                ) && 
                (
                    Change == other.Change ||
                    Change != null &&
                    Change.Equals(other.Change)
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
                    if (View != null)
                    hashCode = hashCode * 59 + View.GetHashCode();
                    if (Change != null)
                    hashCode = hashCode * 59 + Change.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(ApicorrespondentsidPermissions left, ApicorrespondentsidPermissions right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ApicorrespondentsidPermissions left, ApicorrespondentsidPermissions right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
