using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Student_Data.Models
{
    public class Registration
    {
        
         [Key]
        public int id { get; set; }
        [Required(ErrorMessage="Enter student name.")]
        public string First_Name { get; set; }
        [Required(ErrorMessage = "Enter student surname.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Enter student gender.")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Enter student Date_of_Birth.")]
        [DataType(DataType.Date)]
        public string Date_of_Birth { get; set; }
        [Required(ErrorMessage = "Enter student Address.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Enter student Subjects.")]
        public string Subjects { get; set; }
    }
}
