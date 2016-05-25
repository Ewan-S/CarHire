namespace CarHire.Models.User_Classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    using Microsoft.Owin.Security.Facebook;

    public class Address
    {
        public Address()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AddressID { get; set; }

        public virtual ICollection<Guid> MemberIDs { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Address line 1")]
        public string Line1 { get; set; }

        [Display(Name = "Address line 2")]
        [DataType(DataType.Text)]
        public string Line2 { get; set; }

        [Display(Name = "Address line 3")]
        [DataType(DataType.Text)]
        public string Line3 { get; set; }

        [Display(Name = "Town")]
        [DataType(DataType.Text)]
        public string Town { get; set; }

        [Required]
        [Display(Name = "City")]
        [DataType(DataType.Text)]
        public string City { get; set; }


        [Display(Name = "County")]
        [DataType(DataType.Text)]
        public string County { get; set; }

        [Required]
        [Display(Name = "Country")]
        [DataType(DataType.Text)]
        public string Country { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Postcode")]
        public string Postcode { get; set; }

        public string GetCompleteAddresss()
        {
            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(this.Line1))
            {
                sb.Append(this.Line1);
                sb.Append(", ");
            }

            if (!string.IsNullOrWhiteSpace(this.Line2))
            {
                sb.Append(this.Line2);
                sb.Append(", ");
            }

            if (!string.IsNullOrWhiteSpace(this.Line3))
            {
                sb.Append(this.Line3);
                sb.Append(", ");
            }

            if (!string.IsNullOrWhiteSpace(this.Town))
            {
                sb.Append(this.Town);
                sb.Append(", ");
            }

            if (!string.IsNullOrWhiteSpace(this.City))
            {
                sb.Append(this.City);
                sb.Append(", ");
            }

            if (!string.IsNullOrWhiteSpace(this.County))
            {
                sb.Append(this.County);
                sb.Append(", ");
            }

            if (!string.IsNullOrWhiteSpace(this.Postcode))
            {
                sb.Append(this.Postcode);
                sb.Append(", ");
            }

            if (!string.IsNullOrWhiteSpace(this.Country))
            {
                sb.Append(this.Country);
                //should always be prestent, hopefully no outlying commas
            }

            return sb.ToString();
        }
    }
}