using AutoMapper;
using DPHai.Fresher032023.EmisHomework.BL.Domain.Interfaces;
using DPHai.Fresher032023.EmisHomework.Common;
using DPHai.Fresher032023.EmisHomework.Common.Exceptions;
using DPHai.Fresher032023.EmisHomework.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPHai.Fresher032023.EmisHomework.BL.Domain.DomainServices
{
    public abstract class BaseDomainService<TEntity, TEntityGetDto, TEntityPostDto, TEntityFilter> : IBaseDomainService<TEntity, TEntityGetDto, TEntityPostDto, TEntityFilter>
    {
        protected readonly IBaseRepository<TEntity, TEntityFilter> _baseRepository;
        protected readonly IMapper _mapper;

        public BaseDomainService(IBaseRepository<TEntity, TEntityFilter> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public virtual async Task<IEnumerable<TEntityGetDto>> GetAllAsync()
        {
            var entities = await _baseRepository.GetAllAsync();

            var entitiesDto = _mapper.Map<IEnumerable<TEntityGetDto>>(entities);

            return entitiesDto;
        }

        public virtual async Task<TEntityGetDto> GetOneAsync(Guid id)
        {
            var entity = await _baseRepository.GetOneAsync(id);

            if (entity == null)
            {
                throw new NotFoundException(MISAResource.NotFound_Exception);
            }

            var entityDto = _mapper.Map<TEntityGetDto>(entity);

            return entityDto;
        }
    }
}
