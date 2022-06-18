using AutoMapper;
using Meter.Dtos;
using Meter.Models;
using Meter.Requests.Counter;
using Microsoft.EntityFrameworkCore;

namespace Meter.Repositories;

public class CounterRepository
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CounterRepository(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<CounterDto>> All()
    {
        return _mapper.Map<IEnumerable<CounterDto>>(await _context.Counters
            .ToListAsync()
        );
    }

    public async Task<CounterDto> Find(int id)
    {
        return _mapper.Map<CounterDto>(await _context.Counters
            .Include(c => c.Group)
                .ThenInclude(g => g.Owner)
            .FirstOrDefaultAsync(counter => counter.Id == id)
        );
    }

    public async Task<CounterDto> Create(CounterCreateRequest request)
    {
        var counter = await _context.Counters.AddAsync(_mapper.Map<Counter>(request));
        await _context.SaveChangesAsync();
        return _mapper.Map<CounterDto>(counter.Entity);
    }
    
    public async Task<CounterDto> Edit(int id, CounterUpdateRequest request)
    {
        var counter = await _context.Counters.FindAsync(id);
        _mapper.Map(request, counter);
        await _context.SaveChangesAsync();

        return _mapper.Map<CounterDto>(counter);
    }
    
    public async Task Delete(int id)
    {
        var counter = await _context.Counters.FindAsync(id);
        _context.Counters.Remove(counter);    // TODO
        await _context.SaveChangesAsync();
    }
}