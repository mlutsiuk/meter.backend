﻿using AutoMapper;
using Meter.Dtos;
using Meter.Models;
using Meter.Requests.Group;
using Microsoft.EntityFrameworkCore;

namespace Meter.Repositories;

public class GroupRepository
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public GroupRepository(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GroupDto>> All()
    {
        return _mapper.Map<IEnumerable<GroupDto>>(await _context.Groups
            .ToListAsync()
        );
    }

    public async Task<GroupDto> Find(int id)
    {
        return _mapper.Map<GroupDto>(await _context.Groups
            .FirstOrDefaultAsync(group => group.Id == id)
        );
    }

    public async Task<GroupDto> Create(GroupCreateRequest request, int userId)
    {
        var groupDraft = _mapper.Map<Group>(request);
        groupDraft.OwnerId = userId;
        
        var group = await _context.Groups.AddAsync(groupDraft);
        await _context.SaveChangesAsync();
        return _mapper.Map<GroupDto>(group.Entity);
    }
    
    public async Task<GroupDto> Edit(int id, GroupUpdateRequest request)
    {
        var group = await _context.Groups.FindAsync(id);
        _mapper.Map(request, group);
        await _context.SaveChangesAsync();

        return _mapper.Map<GroupDto>(group);
    }
    
    public async Task Delete(int id)
    {
        var group = await _context.Groups.FindAsync(id);
        _context.Groups.Remove(group);    // TODO
        await _context.SaveChangesAsync();
    }
}