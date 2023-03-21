namespace OnlineTest.Models.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        IEnumerable<User> GetUsersPaginated(int pageNumber,int pageSize);
        bool AddUser(User user);
        User GetUserById(int id);
        User GetUserByEmail(string email);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
    }
}
