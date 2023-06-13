using Dapper;
using POS.Common.DTOs;
using System.Data;

namespace POS.Data.Selects
{
  public class SelectsRepository : POSRepository, ISelectsRepository
  {
    public SelectsRepository(IDbTransaction dbTransaction) : base(dbTransaction) { }

    public async Task<List<SelectDTO>> GetAreas()
    {
      var query =
        "SELECT [A].[Id] AS [Value], [A].[Description] AS [Text] " +
        "FROM [dbo].[Areas] [A]";
      return (await _dbConnection.QueryAsync<SelectDTO>(query, transaction: _dbTransaction)).ToList();
    }

    public async Task<List<SelectDTO>> GetArticles()
    {
      var query =
        "SELECT [A].[Id] AS [Value], CONCAT([A].[Code], ' | ', [A].[Description]) AS [Text] " +
        "FROM [dbo].[Articles] [A]";
      return (await _dbConnection.QueryAsync<SelectDTO>(query, transaction: _dbTransaction)).ToList();
    }

    public async Task<List<SelectDTO>> GetArticlesTypes()
    {
      var query =
        "SELECT [AT].[Id] AS [Value], [AT].[Description] AS [Text] " +
        "FROM [dbo].[ArticleTypes] [AT]";
      return (await _dbConnection.QueryAsync<SelectDTO>(query, transaction: _dbTransaction)).ToList();
    }

    public async Task<List<SelectDTO>> GetBrands()
    {
      var query =
        "SELECT [B].[Id] AS [Value], [B].[Description] AS [Text] " +
        "FROM [dbo].[Brands] [B]";
      return (await _dbConnection.QueryAsync<SelectDTO>(query, transaction: _dbTransaction)).ToList();
    }

    public async Task<List<SelectDTO>> GetEmployees()
    {
      var query =
        "SELECT [E].[Id] AS [Value], CONCAT([E].[Name], ' ', [E].[PaternalSurname], ' ', [E].[MaternalSurname]) AS [Text] " +
        "FROM [dbo].[Employees] [E]";
      return (await _dbConnection.QueryAsync<SelectDTO>(query, transaction: _dbTransaction)).ToList();
    }

    public async Task<List<SelectDTO>> GetFeatures()
    {
      var query =
        "SELECT [F].[Id] AS [Value], [F].[Description] AS [Text] " +
        "FROM [dbo].[Features] [F]";
      return (await _dbConnection.QueryAsync<SelectDTO>(query, transaction: _dbTransaction)).ToList();
    }

    public async Task<List<SelectDTO>> GetRoles()
    {
      var query =
        "SELECT [R].[Id] AS [Value], [R].[Description] AS [Text] " +
        "FROM [dbo].[Roles] [R]";
      return (await _dbConnection.QueryAsync<SelectDTO>(query, transaction: _dbTransaction)).ToList();
    }

    public async Task<List<SelectDTO>> GetSuppliers()
    {
      var query =
        "SELECT [S].[Id] AS [Value], CONCAT([S].[Name], ' ', [S].[PaternalSurname], ' ', [S].[MaternalSurname]) AS [Text] " +
        "FROM [dbo].[Suppliers] [S]";
      return (await _dbConnection.QueryAsync<SelectDTO>(query, transaction: _dbTransaction)).ToList();
    }

    public async Task<List<SelectDTO>> GetUsers()
    {
      var query =
        "SELECT [U].[Id] AS [Value], CONCAT([E].[Name], ' ', [E].[PaternalSurname], ' ', [E].[MaternalSurname]) AS [Text] " +
        "FROM [dbo].[Users] [U] " +
        "INNER JOIN [dbo].[Employees] [E] ON [E].[Id] = [U].[EmployeeId]";
      return (await _dbConnection.QueryAsync<SelectDTO>(query, transaction: _dbTransaction)).ToList();
    }
  }
}
