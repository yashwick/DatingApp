using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserRepository(DataContext context, IMapper mapper)//since this uses our database we need to inject the dbContext 
        {
            _mapper = mapper;
            _context = context;
        }

        // public async Task<MemberDto> GetMemberAsync(string username)
        // {//When the auto mapper is not in use we used to map all the things manually as below
        //     return await _context.Users
        //        .Where(x => x.UserName == username)
        //        .Select(user => new MemberDto
        //        {
        //            Id = user.Id,
        //            Username = user.UserName
        //        }).SingleOrDefaultAsync();
        // }
        public async Task<MemberDto> GetMemberAsync(string username)
        {
            return await _context.Users
               .Where(x => x.UserName == username)
               .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
               .SingleOrDefaultAsync();
        }

        public Task<IEnumerable<MemberDto>> GetMembersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await _context.Users
            .Include(p => p.Photos)
            .SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await _context.Users
            .Include(p => p.Photos)//Eager loading
            .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(AppUser user)
        {
            _context.Entry(user).State = EntityState.Modified;//adding a flag
        }

        Task<MemberDto> IUserRepository.GetMemberAsync()
        {
            throw new NotImplementedException();
        }
    }
}