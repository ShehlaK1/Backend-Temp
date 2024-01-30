using Common.DTOs;
using Common.Model;
using ORM.DatabaseContext;

namespace RESTCore.Services
{
    public class UserService
    {
        private readonly AppDbContext _appDbContext;
        
        public UserService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<UserDTO> GetAll()
        {
            List<UserDTO> userDTOs = _appDbContext.Users.Select(x => new UserDTO
            {
                Id=x.Id,
                Name = x.Name,
                Password = x.Password,
                Email = x.Email,
                Info = x.Info
            }).ToList();

            return userDTOs;
        }

        public UserDTO GetById(string id)
        {
            User user = _appDbContext.Users.Where(x =>
            x.Id == id).FirstOrDefault();
            return new UserDTO
            {
                Id = user.Id.ToString(),
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Info = user.Info

            };
        }

        public bool Create(UserDTO userDTO) 
        {
            _appDbContext.Users.Add(new User
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
                Password=userDTO.Password,
                Info = userDTO.Info
            });
            _appDbContext.SaveChanges();
            return true;
        }

        public bool Delete(string id) 
        {
            User user = _appDbContext.Users.Where(x =>
           x.Id == id).FirstOrDefault();
            if(user == null)
            {
                return false;
            }
            _appDbContext.Remove(user);
            _appDbContext.SaveChanges();
            return true;
        }
    }
}
