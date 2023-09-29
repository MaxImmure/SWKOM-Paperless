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
    public partial class ApiSavedViewsBody : IEquatable<ApiSavedViewsBody>
    { 
        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [Required]

        [DataMember(Name="name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets ShowOnDashboard
        /// </summary>
        [Required]

        [DataMember(Name="show_on_dashboard")]
        public bool? ShowOnDashboard { get; set; }

        /// <summary>
        /// Gets or Sets ShowInSidebar
        /// </summary>
        [Required]

        [DataMember(Name="show_in_sidebar")]
        public bool? ShowInSidebar { get; set; }

        /// <summary>
        /// Gets or Sets FilterRules
        /// </summary>
        [Required]

        [DataMember(Name="filter_rules")]
        public List<ApisavedViewsFilterRules> FilterRules { get; set; }

        /// <summary>
        /// Gets or Sets SortReverse
        /// </summary>
        [Required]

        [DataMember(Name="sort_reverse")]
        public bool? SortReverse { get; set; }

        /// <summary>
        /// Gets or Sets SortField
        /// </summary>
        [Required]

        [DataMember(Name="sort_field")]
        public string SortField { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ApiSavedViewsBody {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  ShowOnDashboard: ").Append(ShowOnDashboard).Append("\n");
            sb.Append("  ShowInSidebar: ").Append(ShowInSidebar).Append("\n");
            sb.Append("  FilterRules: ").Append(FilterRules).Append("\n");
            sb.Append("  SortReverse: ").Append(SortReverse).Append("\n");
            sb.Append("  SortField: ").Append(SortField).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ApiSavedViewsBody)obj);
        }

        /// <summary>
        /// Returns true if ApiSavedViewsBody instances are equal
        /// </summary>
        /// <param name="other">Instance of ApiSavedViewsBody to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ApiSavedViewsBody other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Name == other.Name ||
                    Name != null &&
                    Name.Equals(other.Name)
                ) && 
                (
                    ShowOnDashboard == other.ShowOnDashboard ||
                    ShowOnDashboard != null &&
                    ShowOnDashboard.Equals(other.ShowOnDashboard)
                ) && 
                (
                    ShowInSidebar == other.ShowInSidebar ||
                    ShowInSidebar != null &&
                    ShowInSidebar.Equals(other.ShowInSidebar)
                ) && 
                (
                    FilterRules == other.FilterRules ||
                    FilterRules != null &&
                    FilterRules.SequenceEqual(other.FilterRules)
                ) && 
                (
                    SortReverse == other.SortReverse ||
                    SortReverse != null &&
                    SortReverse.Equals(other.SortReverse)
                ) && 
                (
                    SortField == other.SortField ||
                    SortField != null &&
                    SortField.Equals(other.SortField)
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
                    if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                    if (ShowOnDashboard != null)
                    hashCode = hashCode * 59 + ShowOnDashboard.GetHashCode();
                    if (ShowInSidebar != null)
                    hashCode = hashCode * 59 + ShowInSidebar.GetHashCode();
                    if (FilterRules != null)
                    hashCode = hashCode * 59 + FilterRules.GetHashCode();
                    if (SortReverse != null)
                    hashCode = hashCode * 59 + SortReverse.GetHashCode();
                    if (SortField != null)
                    hashCode = hashCode * 59 + SortField.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(ApiSavedViewsBody left, ApiSavedViewsBody right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ApiSavedViewsBody left, ApiSavedViewsBody right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
