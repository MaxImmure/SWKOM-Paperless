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

namespace IO.Swagger.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class InlineResponse20011DocumentFileTypeCounts : IEquatable<InlineResponse20011DocumentFileTypeCounts>
    { 
        /// <summary>
        /// Gets or Sets MimeType
        /// </summary>
        [Required]

        [DataMember(Name="mime_type")]
        public string MimeType { get; set; }

        /// <summary>
        /// Gets or Sets MimeTypeCount
        /// </summary>
        [Required]

        [DataMember(Name="mime_type_count")]
        public int? MimeTypeCount { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class InlineResponse20011DocumentFileTypeCounts {\n");
            sb.Append("  MimeType: ").Append(MimeType).Append("\n");
            sb.Append("  MimeTypeCount: ").Append(MimeTypeCount).Append("\n");
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
            return obj.GetType() == GetType() && Equals((InlineResponse20011DocumentFileTypeCounts)obj);
        }

        /// <summary>
        /// Returns true if InlineResponse20011DocumentFileTypeCounts instances are equal
        /// </summary>
        /// <param name="other">Instance of InlineResponse20011DocumentFileTypeCounts to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InlineResponse20011DocumentFileTypeCounts other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    MimeType == other.MimeType ||
                    MimeType != null &&
                    MimeType.Equals(other.MimeType)
                ) && 
                (
                    MimeTypeCount == other.MimeTypeCount ||
                    MimeTypeCount != null &&
                    MimeTypeCount.Equals(other.MimeTypeCount)
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
                    if (MimeType != null)
                    hashCode = hashCode * 59 + MimeType.GetHashCode();
                    if (MimeTypeCount != null)
                    hashCode = hashCode * 59 + MimeTypeCount.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(InlineResponse20011DocumentFileTypeCounts left, InlineResponse20011DocumentFileTypeCounts right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(InlineResponse20011DocumentFileTypeCounts left, InlineResponse20011DocumentFileTypeCounts right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
