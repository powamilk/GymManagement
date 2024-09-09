namespace GymManagementAPI.ViewModel.MemberVM
{
    public class MemberVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string MembershipType { get; set; }
        public DateTime JoinDate { get; set; }
    }
}
