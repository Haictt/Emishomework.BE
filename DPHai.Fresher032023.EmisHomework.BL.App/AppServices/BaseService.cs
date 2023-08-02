using AutoMapper;
using DPHai.Fresher032023.EmisHomework.BL.App.Interfaces;
using DPHai.Fresher032023.EmisHomework.Common;
using DPHai.Fresher032023.EmisHomework.Common.Exceptions;
using DPHai.Fresher032023.EmisHomework.Common.UnitOfWork;
using DPHai.Fresher032023.EmisHomework.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace DPHai.Fresher032023.EmisHomework.BL.App.AppServices
{
    public abstract class BaseService<TEntity, TEntityGetDto, TEntityPostDto, TEntityFilter> : IBaseService<TEntity, TEntityGetDto, TEntityPostDto, TEntityFilter>
    {
        protected readonly IBaseRepository<TEntity, TEntityFilter> _baseRepository;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        public BaseService(IBaseRepository<TEntity, TEntityFilter> baseRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Hàm lấy toàn bộ bản ghi
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IEnumerable<TEntityGetDto>> GetAllAsync()
        {
            var entities = await _baseRepository.GetAllAsync();
            var entitiesDto = _mapper.Map<IEnumerable<TEntityGetDto>>(entities);
            return entitiesDto;

        }

        /// <summary>
        /// Hàm lấy 1 bản ghi
        /// </summary>
        /// <param name="id">Id bản ghi</param>
        /// <returns></returns>
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

        /// <summary>
        /// Hàm xóa nhiều bàn ghi theo id list
        /// </summary>
        /// <param name="ids">List id</param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteAsync(Guid[] ids)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                foreach (var id in ids)
                {
                    var entity = await _baseRepository.GetOneAsync(id);
                    if (entity == null)
                    {
                        throw new NotFoundException(MISAResource.NotFound_Exception);

                    };

                }
                List<string> formattedList = ids.Select(s => s.ToString()).ToList();
                // Join the formatted strings with commas
                string formattedString = string.Join(",", formattedList);
                var res = await _baseRepository.DeleteAsync(formattedString);
                await _unitOfWork.CommitAsync();
                return res;
            }catch
            {
                await _unitOfWork.RollbackAsync();
                throw new InternalException(MISAResource.Internal_Exception);
            }


        }
    }
}
