using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class MaxWordsAttribute : ValidationAttribute
    { 
        public MaxWordsAttribute(int maxWords) : base("{0} has too many words.")
        {
            _maxWords = maxWords;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var valueAsString = value.ToString();
                if(valueAsString.Split(' ').Length >_maxWords)
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }
            return ValidationResult.Success;
        }

        private readonly int _maxWords;
    }
    public class Review : IValidatableObject
    {
       
        public int Id { get; set; }
        //public string Name { get; set; }
        //public string City { get; set; }
        //public string Country { get; set; }
        //rating gange from 1 to 5
        [Range(1,5)]
        [Required]
        public float Rating { get; set; }


        //a cuctom message for error
        [Required(ErrorMessageResourceType =typeof(Restaurant.Views.Home.Resources), ErrorMessageResourceName = "ErMes")]
        //length of body is less then 900 characters
        [StringLength(900)]
        //and update db  update-database -Verbose -force
        public string Body { get; set; }

        [Display(Name = "User Name")]
        //if a user forfot to specipy a name
        [DisplayFormat(NullDisplayText = "anonymous")]
        //custom validation attribute
        [MaxWords(2)]
        public string ReviewerName { get; set; }
        public int RestaurantId { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            if (Rating < 2 && ReviewerName == "Joe") {
                yield return new ValidationResult("You are not allowed to make changes");
            }
        }
    }
}