using AutoMapper;
using Meter.Dtos;
using Meter.Models;
using Meter.Requests.Measure;
using Microsoft.EntityFrameworkCore;

namespace Meter.Repositories;

public class MeasureRepository
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public MeasureRepository(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<MeasureDto>> All()
    {
        return _mapper.Map<IEnumerable<MeasureDto>>(await _context.Measures
            .ToListAsync()
        );
    }

    public async Task<MeasureDto> Find(int id)
    {
        return _mapper.Map<MeasureDto>(await _context.Measures
            .FirstOrDefaultAsync(measure => measure.Id == id)
        );
    }

    public async Task<MeasureDto> Create(MeasureCreateRequest request)
    {
        var measure = await _context.Measures.AddAsync(_mapper.Map<Measure>(request));
        await _context.SaveChangesAsync();
        return _mapper.Map<MeasureDto>(measure.Entity);
    }
    
    public async Task<MeasureDto> Edit(int id, MeasureUpdateRequest request)
    {
        var measure = await _context.Measures.FindAsync(id);
        _mapper.Map(request, measure);
        await _context.SaveChangesAsync();

        return _mapper.Map<MeasureDto>(measure);
    }
    
    public async Task Delete(int id)
    {
        var measure = await _context.Measures.FindAsync(id);
        _context.Measures.Remove(measure);    // TODO
        await _context.SaveChangesAsync();
    }
}