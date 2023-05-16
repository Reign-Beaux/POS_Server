﻿using Dapper;
using POS.Common.DTOs;
using System.Data;

namespace POS.Data.Selects
{
  public class SelectsRepository : POSRepository, ISelectsRepository
  {
    public SelectsRepository(IDbTransaction dbTransaction) : base(dbTransaction) { }

    public async Task<List<SelectDTO>> GetAreas()
    {
      var query = "SELECT [A].[Id] AS [Value], [A].[Description] AS [Text] FROM [dbo].[Areas] [A]";
      return (await _dbConnection.QueryAsync<SelectDTO>(query, transaction: _dbTransaction)).ToList();
    }

    public async Task<List<SelectDTO>> GetArticlesTypes()
    {
      var query = "SELECT [AT].[Id] AS [Value], [AT].[Description] AS [Text] FROM [dbo].[ArticleTypes] [AT]";
      return (await _dbConnection.QueryAsync<SelectDTO>(query, transaction: _dbTransaction)).ToList();
    }

    public async Task<List<SelectDTO>> GetEmployees()
    {
      var query = "SELECT [E].[Id] AS [Value], CONCAT([E].[Name], ' ', [E].[PaternalSurname], ' ', [E].[MaternalSurname]) AS [Text] FROM [dbo].[Employees] [E]";
      return (await _dbConnection.QueryAsync<SelectDTO>(query, transaction: _dbTransaction)).ToList();
    }

    public async Task<List<SelectDTO>> GetRoles()
    {
      var query = "SELECT [R].[Id] AS [Value], [R].[Description] AS [Text] FROM [dbo].[Roles] [R]";
      return (await _dbConnection.QueryAsync<SelectDTO>(query, transaction: _dbTransaction)).ToList();
    }
  }
}
