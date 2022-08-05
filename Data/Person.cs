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
        public DateTime geboren {get; set;}

        private const int TageimJahr = 365;
        
        //Konstruktor
        public Person()
        {
            this.name= "";
            this.geboren= DateTime.MinValue;
        }  

        public int jahrealt()
        {
            TimeSpan alter = DateTime.Now-this.geboren; 
            //return (DateTime.Now.Year - this.geboren.Year);
            return alter.Days/TageimJahr;
        } 
}


}
