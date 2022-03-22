using System.ComponentModel.DataAnnotations;

namespace MohammedKhaled.Models
{
    public class attend
    {
        public DateTime Tnow { get; set; } = DateTime.Now;
        public DateTime Tin { get; set; }     // time of check in 
        public DateTime Tout { get; set; }    // time of check out


        [Key]
        public int AId { get; set; }   

        public int EmpId { get; set; }  // To link with employee
        public string Name { get; set; }  // name of employee
        public bool CheckIn { get; set; }   // 1=check in  
        public bool CheckOut { get; set; }



        public string InState { get; set; }  // weather absent ? late ? on time 
        public string outState { get; set; } = "s"; // weather absent ? early? on time 

        public string InReason { get; set; }   // the reason if its late
        public string OutReason { get; set; } = "s";  // the reason if its out before 3:00pm

        public int WHours { get; set; } = 0; 


        public attend()
        {

        }
    }
}
