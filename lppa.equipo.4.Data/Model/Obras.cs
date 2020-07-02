
namespace lppa.equipo._4.Data.Model
{
    public class Obras : IdentityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ArtistId { get; set; }
        private string _image = "~/Content/img/";
        public string Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = _image + value;
            }
        }
        public double Price { get; set; }
        public int QuantitySold { get; set; }
        public double AvgStars { get; set; }

        public virtual Artist Artist { get; set; }
    }
}
