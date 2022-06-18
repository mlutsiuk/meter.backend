using AutoMapper;
// using Meter.Dtos;
using Meter.Dtos.Dashboard;
using Meter.Models;
using Microsoft.EntityFrameworkCore;
using CounterDto = Meter.Dtos.Dashboard.CounterDto;

namespace Meter.Repositories;

public class DashboardRepository
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public DashboardRepository(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MyGroupsDto>> My(int ownerId)
    {
        return await _context
            .Groups
            .Where(g => g.OwnerId.Equals(ownerId))
            .Select(g => new MyGroupsDto
            {
                Id = g.Id,
                Title = g.Title,
                OwnerId = g.OwnerId,
                Counters = g.Counters
                    .Select(c => new CounterDto
                    {
                        Id = c.Id,
                        Color = c.Color,
                        Title = c.Title,
                        GroupId = c.GroupId,
                        IconId = c.IconId,
                        LastMeasure = c.Measures.Select(m => new LastMeasureDto
                            {
                                Id = m.Id,
                                Date = m.Date,
                                Value = m.Value,
                                CounterId = m.CounterId
                            }).OrderByDescending(m => m.Date).FirstOrDefault()
                        
                    }).ToList()
            })
            .ToListAsync();
    }
}