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
    public partial class DocumentsPostDocumentBody : IEquatable<DocumentsPostDocumentBody>
    { 
        /// <summary>
        /// Gets or Sets Title
        /// </summary>

        [DataMember(Name="title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets Created
        /// </summary>

        [DataMember(Name="created")]
        public DateTime? Created { get; set; }

        /// <summary>
        /// Gets or Sets DocumentType
        /// </summary>

        [DataMember(Name="document_type")]
        public int? DocumentType { get; set; }

        /// <summary>
        /// Gets or Sets Tags
        /// </summary>

        [DataMember(Name="tags")]
        public List<int?> Tags { get; set; }

        /// <summary>
        /// Gets or Sets Correspondent
        /// </summary>

        [DataMember(Name="correspondent")]
        public int? Correspondent { get; set; }

        /// <summary>
        /// Gets or Sets Document
        /// </summary>

        [DataMember(Name="document")]
        public List<byte[]> Document { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DocumentsPostDocumentBody {\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  Created: ").Append(Created).Append("\n");
            sb.Append("  DocumentType: ").Append(DocumentType).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  Correspondent: ").Append(Correspondent).Append("\n");
            sb.Append("  Document: ").Append(Document).Append("\n");
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
            return obj.GetType() == GetType() && Equals((DocumentsPostDocumentBody)obj);
        }

        /// <summary>
        /// Returns true if DocumentsPostDocumentBody instances are equal
        /// </summary>
        /// <param name="other">Instance of DocumentsPostDocumentBody to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DocumentsPostDocumentBody other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Title == other.Title ||
                    Title != null &&
                    Title.Equals(other.Title)
                ) && 
                (
                    Created == other.Created ||
                    Created != null &&
                    Created.Equals(other.Created)
                ) && 
                (
                    DocumentType == other.DocumentType ||
                    DocumentType != null &&
                    DocumentType.Equals(other.DocumentType)
                ) && 
                (
                    Tags == other.Tags ||
                    Tags != null &&
                    Tags.SequenceEqual(other.Tags)
                ) && 
                (
                    Correspondent == other.Correspondent ||
                    Correspondent != null &&
                    Correspondent.Equals(other.Correspondent)
                ) && 
                (
                    Document == other.Document ||
                    Document != null &&
                    Document.SequenceEqual(other.Document)
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
                    if (Title != null)
                    hashCode = hashCode * 59 + Title.GetHashCode();
                    if (Created != null)
                    hashCode = hashCode * 59 + Created.GetHashCode();
                    if (DocumentType != null)
                    hashCode = hashCode * 59 + DocumentType.GetHashCode();
                    if (Tags != null)
                    hashCode = hashCode * 59 + Tags.GetHashCode();
                    if (Correspondent != null)
                    hashCode = hashCode * 59 + Correspondent.GetHashCode();
                    if (Document != null)
                    hashCode = hashCode * 59 + Document.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(DocumentsPostDocumentBody left, DocumentsPostDocumentBody right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(DocumentsPostDocumentBody left, DocumentsPostDocumentBody right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
