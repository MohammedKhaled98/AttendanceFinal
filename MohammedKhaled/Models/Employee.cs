using System.ComponentModel.DataAnnotations;

namespace MohammedKhaled.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }   
        [Required]
        public string Name { get; set; }  //Name of Employee
        [Required]
        public string Password { get; set; }  //Password to login
        public string Postion { get; set; }  
        [Required]
        public bool admin { get; set; }    // indicates weather if its admin or not 

        public int State { get; set; } = 0;    //This will updated daily , indicat the attendance {eg. 1=Late , 2=absent} 
        public int atID { get; set; } = 0;    //to link with ID of attendace , updated daily



        public Employee()
        {

        }
    }
}
