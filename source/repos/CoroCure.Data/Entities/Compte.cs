namespace CoroCure.Data.Entities
{
    public class Compte
    {
        //[Key]
        public string Username { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; }
        public int CIN { get; set; }
        //[ForeignKey("cin")]
        public Cardiologue Cardiologue { get; set; }
    }
}
