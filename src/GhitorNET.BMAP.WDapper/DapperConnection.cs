using System.Data;
using Dapper;

namespace GhitorNET.BMAP.WDapper;

public class DapperConnection(IDbConnection dbConnection) : IDapperConnection
{
    public Task<IEnumerable<dynamic>> QueryAsync(string sql, object? param = null, IDbTransaction? transaction = null,
        int? commandTimeout = null, CommandType? commandType = null)
    {
        return dbConnection.QueryAsync(sql, param, transaction, commandTimeout, commandType);
    }

    public Task<IEnumerable<dynamic>> QueryAsync(CommandDefinition command)
    {
        return dbConnection.QueryAsync(command);
    }

    public Task<dynamic> QueryFirstAsync(CommandDefinition command)
    {
        return dbConnection.QueryFirstAsync(command);
    }

    public Task<dynamic?> QueryFirstOrDefaultAsync(CommandDefinition command)
    {
        return dbConnection.QueryFirstOrDefaultAsync(command);
    }

    public Task<dynamic> QuerySingleAsync(CommandDefinition command)
    {
        return dbConnection.QuerySingleAsync(command);
    }

    public Task<dynamic?> QuerySingleOrDefaultAsync(CommandDefinition command)
    {
        return dbConnection.QuerySingleOrDefaultAsync(command);
    }

    public Task<IEnumerable<T>> QueryAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null,
        int? commandTimeout = null, CommandType? commandType = null)
    {
        return dbConnection.QueryAsync<T>(sql, param, transaction, commandTimeout, commandType);
    }

    public Task<T> QueryFirstAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null,
        int? commandTimeout = null, CommandType? commandType = null)
    {
        return dbConnection.QueryFirstAsync<T>(sql, param, transaction, commandTimeout, commandType);
    }

    public Task<T?> QueryFirstOrDefaultAsync<T>(string sql, object? param = null,
        IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
    {
        return dbConnection.QueryFirstOrDefaultAsync<T>(sql, param, transaction, commandTimeout, commandType);
    }

    public Task<T> QuerySingleAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null,
        int? commandTimeout = null, CommandType? commandType = null)
    {
        return dbConnection.QuerySingleAsync<T>(sql, param, transaction, commandTimeout, commandType);
    }

    public Task<T?> QuerySingleOrDefaultAsync<T>(string sql, object? param = null,
        IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
    {
        return dbConnection.QuerySingleOrDefaultAsync<T>(sql, param, transaction, commandTimeout, commandType);
    }

    public Task<dynamic> QueryFirstAsync(string sql, object? param = null, IDbTransaction? transaction = null,
        int? commandTimeout = null, CommandType? commandType = null)
    {
        return dbConnection.QueryFirstAsync(sql, param, transaction, commandTimeout, commandType);
    }

    public Task<dynamic?> QueryFirstOrDefaultAsync(string sql, object? param = null, IDbTransaction? transaction = null,
        int? commandTimeout = null, CommandType? commandType = null)
    {
        return dbConnection.QueryFirstOrDefaultAsync(sql, param, transaction, commandTimeout, commandType);
    }

    public Task<dynamic> QuerySingleAsync(string sql, object? param = null, IDbTransaction? transaction = null,
        int? commandTimeout = null, CommandType? commandType = null)
    {
        return dbConnection.QuerySingleAsync(sql, param, transaction, commandTimeout, commandType);
    }

    public Task<dynamic?> QuerySingleOrDefaultAsync(string sql, object? param = null,
        IDbTransaction? transaction = null,
        int? commandTimeout = null, CommandType? commandType = null)
    {
        return dbConnection.QuerySingleOrDefaultAsync(sql, param, transaction, commandTimeout, commandType);
    }

    public Task<IEnumerable<object>> QueryAsync(Type type, string sql, object? param = null,
        IDbTransaction? transaction = null,
        int? commandTimeout = null, CommandType? commandType = null)
    {
        return dbConnection.QueryAsync(type, sql, param, transaction, commandTimeout, commandType);
    }

    public Task<object> QueryFirstAsync(Type type, string sql, object? param = null, IDbTransaction? transaction = null,
        int? commandTimeout = null, CommandType? commandType = null)
    {
        return dbConnection.QueryFirstAsync(type, sql, param, transaction, commandTimeout, commandType);
    }

    public Task<object?> QueryFirstOrDefaultAsync(Type type, string sql, object? param = null,
        IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
    {
        return dbConnection.QueryFirstOrDefaultAsync(type, sql, param, transaction, commandTimeout, commandType);
    }

    public Task<object> QuerySingleAsync(Type type, string sql, object? param = null,
        IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
    {
        return dbConnection.QuerySingleAsync(type, sql, param, transaction, commandTimeout, commandType);
    }

    public Task<object?> QuerySingleOrDefaultAsync(Type type, string sql, object? param = null,
        IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
    {
        return dbConnection.QuerySingleOrDefaultAsync(type, sql, param, transaction, commandTimeout, commandType);
    }

    public Task<IEnumerable<T>> QueryAsync<T>(CommandDefinition command)
    {
        return dbConnection.QueryAsync<T>(command);
    }

    public Task<IEnumerable<object>> QueryAsync(Type type, CommandDefinition command)
    {
        return dbConnection.QueryAsync(type, command);
    }

    public Task<object> QueryFirstAsync(Type type, CommandDefinition command)
    {
        return dbConnection.QueryFirstAsync(type, command);
    }

    public Task<T> QueryFirstAsync<T>(CommandDefinition command)
    {
        return dbConnection.QueryFirstAsync<T>(command);
    }

    public Task<object?> QueryFirstOrDefaultAsync(Type type, CommandDefinition command)
    {
        return dbConnection.QueryFirstOrDefaultAsync(type, command);
    }

    public Task<T?> QueryFirstOrDefaultAsync<T>(CommandDefinition command)
    {
        return dbConnection.QueryFirstOrDefaultAsync<T>(command);
    }

    public Task<object> QuerySingleAsync(Type type, CommandDefinition command)
    {
        return dbConnection.QuerySingleAsync(type, command);
    }

    public Task<T> QuerySingleAsync<T>(CommandDefinition command)
    {
        return dbConnection.QuerySingleAsync<T>(command);
    }

    public Task<object?> QuerySingleOrDefaultAsync(Type type, CommandDefinition command)
    {
        return dbConnection.QuerySingleOrDefaultAsync(type, command);
    }

    public Task<T?> QuerySingleOrDefaultAsync<T>(CommandDefinition command)
    {
        return dbConnection.QuerySingleOrDefaultAsync<T>(command);
    }

    public Task<int> ExecuteAsync(string sql, object? param = null, IDbTransaction? transaction = null,
        int? commandTimeout = null, CommandType? commandType = null)
    {
        return dbConnection.ExecuteAsync(sql, param, transaction, commandTimeout, commandType);
    }

    public Task<int> ExecuteAsync(CommandDefinition command)
    {
        return dbConnection.ExecuteAsync(command);
    }

    public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(string sql,
        Func<TFirst, TSecond, TReturn> map, object? param = null,
        IDbTransaction? transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null,
        CommandType? commandType = null)
    {
        return dbConnection.QueryAsync(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
    }

    public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(CommandDefinition command,
        Func<TFirst, TSecond, TReturn> map,
        string splitOn = "Id")
    {
        return dbConnection.QueryAsync(command, map, splitOn);
    }

    public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(string sql,
        Func<TFirst, TSecond, TThird, TReturn> map, object? param = null,
        IDbTransaction? transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null,
        CommandType? commandType = null)
    {
        return dbConnection.QueryAsync(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
    }

    public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(CommandDefinition command,
        Func<TFirst, TSecond, TThird, TReturn> map,
        string splitOn = "Id")
    {
        return dbConnection.QueryAsync(command, map, splitOn);
    }

    public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(string sql,
        Func<TFirst, TSecond, TThird, TFourth, TReturn> map,
        object? param = null, IDbTransaction? transaction = null, bool buffered = true, string splitOn = "Id",
        int? commandTimeout = null, CommandType? commandType = null)
    {
        return dbConnection.QueryAsync(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
    }

    public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(CommandDefinition command,
        Func<TFirst, TSecond, TThird, TFourth, TReturn> map,
        string splitOn = "Id")
    {
        return dbConnection.QueryAsync(command, map, splitOn);
    }

    public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(
        string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map,
        object? param = null, IDbTransaction? transaction = null, bool buffered = true, string splitOn = "Id",
        int? commandTimeout = null, CommandType? commandType = null)
    {
        return dbConnection.QueryAsync(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
    }

    public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(
        CommandDefinition command,
        Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, string splitOn = "Id")
    {
        return dbConnection.QueryAsync(command, map, splitOn);
    }

    public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(string sql,
        Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map,
        object? param = null, IDbTransaction? transaction = null, bool buffered = true, string splitOn = "Id",
        int? commandTimeout = null, CommandType? commandType = null)
    {
        return dbConnection.QueryAsync(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
    }

    public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(
        CommandDefinition command,
        Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, string splitOn = "Id")
    {
        return dbConnection.QueryAsync(command, map, splitOn);
    }

    public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(
        string sql,
        Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, object? param = null,
        IDbTransaction? transaction = null, bool buffered = true, string splitOn = "Id",
        int? commandTimeout = null, CommandType? commandType = null)
    {
        return dbConnection.QueryAsync(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
    }

    public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(
        CommandDefinition command, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map,
        string splitOn = "Id")
    {
        return dbConnection.QueryAsync(command, map, splitOn);
    }

    public Task<IEnumerable<TReturn>> QueryAsync<TReturn>(string sql, Type[] types, Func<object[], TReturn> map,
        object? param = null,
        IDbTransaction? transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null,
        CommandType? commandType = null)
    {
        return dbConnection.QueryAsync(sql, types, map, param, transaction, buffered, splitOn, commandTimeout,
            commandType);
    }

    public Task<SqlMapper.GridReader> QueryMultipleAsync(string sql, object? param = null,
        IDbTransaction? transaction = null,
        int? commandTimeout = null, CommandType? commandType = null)
    {
        return dbConnection.QueryMultipleAsync(sql, param, transaction, commandTimeout, commandType);
    }

    public Task<SqlMapper.GridReader> QueryMultipleAsync(CommandDefinition command)
    {
        return dbConnection.QueryMultipleAsync(command);
    }

    public Task<IDataReader> ExecuteReaderAsync(string sql, object? param = null, IDbTransaction? transaction = null,
        int? commandTimeout = null, CommandType? commandType = null)
    {
        return dbConnection.ExecuteReaderAsync(sql, param, transaction, commandTimeout, commandType);
    }

    public Task<IDataReader> ExecuteReaderAsync(CommandDefinition command)
    {
        return dbConnection.ExecuteReaderAsync(command);
    }

    public Task<IDataReader> ExecuteReaderAsync(CommandDefinition command, CommandBehavior commandBehavior)
    {
        return dbConnection.ExecuteReaderAsync(command, commandBehavior);
    }

    public Task<object?> ExecuteScalarAsync(string sql, object? param = null, IDbTransaction? transaction = null,
        int? commandTimeout = null, CommandType? commandType = null)
    {
        return dbConnection.ExecuteScalarAsync(sql, param, transaction, commandTimeout, commandType);
    }

    public Task<T?> ExecuteScalarAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null,
        int? commandTimeout = null, CommandType? commandType = null)
    {
        return dbConnection.ExecuteScalarAsync<T>(sql, param, transaction, commandTimeout, commandType);
    }

    public Task<object?> ExecuteScalarAsync(CommandDefinition command)
    {
        return dbConnection.ExecuteScalarAsync(command);
    }

    public Task<T?> ExecuteScalarAsync<T>(CommandDefinition command)
    {
        return dbConnection.ExecuteScalarAsync<T>(command);
    }

    public void Dispose()
    {
        if (dbConnection is IDisposable disposableConnection) disposableConnection.Dispose();
    }

    public IDbTransaction BeginTransaction()
    {
        return dbConnection.BeginTransaction();
    }

    public IDbTransaction BeginTransaction(IsolationLevel il)
    {
        return dbConnection.BeginTransaction(il);
    }

    public void ChangeDatabase(string databaseName)
    {
        dbConnection.ChangeDatabase(databaseName);
    }

    public void Close()
    {
        dbConnection.Close();
    }

    public IDbCommand CreateCommand()
    {
        return dbConnection.CreateCommand();
    }

    public void Open()
    {
        dbConnection.Open();
    }

    public string? ConnectionString
    {
        get => dbConnection.ConnectionString;
        set => dbConnection.ConnectionString = value;
    }

    public int ConnectionTimeout => dbConnection.ConnectionTimeout;
    public string Database => dbConnection.Database;
    public ConnectionState State => dbConnection.State;
}