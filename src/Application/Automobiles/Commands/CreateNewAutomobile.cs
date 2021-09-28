using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Automobiles.Dtos;
using Application.Common.Interfaces;
using MediatR;
using Newtonsoft.Json;

namespace Application.Automobiles.Commands
{
    public class CreateNewAutomobile : IRequest<NewAutomobileDto>
    {
        [JsonProperty("manufacturer")]
        public string Manufacturer { get; set; }
        [JsonProperty("model")]
        public string Model { get; set; }
        [JsonProperty("color")]
        public string Color { get; set; }
    }

    public class CreateNewAutomobileHandler : IRequestHandler<CreateNewAutomobile, NewAutomobileDto>
    {
        private readonly IAutomobileContext _db;

        public CreateNewAutomobileHandler(IAutomobileContext automobileContext)
        {
            _db = automobileContext ?? throw new ArgumentNullException(nameof(automobileContext));
        }

        public async Task<NewAutomobileDto> Handle(CreateNewAutomobile request, CancellationToken cancellationToken)
        {
            using (var trans = await _db.BeginTransactionAsync())
            {
                try
                {
                    var a = new Domain.Entities.Automobile
                    {
                        Id = 1,
                        Color = request.Color,
                        Manufacturer = request.Manufacturer,
                        Model = request.Model
                    };

                    _db.Automobiles.Add(a);
                    await _db.SaveChangesAsync(cancellationToken);
                    await _db.CommitTransactions(trans);
                    return new NewAutomobileDto { Id = a.Id };
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }
        }
    }
}
