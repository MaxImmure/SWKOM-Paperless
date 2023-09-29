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
    public partial class InlineResponse2002Results : IEquatable<InlineResponse2002Results>
    { 
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [Required]

        [DataMember(Name="id")]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or Sets Correspondent
        /// </summary>
        [Required]

        [DataMember(Name="correspondent")]
        public int? Correspondent { get; set; }

        /// <summary>
        /// Gets or Sets DocumentType
        /// </summary>
        [Required]

        [DataMember(Name="document_type")]
        public int? DocumentType { get; set; }

        /// <summary>
        /// Gets or Sets StoragePath
        /// </summary>
        [Required]

        [DataMember(Name="storage_path")]
        public int? StoragePath { get; set; }

        /// <summary>
        /// Gets or Sets Title
        /// </summary>
        [Required]

        [DataMember(Name="title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets Content
        /// </summary>
        [Required]

        [DataMember(Name="content")]
        public string Content { get; set; }

        /// <summary>
        /// Gets or Sets Tags
        /// </summary>
        [Required]

        [DataMember(Name="tags")]
        public List<int?> Tags { get; set; }

        /// <summary>
        /// Gets or Sets Created
        /// </summary>
        [Required]

        [DataMember(Name="created")]
        public string Created { get; set; }

        /// <summary>
        /// Gets or Sets CreatedDate
        /// </summary>
        [Required]

        [DataMember(Name="created_date")]
        public string CreatedDate { get; set; }

        /// <summary>
        /// Gets or Sets Modified
        /// </summary>
        [Required]

        [DataMember(Name="modified")]
        public string Modified { get; set; }

        /// <summary>
        /// Gets or Sets Added
        /// </summary>
        [Required]

        [DataMember(Name="added")]
        public string Added { get; set; }

        /// <summary>
        /// Gets or Sets ArchiveSerialNumber
        /// </summary>
        [Required]

        [DataMember(Name="archive_serial_number")]
        public int? ArchiveSerialNumber { get; set; }

        /// <summary>
        /// Gets or Sets OriginalFileName
        /// </summary>
        [Required]

        [DataMember(Name="original_file_name")]
        public string OriginalFileName { get; set; }

        /// <summary>
        /// Gets or Sets ArchivedFileName
        /// </summary>
        [Required]

        [DataMember(Name="archived_file_name")]
        public string ArchivedFileName { get; set; }

        /// <summary>
        /// Gets or Sets Owner
        /// </summary>
        [Required]

        [DataMember(Name="owner")]
        public int? Owner { get; set; }

        /// <summary>
        /// Gets or Sets UserCanChange
        /// </summary>
        [Required]

        [DataMember(Name="user_can_change")]
        public bool? UserCanChange { get; set; }

        /// <summary>
        /// Gets or Sets Notes
        /// </summary>
        [Required]

        [DataMember(Name="notes")]
        public List<InlineResponse2002Notes> Notes { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class InlineResponse2002Results {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Correspondent: ").Append(Correspondent).Append("\n");
            sb.Append("  DocumentType: ").Append(DocumentType).Append("\n");
            sb.Append("  StoragePath: ").Append(StoragePath).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  Content: ").Append(Content).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  Created: ").Append(Created).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  Modified: ").Append(Modified).Append("\n");
            sb.Append("  Added: ").Append(Added).Append("\n");
            sb.Append("  ArchiveSerialNumber: ").Append(ArchiveSerialNumber).Append("\n");
            sb.Append("  OriginalFileName: ").Append(OriginalFileName).Append("\n");
            sb.Append("  ArchivedFileName: ").Append(ArchivedFileName).Append("\n");
            sb.Append("  Owner: ").Append(Owner).Append("\n");
            sb.Append("  UserCanChange: ").Append(UserCanChange).Append("\n");
            sb.Append("  Notes: ").Append(Notes).Append("\n");
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
            return obj.GetType() == GetType() && Equals((InlineResponse2002Results)obj);
        }

        /// <summary>
        /// Returns true if InlineResponse2002Results instances are equal
        /// </summary>
        /// <param name="other">Instance of InlineResponse2002Results to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InlineResponse2002Results other)
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
                    Correspondent == other.Correspondent ||
                    Correspondent != null &&
                    Correspondent.Equals(other.Correspondent)
                ) && 
                (
                    DocumentType == other.DocumentType ||
                    DocumentType != null &&
                    DocumentType.Equals(other.DocumentType)
                ) && 
                (
                    StoragePath == other.StoragePath ||
                    StoragePath != null &&
                    StoragePath.Equals(other.StoragePath)
                ) && 
                (
                    Title == other.Title ||
                    Title != null &&
                    Title.Equals(other.Title)
                ) && 
                (
                    Content == other.Content ||
                    Content != null &&
                    Content.Equals(other.Content)
                ) && 
                (
                    Tags == other.Tags ||
                    Tags != null &&
                    Tags.SequenceEqual(other.Tags)
                ) && 
                (
                    Created == other.Created ||
                    Created != null &&
                    Created.Equals(other.Created)
                ) && 
                (
                    CreatedDate == other.CreatedDate ||
                    CreatedDate != null &&
                    CreatedDate.Equals(other.CreatedDate)
                ) && 
                (
                    Modified == other.Modified ||
                    Modified != null &&
                    Modified.Equals(other.Modified)
                ) && 
                (
                    Added == other.Added ||
                    Added != null &&
                    Added.Equals(other.Added)
                ) && 
                (
                    ArchiveSerialNumber == other.ArchiveSerialNumber ||
                    ArchiveSerialNumber != null &&
                    ArchiveSerialNumber.Equals(other.ArchiveSerialNumber)
                ) && 
                (
                    OriginalFileName == other.OriginalFileName ||
                    OriginalFileName != null &&
                    OriginalFileName.Equals(other.OriginalFileName)
                ) && 
                (
                    ArchivedFileName == other.ArchivedFileName ||
                    ArchivedFileName != null &&
                    ArchivedFileName.Equals(other.ArchivedFileName)
                ) && 
                (
                    Owner == other.Owner ||
                    Owner != null &&
                    Owner.Equals(other.Owner)
                ) && 
                (
                    UserCanChange == other.UserCanChange ||
                    UserCanChange != null &&
                    UserCanChange.Equals(other.UserCanChange)
                ) && 
                (
                    Notes == other.Notes ||
                    Notes != null &&
                    Notes.SequenceEqual(other.Notes)
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
                    if (Correspondent != null)
                    hashCode = hashCode * 59 + Correspondent.GetHashCode();
                    if (DocumentType != null)
                    hashCode = hashCode * 59 + DocumentType.GetHashCode();
                    if (StoragePath != null)
                    hashCode = hashCode * 59 + StoragePath.GetHashCode();
                    if (Title != null)
                    hashCode = hashCode * 59 + Title.GetHashCode();
                    if (Content != null)
                    hashCode = hashCode * 59 + Content.GetHashCode();
                    if (Tags != null)
                    hashCode = hashCode * 59 + Tags.GetHashCode();
                    if (Created != null)
                    hashCode = hashCode * 59 + Created.GetHashCode();
                    if (CreatedDate != null)
                    hashCode = hashCode * 59 + CreatedDate.GetHashCode();
                    if (Modified != null)
                    hashCode = hashCode * 59 + Modified.GetHashCode();
                    if (Added != null)
                    hashCode = hashCode * 59 + Added.GetHashCode();
                    if (ArchiveSerialNumber != null)
                    hashCode = hashCode * 59 + ArchiveSerialNumber.GetHashCode();
                    if (OriginalFileName != null)
                    hashCode = hashCode * 59 + OriginalFileName.GetHashCode();
                    if (ArchivedFileName != null)
                    hashCode = hashCode * 59 + ArchivedFileName.GetHashCode();
                    if (Owner != null)
                    hashCode = hashCode * 59 + Owner.GetHashCode();
                    if (UserCanChange != null)
                    hashCode = hashCode * 59 + UserCanChange.GetHashCode();
                    if (Notes != null)
                    hashCode = hashCode * 59 + Notes.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(InlineResponse2002Results left, InlineResponse2002Results right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(InlineResponse2002Results left, InlineResponse2002Results right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
