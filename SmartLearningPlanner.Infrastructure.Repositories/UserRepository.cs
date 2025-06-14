using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartLearningPlanner.Domain.Entities;
using SmartLearningPlanner.Domain.Interfaces.Repositories;
using SmartLearningPlanner.Infrastructure.EntityFramework;

namespace SmartLearningPlanner.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public UserRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<ApplicationUser> GetByIdAsync(string id)
    {
        return await _context.Users.FindAsync(id);
    }
    public async Task<IEnumerable<ApplicationUser>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<string> AddAsync(ApplicationUser user, string password)
    {
        var result = await _userManager.CreateAsync(user, password);
        if (!result.Succeeded)
        {
            throw new Exception($"Failed to create user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }
        return await _userManager.GenerateEmailConfirmationTokenAsync(user);
    }

    public async Task UpdateAsync(ApplicationUser user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
    public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
    {
        return await _userManager.CheckPasswordAsync(user, password);
    }

    public async Task ChangePasswordAsync(ApplicationUser user, string currentPassword, string newPassword)
    {
        var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        if (!result.Succeeded)
        {
            throw new Exception($"Failed to change password: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }
    }
    public async Task ConfirmEmailAsync(string id, string token)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user != null)
        {
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (!result.Succeeded)
                throw new Exception($"Email confirmation failed: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }

    }
    public async Task<ApplicationUser> GetByEmailAsync(string email)
    {
        return await _userManager.FindByEmailAsync(email);
    }

    public async Task<bool> IsEmailConfirmedAsync(ApplicationUser user)
    {
        return await _userManager.IsEmailConfirmedAsync(user);
    }

    public async Task<bool> AuthenticateAsync(ApplicationUser user, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
        return result.Succeeded;
    }

}