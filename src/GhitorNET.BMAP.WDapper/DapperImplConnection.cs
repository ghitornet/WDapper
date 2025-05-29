using System.Data;
using System.Data.Common;
using Dapper;

namespace GhitorNET.BMAP.WDapper;

public class DapperImplConnection(DbConnection connection) : DapperConnection(connection), IDapperImplConnection
{
    public IAsyncEnumerable<dynamic> QueryUnbufferedAsync(string sql, object? param = null,
        DbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
    {
        return connection.QueryUnbufferedAsync(sql, param, transaction, commandTimeout, commandType);
    }

    public IAsyncEnumerable<T> QueryUnbufferedAsync<T>(string sql, object? param = null,
        DbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
    {
        return connection.QueryUnbufferedAsync<T>(sql, param, transaction, commandTimeout, commandType);
    }
}