
using Marketplace.Infrustructure.Presentation;
using Microsoft.EntityFrameworkCore;
using Marketplace.Domain.Entities;
using Marketplace.Infrustructure.Model.Services;

public class UserService : IUserService
{
    private readonly UserRepository _userRepository;
    private readonly ItemRepository _itemRepository;

    public UserService(UserRepository userRepository, ItemRepository itemRepository)
    {
        _userRepository = userRepository;
        _itemRepository = itemRepository;
    }

    public async Task<User?> GetUserWithItemsAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _userRepository.GetByIdWithItemAsync(id);
    }

    public async Task<int> CreateUserAsync(User user, CancellationToken cancellationToken = default)
    {
        await _userRepository.AddAsync(user);
        await _userRepository.SaveAsync();
        return user.UserId;
    }

    public async Task AddItemToUserAsync(int userId, Item item, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdWithItemAsync(userId, cancellationToken) 
            ?? throw new InvalidOperationException("User not found");
        if (item.Id != Guid.Empty)
        {
            var existing = await _itemRepository.GetByIdAsync(item.Id, cancellationToken);
            if (existing == null)
            {
                user.Items.Add(existing);
            }
            else
            {
                user.Items.Add(item);
                await _itemRepository.AddItemAsync(item,cancellationToken);
            }
        }
        else
        {
            user.Items.Add(item);
            await _itemRepository.AddItemAsync(item, cancellationToken);
        }

        await _userRepository.SaveAsync(cancellationToken);
    }
}