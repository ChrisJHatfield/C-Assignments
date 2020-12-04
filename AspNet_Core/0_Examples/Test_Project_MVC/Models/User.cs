using System.ComponentModel.DataAnnotations;
namespace Test_Project_MVC.Models
{
    public class User
    {
//Example: 

        [Required]
        [MinLength(3)]
        [Display(Name = "Your Username:")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Your Email:")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Your Password:")]
        public string Password { get; set; }

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Common DataAnnotations: ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//         Name of DataAnnotation                           Use                                  Parameters
//         Required                     Validates whether the field has a value.                     NA

//         Regular Expression           Validates whether the submitted value                  A regex string.
//                                         conforms to a regex string.

//         MinLength()                  Validates that a string or array field                   An integer.
//                                         has the specified minimum length.

//         MaxLength()                  Validates that a string or array field                   An integer.
//                                         has the specified maximum length.

//         Range()                      Checks whether the value is within the             Two integers or two doubles.
//                                         range specified.                             Must be the same type as the field.

//         EmailAddress                 Validates that the field is in the form                       NA
//                                         of a valid email address.

//         Compare()                    Validates that two fields contain the           A string corresponding to the name of the other field.
//                                         same value. Only needs to be applied         A second parameter consisting of ErrorMessage = and a
//                                         to one of the two fields                     string to be displayed as an error may also be included.

//         DataType()                   Ensures that the field conforms to a                   A DataType object
//                                         specific DataType

// For More Info on DataAnnotations: https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?redirectedfrom=MSDN&view=netcore-3.1
// For More Info on DataType Enumerations: https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.datatype?redirectedfrom=MSDN&view=netcore-3.1


    }
}