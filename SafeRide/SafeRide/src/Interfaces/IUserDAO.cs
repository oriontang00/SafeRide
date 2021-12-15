using SafeRide.src.Models;

namespace SafeRide.src.Interfaces
{
    public interface IUserDAO
    {
        public bool Create(User User);
        public User Read(String UserId);
        public bool Update(String UserId, User User);
        public bool Delete(String UserId);
        public bool Enable(String UserId);
        public bool Disable(String UserId);

        public List<bool> BulkOp(String path);
    }
}
