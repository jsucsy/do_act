﻿using Accounting.Business;

namespace Accounting.Database.Interfaces
{
  public interface ISecretManager : IGenericRepository<Secret, int>
  {
    Task<Secret> CreateAsync(string? key, bool master, string? value, string? vendor, string? purpose, int organizationId, int createdById);
    Task<int> DeleteAsync(int id, int organizationId);
    Task<int> DeleteMasterAsync(int organizationId);
    Task<List<Secret>> GetAllAsync(int organizationId);
    Task<Secret> GetAsync(int id, int organizationId);
    Task<Secret?> GetAsync(string key, int? organizationId);
    Task<Secret?> GetByTypeAsync(string type, int organizationId);
    Task<Secret?> GetMasterAsync(int organizationId);
  }
}