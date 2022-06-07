using AutoMapper;
using Meter.Dtos;
using Meter.Models;
using Meter.Requests.Icon;
using Microsoft.EntityFrameworkCore;

namespace Meter.Repositories;

public class IconRepository
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public IconRepository(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<IconDto>> All()
    {
        return _mapper.Map<IEnumerable<IconDto>>(await _context.Icons
            .ToListAsync()
        );
    }

    public async Task<IconDto> Find(int id)
    {
        return _mapper.Map<IconDto>(await _context.Icons
            .FirstOrDefaultAsync(icon => icon.Id == id)
        );
    }

    public async Task<IconDto> Create(IconCreateRequest request)
    {
        var icon = await _context.Icons.AddAsync(_mapper.Map<Icon>(request));
        await _context.SaveChangesAsync();
        return _mapper.Map<IconDto>(icon.Entity);
    }
    
    public async Task<IconDto> Edit(int id, IconUpdateRequest request)
    {
        var icon = await _context.Icons.FindAsync(id);
        _mapper.Map(request, icon);
        await _context.SaveChangesAsync();

        return _mapper.Map<IconDto>(icon);
    }
    
    public async Task Delete(int id)
    {
        var icon = await _context.Icons.FindAsync(id);
        _context.Icons.Remove(icon);    // TODO
        await _context.SaveChangesAsync();
    }
}