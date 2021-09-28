using Application.Automobiles.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.Threading;
using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Automobiles.Queries
{
    public class GetAllAutomobiles : IRequest<List<AutomobileSummaryDto>>
    {
    }

    public class GetAllAutomobilesHandler : IRequestHandler<GetAllAutomobiles, List<AutomobileSummaryDto>>
    {
        private readonly IAutomobileContext _db;

        public GetAllAutomobilesHandler(IAutomobileContext automobileContext)
        {
            _db = automobileContext ?? throw new ArgumentNullException(nameof(automobileContext));
        }

        public async Task<List<AutomobileSummaryDto>> Handle(GetAllAutomobiles request, CancellationToken cancellationToken)
        {
            List<AutomobileSummaryDto> output = new List<AutomobileSummaryDto>();

            var results = await _db.Automobiles
                .AsNoTracking()
                .ToListAsync();

            //
            // Can use AutoMapper to convert from Domain entity to User entity
            return results.Select(i => new AutomobileSummaryDto
            {
                Id = i.Id,
                Manufacturer = i.Manufacturer,
                Model = i.Model
            }).ToList();
        }
    }
}
