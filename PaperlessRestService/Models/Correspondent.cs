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
    public partial class Correspondent : IEquatable<Correspondent>
    { 
        /// <summary>
        /// Gets or Sets Id
        /// </summary>

        [DataMember(Name="id")]
        public long? Id { get; set; }

        /// <summary>
        /// Gets or Sets Slug
        /// </summary>

        [DataMember(Name="slug")]
        public string Slug { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>

        [DataMember(Name="name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Match
        /// </summary>

        [DataMember(Name="match")]
        public string Match { get; set; }

        /// <summary>
        /// Gets or Sets MatchingAlgorithm
        /// </summary>

        [DataMember(Name="matching_algorithm")]
        public long? MatchingAlgorithm { get; set; }

        /// <summary>
        /// Gets or Sets IsInsensitive
        /// </summary>

        [DataMember(Name="is_insensitive")]
        public bool? IsInsensitive { get; set; }

        /// <summary>
        /// Gets or Sets DocumentCount
        /// </summary>

        [DataMember(Name="document_count")]
        public long? DocumentCount { get; set; }

        /// <summary>
        /// Gets or Sets LastCorrespondence
        /// </summary>

        [DataMember(Name="last_correspondence")]
        public DateTime? LastCorrespondence { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Correspondent {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Slug: ").Append(Slug).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Match: ").Append(Match).Append("\n");
            sb.Append("  MatchingAlgorithm: ").Append(MatchingAlgorithm).Append("\n");
            sb.Append("  IsInsensitive: ").Append(IsInsensitive).Append("\n");
            sb.Append("  DocumentCount: ").Append(DocumentCount).Append("\n");
            sb.Append("  LastCorrespondence: ").Append(LastCorrespondence).Append("\n");
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
            return obj.GetType() == GetType() && Equals((Correspondent)obj);
        }

        /// <summary>
        /// Returns true if Correspondent instances are equal
        /// </summary>
        /// <param name="other">Instance of Correspondent to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Correspondent other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Id == other.Id ||
                    Id != null &&
                    Id.Equals(other.Id)
                ) && 
                (
                    Slug == other.Slug ||
                    Slug != null &&
                    Slug.Equals(other.Slug)
                ) && 
                (
                    Name == other.Name ||
                    Name != null &&
                    Name.Equals(other.Name)
                ) && 
                (
                    Match == other.Match ||
                    Match != null &&
                    Match.Equals(other.Match)
                ) && 
                (
                    MatchingAlgorithm == other.MatchingAlgorithm ||
                    MatchingAlgorithm != null &&
                    MatchingAlgorithm.Equals(other.MatchingAlgorithm)
                ) && 
                (
                    IsInsensitive == other.IsInsensitive ||
                    IsInsensitive != null &&
                    IsInsensitive.Equals(other.IsInsensitive)
                ) && 
                (
                    DocumentCount == other.DocumentCount ||
                    DocumentCount != null &&
                    DocumentCount.Equals(other.DocumentCount)
                ) && 
                (
                    LastCorrespondence == other.LastCorrespondence ||
                    LastCorrespondence != null &&
                    LastCorrespondence.Equals(other.LastCorrespondence)
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
                    if (Id != null)
                    hashCode = hashCode * 59 + Id.GetHashCode();
                    if (Slug != null)
                    hashCode = hashCode * 59 + Slug.GetHashCode();
                    if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                    if (Match != null)
                    hashCode = hashCode * 59 + Match.GetHashCode();
                    if (MatchingAlgorithm != null)
                    hashCode = hashCode * 59 + MatchingAlgorithm.GetHashCode();
                    if (IsInsensitive != null)
                    hashCode = hashCode * 59 + IsInsensitive.GetHashCode();
                    if (DocumentCount != null)
                    hashCode = hashCode * 59 + DocumentCount.GetHashCode();
                    if (LastCorrespondence != null)
                    hashCode = hashCode * 59 + LastCorrespondence.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(Correspondent left, Correspondent right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Correspondent left, Correspondent right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
