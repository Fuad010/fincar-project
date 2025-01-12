using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Application.Cars.Queries.GetCarDetails
{
    public class GetCarDetailsQueryHandler
           : IRequestHandler<GetCarDetailsQuery, CarDetailsVm>
    {
        private readonly IAppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCarDetailsQueryHandler(IAppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CarDetailsVm> Handle(GetCarDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Cars
                .Include(car => car.Brand)
                .Include(car => car.CarColor)
                .Include(car => car.Box)
                .Include(car => car.SteeringWheel)
                .Include(car => car.Body)
                .Include(car => car.Images)
                .FirstOrDefaultAsync(car => car.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Car), request.Id);
            }

            return _mapper.Map<CarDetailsVm>(entity);
        }
    }
}
