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
    public partial class ApiUsersBody : IEquatable<ApiUsersBody>
    { 
        /// <summary>
        /// Gets or Sets Username
        /// </summary>
        [Required]

        [DataMember(Name="username")]
        public string Username { get; set; }

        /// <summary>
        /// Gets or Sets Email
        /// </summary>
        [Required]

        [DataMember(Name="email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or Sets Password
        /// </summary>
        [Required]

        [DataMember(Name="password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or Sets FirstName
        /// </summary>
        [Required]

        [DataMember(Name="first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or Sets LastName
        /// </summary>
        [Required]

        [DataMember(Name="last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or Sets IsActive
        /// </summary>
        [Required]

        [DataMember(Name="is_active")]
        public bool? IsActive { get; set; }

        /// <summary>
        /// Gets or Sets IsSuperuser
        /// </summary>
        [Required]

        [DataMember(Name="is_superuser")]
        public bool? IsSuperuser { get; set; }

        /// <summary>
        /// Gets or Sets Groups
        /// </summary>
        [Required]

        [DataMember(Name="groups")]
        public List<Object> Groups { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ApiUsersBody {\n");
            sb.Append("  Username: ").Append(Username).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  Password: ").Append(Password).Append("\n");
            sb.Append("  FirstName: ").Append(FirstName).Append("\n");
            sb.Append("  LastName: ").Append(LastName).Append("\n");
            sb.Append("  IsActive: ").Append(IsActive).Append("\n");
            sb.Append("  IsSuperuser: ").Append(IsSuperuser).Append("\n");
            sb.Append("  Groups: ").Append(Groups).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ApiUsersBody)obj);
        }

        /// <summary>
        /// Returns true if ApiUsersBody instances are equal
        /// </summary>
        /// <param name="other">Instance of ApiUsersBody to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ApiUsersBody other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Username == other.Username ||
                    Username != null &&
                    Username.Equals(other.Username)
                ) && 
                (
                    Email == other.Email ||
                    Email != null &&
                    Email.Equals(other.Email)
                ) && 
                (
                    Password == other.Password ||
                    Password != null &&
                    Password.Equals(other.Password)
                ) && 
                (
                    FirstName == other.FirstName ||
                    FirstName != null &&
                    FirstName.Equals(other.FirstName)
                ) && 
                (
                    LastName == other.LastName ||
                    LastName != null &&
                    LastName.Equals(other.LastName)
                ) && 
                (
                    IsActive == other.IsActive ||
                    IsActive != null &&
                    IsActive.Equals(other.IsActive)
                ) && 
                (
                    IsSuperuser == other.IsSuperuser ||
                    IsSuperuser != null &&
                    IsSuperuser.Equals(other.IsSuperuser)
                ) && 
                (
                    Groups == other.Groups ||
                    Groups != null &&
                    Groups.SequenceEqual(other.Groups)
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
                    if (Username != null)
                    hashCode = hashCode * 59 + Username.GetHashCode();
                    if (Email != null)
                    hashCode = hashCode * 59 + Email.GetHashCode();
                    if (Password != null)
                    hashCode = hashCode * 59 + Password.GetHashCode();
                    if (FirstName != null)
                    hashCode = hashCode * 59 + FirstName.GetHashCode();
                    if (LastName != null)
                    hashCode = hashCode * 59 + LastName.GetHashCode();
                    if (IsActive != null)
                    hashCode = hashCode * 59 + IsActive.GetHashCode();
                    if (IsSuperuser != null)
                    hashCode = hashCode * 59 + IsSuperuser.GetHashCode();
                    if (Groups != null)
                    hashCode = hashCode * 59 + Groups.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(ApiUsersBody left, ApiUsersBody right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ApiUsersBody left, ApiUsersBody right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
