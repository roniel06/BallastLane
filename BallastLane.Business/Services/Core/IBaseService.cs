﻿using BallastLane.Infrastructure.Models.Core;

namespace BallastLane.Business.Services.Core
{
    public interface IBaseService<T> where T: BaseModel, new()
    {
        /// <summary>
        /// This method will create a record
        /// for the given entity.
        /// </summary>
        /// <param name="model">The entity</param>
        /// <returns>The created record</returns>
        Task<T?> CreateAsync(T model);

        /// <summary>
        /// This method will update the given record
        /// </summary>
        /// <param name="model"></param>
        /// <returns>The updated record</returns>
        Task<T?> UpdateAsync(T model);

        /// <summary>
        /// This method will soft-delete the record
        /// </summary>
        /// <param name="id">The id of the record</param>
        /// <returns>true if the record was soft-deleted</returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// This method will return all records for the given entity
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// This method will return the record for the entity by a given id.
        /// </summary>
        /// <param name="id">The record id.</param>
        /// <returns></returns>
        Task<T?> GetByIdAsync(int id);
    }
}
