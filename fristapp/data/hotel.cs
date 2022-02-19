using System.ComponentModel.DataAnnotations.Schema;

namespace fristapp.data
{
    public class hotel
      

    {
        public  int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public double Rating { get; set; }
      [ForeignKey(nameof(country))]
        public  int countryid { get; set; }
       public country country { get; set; }
            }
}
