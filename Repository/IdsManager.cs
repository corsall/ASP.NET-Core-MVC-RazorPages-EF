using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using lab.Contracts;
using lab.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace lab.Repository;

public class IdsManager : IidsManager
{
    private readonly restaurantsContext _context;

    public IdsManager(restaurantsContext context)
    {
        _context = context;
    }

    public async Task<Dictionary<string, List<string>>> GetAllIds()
    {
        var dict = new Dictionary<string, List<string>>();

        var idValues = await _context.VmistZamovlenies.Select(x => x.Id.ToString()).ToListAsync();
        dict.Add("id", idValues);

        idValues = await _context.DovidnykClientivs.Select(x => x.Kodkl.ToString()).ToListAsync();
        dict.Add("kodkl", idValues);

        idValues = await _context.DovidnykDostavkis.Select(x => x.Koddos.ToString()).ToListAsync();
        dict.Add("koddos", idValues);

        idValues = await _context.DovidnykProdukciis.Select(x => x.Kodpr.ToString()).ToListAsync();
        dict.Add("kodpr", idValues);

        idValues = await _context.ZamovlenyaProductciis.Select(x => x.Nz.ToString()).ToListAsync();
        dict.Add("nz", idValues);

        return dict;
    }
}
