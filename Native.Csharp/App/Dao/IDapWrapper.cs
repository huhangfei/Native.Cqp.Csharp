using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;

namespace Native.Csharp.Dao
{
    public interface IDapWrapper
    {
        int InnerExecuteProc(string connString, string proc);
        int InnerExecuteProc(string connString, string proc, DynamicParameters procParams);
        Task<int> InnerExecuteProcAsync(string connString, string proc);
        Task<int> InnerExecuteProcAsync(string connString, string proc, DynamicParameters procParams);
        int InnerExecuteScalarProc(string connString, string proc);
        Task<int> InnerExecuteScalarProcAsync(string connString, string proc);
        int InnerExecuteSql(string connString, string sql, DynamicParameters sqlParams);
        int InnerExecuteSql(string connString, string sql, object param);
        Task<int> InnerExecuteSqlAsync(string connString, string sql, DynamicParameters sqlParams);
        Task<int> InnerExecuteSqlAsync(string connString, string sql, object param);
        int InnerExecuteText(string connString, string sql);
        Task<int> InnerExecuteTextAsync(string connString, string sql);
        List<T> InnerQueryLongTimeProc<T>(string connString, string proc);
        Task<IEnumerable<T>> InnerQueryLongTimeProcAsync<T>(string connString, string proc);
        T InnerQueryMultipleProc<T>(string connString, string proc, DynamicParameters procParams, Func<SqlMapper.GridReader, T> readResult);
        Task<T> InnerQueryMultipleProcAsync<T>(string connString, string proc, DynamicParameters procParams, Func<Task<SqlMapper.GridReader>, Task<T>> readResult);
        List<T> InnerQueryProc<T>(string connString, string proc);
        List<T> InnerQueryProc<T>(string connString, string proc, DynamicParameters procParams);
        Task<IEnumerable<T>> InnerQueryProcAsync<T>(string connString, string proc);
        Task<IEnumerable<T>> InnerQueryProcAsync<T>(string connString, string proc, DynamicParameters procParams);
        T InnerQueryScalarProc<T>(string connString, string proc);
        T InnerQueryScalarProc<T>(string connString, string proc, DynamicParameters procParams);
        Task<T> InnerQueryScalarProcAsync<T>(string connString, string proc);
        Task<T> InnerQueryScalarProcAsync<T>(string connString, string proc, DynamicParameters procParams);
        T InnerQueryScalarSql<T>(string connString, string sql, DynamicParameters procParams);
        Task<T> InnerQueryScalarSqlAsync<T>(string connString, string sql, DynamicParameters procParams);
        List<T> InnerQuerySql<T>(string connString, string sql);
        List<T> InnerQuerySql<T>(string connString, string sql, DynamicParameters procParams);
        List<T> InnerQuerySql<T>(string connString, string sql, object procParams);
        Task<IEnumerable<T>> InnerQuerySqlAsync<T>(string connString, string sql);
        Task<IEnumerable<T>> InnerQuerySqlAsync<T>(string connString, string sql, DynamicParameters procParams);
    }
}