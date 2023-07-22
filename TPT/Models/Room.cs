namespace TPT.Models
{
	public class Room
	{
        public int RoomId { get; set; }

        public string Name { get; set; }    

        public virtual ICollection<Teacher>? Teachers { get; set; } = new HashSet<Teacher>();
    }
}
