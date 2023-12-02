namespace FinalFN.Data
{
    public class Skin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string WeaponName { get; set; }
        public string RarityName { get; set; }
        public string PictureUrl { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }


}
