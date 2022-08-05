using System.ComponentModel.DataAnnotations;

namespace Person
{

class Person
    {
        [Required] 
        [StringLength(15,
            ErrorMessage = "Maximal 15 Buchstaben!")] 
        public string name {get; set;}
        
        [Required]
        [Range(typeof(DateTime),"01.01.1900","31.12.2021", ErrorMessage = "Gültig ist 1900 bis 2021!")]  
        public DateTime geboren {get; set;}

        private const int TageimJahr = 365;
        
        //Konstruktor
        public Person()
        {
            this.name= "";
            this.geboren= DateTime.Parse("01.01.2000");
        }  

        public int jahrealt()
        {
            TimeSpan alter = DateTime.Now-this.geboren; 
            //return (DateTime.Now.Year - this.geboren.Year);
            return alter.Days/TageimJahr;
        } 
}


}
