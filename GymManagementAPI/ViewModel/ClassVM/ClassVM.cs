namespace GymManagementAPI.ViewModel.ClassVM
{
    public class ClassVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TrainerId { get; set; }
        public string Schedule { get; set; }
        public int MaxMembers { get; set; }
        public int? CurrentMembers { get; set; }
    }

}
