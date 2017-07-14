
namespace LigaFutbolu.Models
{

    public enum Grade
    {
        TOPLIGA, PLFA1, PLFA2
    }


    public class Liga
    {
        public int LigaId { get; set; }
        public int IdZawodnik { get; set; }
        public int IdDruzyny { get; set; }
        public Grade? Grade { get; set; }
        public Zawodnik Zawodnik { get; set; }
        public DruzynyModel DruzynyModel { get; set; }
    }
}