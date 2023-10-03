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
    public partial class ApigroupsidPermissionsForm : IEquatable<ApigroupsidPermissionsForm>
    { 
        /// <summary>
        /// Gets or Sets SetPermissions
        /// </summary>
        [Required]

        [DataMember(Name="set_permissions")]
        public List<string> SetPermissions { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ApigroupsidPermissionsForm {\n");
            sb.Append("  SetPermissions: ").Append(SetPermissions).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ApigroupsidPermissionsForm)obj);
        }

        /// <summary>
        /// Returns true if ApigroupsidPermissionsForm instances are equal
        /// </summary>
        /// <param name="other">Instance of ApigroupsidPermissionsForm to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ApigroupsidPermissionsForm other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    SetPermissions == other.SetPermissions ||
                    SetPermissions != null &&
                    SetPermissions.SequenceEqual(other.SetPermissions)
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
                    if (SetPermissions != null)
                    hashCode = hashCode * 59 + SetPermissions.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(ApigroupsidPermissionsForm left, ApigroupsidPermissionsForm right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ApigroupsidPermissionsForm left, ApigroupsidPermissionsForm right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
