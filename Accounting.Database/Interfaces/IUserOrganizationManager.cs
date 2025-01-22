﻿using Accounting.Business;

namespace Accounting.Database.Interfaces
{
  public interface IUserOrganizationManager : IGenericRepository<UserOrganization, int>
  {
    Task<UserOrganization> GetAsync(int userId, int organizationId, string databaseName, string databasePassword);
    Task<List<Organization>> GetByUserIdAsync(int userId, string? databaseName);
    Task<UserOrganization> CreateAsync(UserOrganization userOrganization, string databaseName);
    Task<List<UserOrganization>> GetAllAsync(int tenantId);
    Task<List<(Organization Organization, Tenant? Tenant)>> GetByEmailAsync(string email, bool searchTenants);
    Task<UserOrganization> GetByEmailAsync(string email, int? selectedOrganizationId, int tenantPublicId);
    Task<List<User>> GetUsersWithOrganizationsAsync(string databaseName);
    Task<UserOrganization> CreateAsync(int userID, int organizationId, string databaseName);
    Task<int> UpdateUserOrganizationsAsync(int userID, List<int> selectedOrganizationIds, string databasePassword, string databaseName);
    Task<int> DeleteByOrganizationIdAsync(int organizationId, string databasePassword, string databaseName);
  }
}