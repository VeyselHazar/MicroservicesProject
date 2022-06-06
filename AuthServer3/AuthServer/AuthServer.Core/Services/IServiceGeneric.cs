using AuthServer.Core.Repositories;
using AuthServer.Core.Services;
using AuthServer.Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.Services
{
    public interface IServiceGeneric<TEntity, TDto> where TEntity : class where TDto : class
    {
        //Task<Response<TDto>> GetByIdAsync(int id);

        //Task<Response<IEnumerable<TDto>>> GetAllAsync();

        //Task<Response<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> predicate);

        //Task<Response<TDto>> AddAsync(TDto entity);

        //Task<Response<NoDataDto>> Remove(int id);

        //Task<Response<NoDataDto>> Update(TDto entity, int id);
    }
    public class ServiceGeneric<TEntity, TDto> : IServiceGeneric<TEntity, TDto> where TEntity : class where TDto : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<TEntity> _genericRepository;
        public ServiceGeneric(IUnitOfWork unitOfWork, IGenericRepository<TEntity> genericRepository)
        {
            _unitOfWork = unitOfWork;
            _genericRepository = genericRepository;
        }

        //public async Task<Response<TDto>> AddAsync(TDto entity)
        //{
        //    var newEntity = ObjectMapper.Mapper.Map<TEntity>(entity);
        //    await _genericRepository.AddAsync(newEntity);
        //    await _unitOfWork.CommitAsync();
        //    var newDto = ObjectMapper.Mapper.Map<TDto>(newEntity);
        //    return Response<TDto>.Success(newDto, 200);
        //}

        //public async Task<Response<IEnumerable<TDto>>> GetAllAsync()
        //{
        //    var rezervations = ObjectMapper.Mapper.Map<List<TDto>>(await _genericRepository.GetAllAsync());
        //    return Response<IEnumerable<TDto>>.Success(rezervations, 200);
        //}

        //public async Task<Response<TDto>> GetByIdAsync(int id)
        //{
        //    var rezervations = await _genericRepository.GetByIdAsync(id);
        //    if (rezervations==null)
        //    {
        //        return Response<TDto>.Fail("Id is not found", 404, true);
        //    }
        //    return Response<TDto>.Success(ObjectMapper.Mapper.Map<TDto>(rezervations), 200);
        //}

        //public async Task<Response<NoDataDto>> Remove(int id)
        //{
        //    var isExistEntity = await _genericRepository.GetByIdAsync(id);
        //    if (isExistEntity==null)
        //    {
        //        return Response<NoDataDto>.Fail("id is not found",404,true);
        //    }
        //    _genericRepository.Remove(isExistEntity);
        //    await _unitOfWork.CommitAsync();
        //    return Response<NoDataDto>.Success(200);
        //} 

        //public async Task<Response<NoDataDto>> Update(TDto entity, int id )
        //{
        //    var isExistEntity = await _genericRepository.GetByIdAsync(id);
        //    if(isExistEntity==null)
        //    {
        //        return Response<NoDataDto>.Fail("Id is not found", 404, true);
        //    }

        //    var updateEntity = ObjectMapper.Mapper.Map<TEntity>(entity);
        //    _genericRepository.Update(updateEntity);
        //    await _unitOfWork.CommitAsync();
        //    return Response<NoDataDto>.Success(204); //204 kodu => no content
        //}

        //public async Task<Response<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> predicate)
        //{
        //    var list = _genericRepository.Where(predicate);
        //    return Response<IEnumerable<TDto>>.Success(ObjectMapper.Mapper.Map<IEnumerable<TDto>>(await list.ToListAsync()), 200);
        //}
    }
}
