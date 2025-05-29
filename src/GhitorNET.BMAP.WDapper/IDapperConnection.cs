using System.Data;
using System.Diagnostics.CodeAnalysis;
using Dapper;
using static Dapper.SqlMapper;

namespace GhitorNET.BMAP.WDapper;

public interface IDapperConnection : IDisposable
{
    [AllowNull] public string ConnectionString { get; set; }
    public int ConnectionTimeout { get; }
    public string Database { get; }
    public ConnectionState State { get; }

    /// <summary>
    ///     Execute a query asynchronously using Task.
    /// </summary>
    /// <param name="sql">The SQL to execute for the query.</param>
    /// <param name="param">The parameters to pass, if any.</param>
    /// <param name="transaction">The transaction to use, if any.</param>
    /// <param name="commandTimeout">The command timeout (in seconds).</param>
    /// <param name="commandType">The type of command to execute.</param>
    /// <remarks>Note: each row can be accessed via "dynamic", or by casting to an IDictionary&lt;string,object&gt;</remarks>
    public Task<IEnumerable<dynamic>> QueryAsync(string sql, object? param = null,
        IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);

    /// <summary>
    ///     Execute a query asynchronously using Task.
    /// </summary>
    /// <param name="command">The command used to query on this connection.</param>
    /// <remarks>Note: each row can be accessed via "dynamic", or by casting to an IDictionary&lt;string,object&gt;</remarks>
    public Task<IEnumerable<dynamic>> QueryAsync(CommandDefinition command);

    /// <summary>
    ///     Execute a single-row query asynchronously using Task.
    /// </summary>
    /// <param name="command">The command used to query on this connection.</param>
    /// <remarks>Note: the row can be accessed via "dynamic", or by casting to an IDictionary&lt;string,object&gt;</remarks>
    public Task<dynamic> QueryFirstAsync(CommandDefinition command);

    /// <summary>
    ///     Execute a single-row query asynchronously using Task.
    /// </summary>
    /// <param name="command">The command used to query on this connection.</param>
    /// <remarks>Note: the row can be accessed via "dynamic", or by casting to an IDictionary&lt;string,object&gt;</remarks>
    public Task<dynamic?> QueryFirstOrDefaultAsync(CommandDefinition command);

    /// <summary>
    ///     Execute a single-row query asynchronously using Task.
    /// </summary>
    /// <param name="command">The command used to query on this connection.</param>
    /// <remarks>Note: the row can be accessed via "dynamic", or by casting to an IDictionary&lt;string,object&gt;</remarks>
    public Task<dynamic> QuerySingleAsync(CommandDefinition command);

    /// <summary>
    ///     Execute a single-row query asynchronously using Task.
    /// </summary>
    /// <param name="command">The command used to query on this connection.</param>
    /// <remarks>Note: the row can be accessed via "dynamic", or by casting to an IDictionary&lt;string,object&gt;</remarks>
    public Task<dynamic?> QuerySingleOrDefaultAsync(CommandDefinition command);

    /// <summary>
    ///     Execute a query asynchronously using Task.
    /// </summary>
    /// <typeparam name="T">The type of results to return.</typeparam>
    /// <param name="sql">The SQL to execute for the query.</param>
    /// <param name="param">The parameters to pass, if any.</param>
    /// <param name="transaction">The transaction to use, if any.</param>
    /// <param name="commandTimeout">The command timeout (in seconds).</param>
    /// <param name="commandType">The type of command to execute.</param>
    /// <returns>
    ///     A sequence of data of <typeparamref name="T" />; if a basic type (int, string, etc) is queried then the data from
    ///     the first column is assumed, otherwise an instance is
    ///     created per row, and a direct column-name===member-name mapping is assumed (case insensitive).
    /// </returns>
    public Task<IEnumerable<T>> QueryAsync<T>(string sql, object? param = null,
        IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);

    /// <summary>
    ///     Execute a single-row query asynchronously using Task.
    /// </summary>
    /// <typeparam name="T">The type of result to return.</typeparam>
    /// <param name="sql">The SQL to execute for the query.</param>
    /// <param name="param">The parameters to pass, if any.</param>
    /// <param name="transaction">The transaction to use, if any.</param>
    /// <param name="commandTimeout">The command timeout (in seconds).</param>
    /// <param name="commandType">The type of command to execute.</param>
    public Task<T> QueryFirstAsync<T>(string sql, object? param = null,
        IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);

    /// <summary>
    ///     Execute a single-row query asynchronously using Task.
    /// </summary>
    /// <typeparam name="T">The type of result to return.</typeparam>
    /// <param name="sql">The SQL to execute for the query.</param>
    /// <param name="param">The parameters to pass, if any.</param>
    /// <param name="transaction">The transaction to use, if any.</param>
    /// <param name="commandTimeout">The command timeout (in seconds).</param>
    /// <param name="commandType">The type of command to execute.</param>
    public Task<T?> QueryFirstOrDefaultAsync<T>(string sql, object? param = null,
        IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);

    /// <summary>
    ///     Execute a single-row query asynchronously using Task.
    /// </summary>
    /// <typeparam name="T">The type of result to return.</typeparam>
    /// <param name="sql">The SQL to execute for the query.</param>
    /// <param name="param">The parameters to pass, if any.</param>
    /// <param name="transaction">The transaction to use, if any.</param>
    /// <param name="commandTimeout">The command timeout (in seconds).</param>
    /// <param name="commandType">The type of command to execute.</param>
    public Task<T> QuerySingleAsync<T>(string sql, object? param = null,
        IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);

    /// <summary>
    ///     Execute a single-row query asynchronously using Task.
    /// </summary>
    /// <typeparam name="T">The type to return.</typeparam>
    /// <param name="sql">The SQL to execute for the query.</param>
    /// <param name="param">The parameters to pass, if any.</param>
    /// <param name="transaction">The transaction to use, if any.</param>
    /// <param name="commandTimeout">The command timeout (in seconds).</param>
    /// <param name="commandType">The type of command to execute.</param>
    public Task<T?> QuerySingleOrDefaultAsync<T>(string sql, object? param = null,
        IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);

    /// <summary>
    ///     Execute a single-row query asynchronously using Task.
    /// </summary>
    /// <param name="sql">The SQL to execute for the query.</param>
    /// <param name="param">The parameters to pass, if any.</param>
    /// <param name="transaction">The transaction to use, if any.</param>
    /// <param name="commandTimeout">The command timeout (in seconds).</param>
    /// <param name="commandType">The type of command to execute.</param>
    public Task<dynamic> QueryFirstAsync(string sql, object? param = null,
        IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);

    /// <summary>
    ///     Execute a single-row query asynchronously using Task.
    /// </summary>
    /// <param name="sql">The SQL to execute for the query.</param>
    /// <param name="param">The parameters to pass, if any.</param>
    /// <param name="transaction">The transaction to use, if any.</param>
    /// <param name="commandTimeout">The command timeout (in seconds).</param>
    /// <param name="commandType">The type of command to execute.</param>
    public Task<dynamic?> QueryFirstOrDefaultAsync(string sql, object? param = null,
        IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);

    /// <summary>
    ///     Execute a single-row query asynchronously using Task.
    /// </summary>
    /// <param name="sql">The SQL to execute for the query.</param>
    /// <param name="param">The parameters to pass, if any.</param>
    /// <param name="transaction">The transaction to use, if any.</param>
    /// <param name="commandTimeout">The command timeout (in seconds).</param>
    /// <param name="commandType">The type of command to execute.</param>
    public Task<dynamic> QuerySingleAsync(string sql, object? param = null,
        IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);

    /// <summary>
    ///     Execute a single-row query asynchronously using Task.
    /// </summary>
    /// <param name="sql">The SQL to execute for the query.</param>
    /// <param name="param">The parameters to pass, if any.</param>
    /// <param name="transaction">The transaction to use, if any.</param>
    /// <param name="commandTimeout">The command timeout (in seconds).</param>
    /// <param name="commandType">The type of command to execute.</param>
    public Task<dynamic?> QuerySingleOrDefaultAsync(string sql, object? param = null,
        IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);

    /// <summary>
    ///     Execute a query asynchronously using Task.
    /// </summary>
    /// <param name="type">The type to return.</param>
    /// <param name="sql">The SQL to execute for the query.</param>
    /// <param name="param">The parameters to pass, if any.</param>
    /// <param name="transaction">The transaction to use, if any.</param>
    /// <param name="commandTimeout">The command timeout (in seconds).</param>
    /// <param name="commandType">The type of command to execute.</param>
    /// <exception cref="ArgumentNullException"><paramref name="type" /> is <c>null</c>.</exception>
    public Task<IEnumerable<object>> QueryAsync(Type type, string sql, object? param = null,
        IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);

    /// <summary>
    ///     Execute a single-row query asynchronously using Task.
    /// </summary>
    /// <param name="type">The type to return.</param>
    /// <param name="sql">The SQL to execute for the query.</param>
    /// <param name="param">The parameters to pass, if any.</param>
    /// <param name="transaction">The transaction to use, if any.</param>
    /// <param name="commandTimeout">The command timeout (in seconds).</param>
    /// <param name="commandType">The type of command to execute.</param>
    /// <exception cref="ArgumentNullException"><paramref name="type" /> is <c>null</c>.</exception>
    public Task<object> QueryFirstAsync(Type type, string sql, object? param = null,
        IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);

    /// <summary>
    ///     Execute a single-row query asynchronously using Task.
    /// </summary>
    /// <param name="type">The type to return.</param>
    /// <param name="sql">The SQL to execute for the query.</param>
    /// <param name="param">The parameters to pass, if any.</param>
    /// <param name="transaction">The transaction to use, if any.</param>
    /// <param name="commandTimeout">The command timeout (in seconds).</param>
    /// <param name="commandType">The type of command to execute.</param>
    /// <exception cref="ArgumentNullException"><paramref name="type" /> is <c>null</c>.</exception>
    public Task<object?> QueryFirstOrDefaultAsync(Type type, string sql, object? param = null,
        IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);

    /// <summary>
    ///     Execute a single-row query asynchronously using Task.
    /// </summary>
    /// <param name="type">The type to return.</param>
    /// <param name="sql">The SQL to execute for the query.</param>
    /// <param name="param">The parameters to pass, if any.</param>
    /// <param name="transaction">The transaction to use, if any.</param>
    /// <param name="commandTimeout">The command timeout (in seconds).</param>
    /// <param name="commandType">The type of command to execute.</param>
    /// <exception cref="ArgumentNullException"><paramref name="type" /> is <c>null</c>.</exception>
    public Task<object> QuerySingleAsync(Type type, string sql, object? param = null,
        IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);

    /// <summary>
    ///     Execute a single-row query asynchronously using Task.
    /// </summary>
    /// <param name="type">The type to return.</param>
    /// <param name="sql">The SQL to execute for the query.</param>
    /// <param name="param">The parameters to pass, if any.</param>
    /// <param name="transaction">The transaction to use, if any.</param>
    /// <param name="commandTimeout">The command timeout (in seconds).</param>
    /// <param name="commandType">The type of command to execute.</param>
    /// <exception cref="ArgumentNullException"><paramref name="type" /> is <c>null</c>.</exception>
    public Task<object?> QuerySingleOrDefaultAsync(Type type, string sql, object? param = null,
        IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);

    /// <summary>
    ///     Execute a query asynchronously using Task.
    /// </summary>
    /// <typeparam name="T">The type to return.</typeparam>
    /// <param name="command">The command used to query on this connection.</param>
    /// <returns>
    ///     A sequence of data of <typeparamref name="T" />; if a basic type (int, string, etc) is queried then the data from
    ///     the first column is assumed, otherwise an instance is
    ///     created per row, and a direct column-name===member-name mapping is assumed (case insensitive).
    /// </returns>
    public Task<IEnumerable<T>> QueryAsync<T>(CommandDefinition command);

    /// <summary>
    ///     Execute a query asynchronously using Task.
    /// </summary>
    /// <param name="type">The type to return.</param>
    /// <param name="command">The command used to query on this connection.</param>
    public Task<IEnumerable<object>> QueryAsync(Type type, CommandDefinition command);

    /// <summary>
    ///     Execute a single-row query asynchronously using Task.
    /// </summary>
    /// <param name="type">The type to return.</param>
    /// <param name="command">The command used to query on this connection.</param>
    public Task<object> QueryFirstAsync(Type type, CommandDefinition command);

    /// <summary>
    ///     Execute a single-row query asynchronously using Task.
    /// </summary>
    /// <typeparam name="T">The type to return.</typeparam>
    /// <param name="command">The command used to query on this connection.</param>
    public Task<T> QueryFirstAsync<T>(CommandDefinition command);

    /// <summary>
    ///     Execute a single-row query asynchronously using Task.
    /// </summary>
    /// <param name="type">The type to return.</param>
    /// <param name="command">The command used to query on this connection.</param>
    public Task<object?> QueryFirstOrDefaultAsync(Type type, CommandDefinition command);

    /// <summary>
    ///     Execute a single-row query asynchronously using Task.
    /// </summary>
    /// <typeparam name="T">The type to return.</typeparam>
    /// <param name="command">The command used to query on this connection.</param>
    public Task<T?> QueryFirstOrDefaultAsync<T>(CommandDefinition command);

    /// <summary>
    ///     Execute a single-row query asynchronously using Task.
    /// </summary>
    /// <param name="type">The type to return.</param>
    /// <param name="command">The command used to query on this connection.</param>
    public Task<object> QuerySingleAsync(Type type, CommandDefinition command);

    /// <summary>
    ///     Execute a single-row query asynchronously using Task.
    /// </summary>
    /// <typeparam name="T">The type to return.</typeparam>
    /// <param name="command">The command used to query on this connection.</param>
    public Task<T> QuerySingleAsync<T>(CommandDefinition command);

    /// <summary>
    ///     Execute a single-row query asynchronously using Task.
    /// </summary>
    /// <param name="type">The type to return.</param>
    /// <param name="command">The command used to query on this connection.</param>
    public Task<object?> QuerySingleOrDefaultAsync(Type type, CommandDefinition command);

    /// <summary>
    ///     Execute a single-row query asynchronously using Task.
    /// </summary>
    /// <typeparam name="T">The type to return.</typeparam>
    /// <param name="command">The command used to query on this connection.</param>
    public Task<T?> QuerySingleOrDefaultAsync<T>(CommandDefinition command);

    /// <summary>
    ///     Execute a command asynchronously using Task.
    /// </summary>
    /// <param name="sql">The SQL to execute for this query.</param>
    /// <param name="param">The parameters to use for this query.</param>
    /// <param name="transaction">The transaction to use for this query.</param>
    /// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
    /// <param name="commandType">Is it a stored proc or a batch?</param>
    /// <returns>The number of rows affected.</returns>
    public Task<int> ExecuteAsync(string sql, object? param = null,
        IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);

    /// <summary>
    ///     Execute a command asynchronously using Task.
    /// </summary>
    /// <param name="command">The command to execute on this connection.</param>
    /// <returns>The number of rows affected.</returns>
    public Task<int> ExecuteAsync(CommandDefinition command);

    /// <summary>
    ///     Perform an asynchronous multi-mapping query with 2 input types.
    ///     This returns a single type, combined from the raw types via <paramref name="map" />.
    /// </summary>
    /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
    /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
    /// <typeparam name="TReturn">The combined type to return.</typeparam>
    /// <param name="sql">The SQL to execute for this query.</param>
    /// <param name="map">The function to map row types to the return type.</param>
    /// <param name="param">The parameters to use for this query.</param>
    /// <param name="transaction">The transaction to use for this query.</param>
    /// <param name="buffered">Whether to buffer the results in memory.</param>
    /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
    /// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
    /// <param name="commandType">Is it a stored proc or a batch?</param>
    /// <returns>An enumerable of <typeparamref name="TReturn" />.</returns>
    public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(string sql,
        Func<TFirst, TSecond, TReturn> map, object? param = null, IDbTransaction? transaction = null,
        bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);

    /// <summary>
    ///     Perform an asynchronous multi-mapping query with 2 input types.
    ///     This returns a single type, combined from the raw types via <paramref name="map" />.
    /// </summary>
    /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
    /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
    /// <typeparam name="TReturn">The combined type to return.</typeparam>
    /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
    /// <param name="command">The command to execute.</param>
    /// <param name="map">The function to map row types to the return type.</param>
    /// <returns>An enumerable of <typeparamref name="TReturn" />.</returns>
    public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(CommandDefinition command,
        Func<TFirst, TSecond, TReturn> map, string splitOn = "Id");

    /// <summary>
    ///     Perform an asynchronous multi-mapping query with 3 input types.
    ///     This returns a single type, combined from the raw types via <paramref name="map" />.
    /// </summary>
    /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
    /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
    /// <typeparam name="TThird">The third type in the recordset.</typeparam>
    /// <typeparam name="TReturn">The combined type to return.</typeparam>
    /// <param name="sql">The SQL to execute for this query.</param>
    /// <param name="map">The function to map row types to the return type.</param>
    /// <param name="param">The parameters to use for this query.</param>
    /// <param name="transaction">The transaction to use for this query.</param>
    /// <param name="buffered">Whether to buffer the results in memory.</param>
    /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
    /// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
    /// <param name="commandType">Is it a stored proc or a batch?</param>
    /// <returns>An enumerable of <typeparamref name="TReturn" />.</returns>
    public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(string sql,
        Func<TFirst, TSecond, TThird, TReturn> map, object? param = null, IDbTransaction? transaction = null,
        bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);

    /// <summary>
    ///     Perform an asynchronous multi-mapping query with 3 input types.
    ///     This returns a single type, combined from the raw types via <paramref name="map" />.
    /// </summary>
    /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
    /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
    /// <typeparam name="TThird">The third type in the recordset.</typeparam>
    /// <typeparam name="TReturn">The combined type to return.</typeparam>
    /// <param name="splitOn">The field we should split and read the second object from (default: "ID").</param>
    /// <param name="command">The command to execute.</param>
    /// <param name="map">The function to map row types to the return type.</param>
    /// <returns>An enumerable of <typeparamref name="TReturn" />.</returns>
    public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(
        CommandDefinition command, Func<TFirst, TSecond, TThird, TReturn> map, string splitOn = "Id");

    /// <summary>
    ///     Perform an asynchronous multi-mapping query with 4 input types.
    ///     This returns a single type, combined from the raw types via <paramref name="map" />.
    /// </summary>
    /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
    /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
    /// <typeparam name="TThird">The third type in the recordset.</typeparam>
    /// <typeparam name="TFourth">The fourth type in the recordset.</typeparam>
    /// <typeparam name="TReturn">The combined type to return.</typeparam>
    /// <param name="sql">The SQL to execute for this query.</param>
    /// <param name="map">The function to map row types to the return type.</param>
    /// <param name="param">The parameters to use for this query.</param>
    /// <param name="transaction">The transaction to use for this query.</param>
    /// <param name="buffered">Whether to buffer the results in memory.</param>
    /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
    /// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
    /// <param name="commandType">Is it a stored proc or a batch?</param>
    /// <returns>An enumerable of <typeparamref name="TReturn" />.</returns>
    public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(
        string sql, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, object? param = null,
        IDbTransaction? transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null,
        CommandType? commandType = null);

    /// <summary>
    ///     Perform an asynchronous multi-mapping query with 4 input types.
    ///     This returns a single type, combined from the raw types via <paramref name="map" />.
    /// </summary>
    /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
    /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
    /// <typeparam name="TThird">The third type in the recordset.</typeparam>
    /// <typeparam name="TFourth">The fourth type in the recordset.</typeparam>
    /// <typeparam name="TReturn">The combined type to return.</typeparam>
    /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
    /// <param name="command">The command to execute.</param>
    /// <param name="map">The function to map row types to the return type.</param>
    /// <returns>An enumerable of <typeparamref name="TReturn" />.</returns>
    public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(
        CommandDefinition command, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, string splitOn = "Id");

    /// <summary>
    ///     Perform an asynchronous multi-mapping query with 5 input types.
    ///     This returns a single type, combined from the raw types via <paramref name="map" />.
    /// </summary>
    /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
    /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
    /// <typeparam name="TThird">The third type in the recordset.</typeparam>
    /// <typeparam name="TFourth">The fourth type in the recordset.</typeparam>
    /// <typeparam name="TFifth">The fifth type in the recordset.</typeparam>
    /// <typeparam name="TReturn">The combined type to return.</typeparam>
    /// <param name="sql">The SQL to execute for this query.</param>
    /// <param name="map">The function to map row types to the return type.</param>
    /// <param name="param">The parameters to use for this query.</param>
    /// <param name="transaction">The transaction to use for this query.</param>
    /// <param name="buffered">Whether to buffer the results in memory.</param>
    /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
    /// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
    /// <param name="commandType">Is it a stored proc or a batch?</param>
    /// <returns>An enumerable of <typeparamref name="TReturn" />.</returns>
    public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(
        string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, object? param = null,
        IDbTransaction? transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null,
        CommandType? commandType = null);

    /// <summary>
    ///     Perform an asynchronous multi-mapping query with 5 input types.
    ///     This returns a single type, combined from the raw types via <paramref name="map" />.
    /// </summary>
    /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
    /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
    /// <typeparam name="TThird">The third type in the recordset.</typeparam>
    /// <typeparam name="TFourth">The fourth type in the recordset.</typeparam>
    /// <typeparam name="TFifth">The fifth type in the recordset.</typeparam>
    /// <typeparam name="TReturn">The combined type to return.</typeparam>
    /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
    /// <param name="command">The command to execute.</param>
    /// <param name="map">The function to map row types to the return type.</param>
    /// <returns>An enumerable of <typeparamref name="TReturn" />.</returns>
    public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(
        CommandDefinition command, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, string splitOn = "Id");

    /// <summary>
    ///     Perform an asynchronous multi-mapping query with 6 input types.
    ///     This returns a single type, combined from the raw types via <paramref name="map" />.
    /// </summary>
    /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
    /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
    /// <typeparam name="TThird">The third type in the recordset.</typeparam>
    /// <typeparam name="TFourth">The fourth type in the recordset.</typeparam>
    /// <typeparam name="TFifth">The fifth type in the recordset.</typeparam>
    /// <typeparam name="TSixth">The sixth type in the recordset.</typeparam>
    /// <typeparam name="TReturn">The combined type to return.</typeparam>
    /// <param name="sql">The SQL to execute for this query.</param>
    /// <param name="map">The function to map row types to the return type.</param>
    /// <param name="param">The parameters to use for this query.</param>
    /// <param name="transaction">The transaction to use for this query.</param>
    /// <param name="buffered">Whether to buffer the results in memory.</param>
    /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
    /// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
    /// <param name="commandType">Is it a stored proc or a batch?</param>
    /// <returns>An enumerable of <typeparamref name="TReturn" />.</returns>
    public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(
        string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map,
        object? param = null, IDbTransaction? transaction = null, bool buffered = true, string splitOn = "Id",
        int? commandTimeout = null, CommandType? commandType = null);

    /// <summary>
    ///     Perform an asynchronous multi-mapping query with 6 input types.
    ///     This returns a single type, combined from the raw types via <paramref name="map" />.
    /// </summary>
    /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
    /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
    /// <typeparam name="TThird">The third type in the recordset.</typeparam>
    /// <typeparam name="TFourth">The fourth type in the recordset.</typeparam>
    /// <typeparam name="TFifth">The fifth type in the recordset.</typeparam>
    /// <typeparam name="TSixth">The sixth type in the recordset.</typeparam>
    /// <typeparam name="TReturn">The combined type to return.</typeparam>
    /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
    /// <param name="command">The command to execute.</param>
    /// <param name="map">The function to map row types to the return type.</param>
    /// <returns>An enumerable of <typeparamref name="TReturn" />.</returns>
    public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(
        CommandDefinition command,
        Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, string splitOn = "Id");

    /// <summary>
    ///     Perform an asynchronous multi-mapping query with 7 input types.
    ///     This returns a single type, combined from the raw types via <paramref name="map" />.
    /// </summary>
    /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
    /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
    /// <typeparam name="TThird">The third type in the recordset.</typeparam>
    /// <typeparam name="TFourth">The fourth type in the recordset.</typeparam>
    /// <typeparam name="TFifth">The fifth type in the recordset.</typeparam>
    /// <typeparam name="TSixth">The sixth type in the recordset.</typeparam>
    /// <typeparam name="TSeventh">The seventh type in the recordset.</typeparam>
    /// <typeparam name="TReturn">The combined type to return.</typeparam>
    /// <param name="sql">The SQL to execute for this query.</param>
    /// <param name="map">The function to map row types to the return type.</param>
    /// <param name="param">The parameters to use for this query.</param>
    /// <param name="transaction">The transaction to use for this query.</param>
    /// <param name="buffered">Whether to buffer the results in memory.</param>
    /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
    /// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
    /// <param name="commandType">Is it a stored proc or a batch?</param>
    /// <returns>An enumerable of <typeparamref name="TReturn" />.</returns>
    public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(
        string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map,
        object? param = null, IDbTransaction? transaction = null, bool buffered = true, string splitOn = "Id",
        int? commandTimeout = null, CommandType? commandType = null);

    /// <summary>
    ///     Perform an asynchronous multi-mapping query with 7 input types.
    ///     This returns a single type, combined from the raw types via <paramref name="map" />.
    /// </summary>
    /// <typeparam name="TFirst">The first type in the recordset.</typeparam>
    /// <typeparam name="TSecond">The second type in the recordset.</typeparam>
    /// <typeparam name="TThird">The third type in the recordset.</typeparam>
    /// <typeparam name="TFourth">The fourth type in the recordset.</typeparam>
    /// <typeparam name="TFifth">The fifth type in the recordset.</typeparam>
    /// <typeparam name="TSixth">The sixth type in the recordset.</typeparam>
    /// <typeparam name="TSeventh">The seventh type in the recordset.</typeparam>
    /// <typeparam name="TReturn">The combined type to return.</typeparam>
    /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
    /// <param name="command">The command to execute.</param>
    /// <param name="map">The function to map row types to the return type.</param>
    /// <returns>An enumerable of <typeparamref name="TReturn" />.</returns>
    public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(
        CommandDefinition command,
        Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, string splitOn = "Id");

    /// <summary>
    ///     Perform an asynchronous multi-mapping query with an arbitrary number of input types.
    ///     This returns a single type, combined from the raw types via <paramref name="map" />.
    /// </summary>
    /// <typeparam name="TReturn">The combined type to return.</typeparam>
    /// <param name="sql">The SQL to execute for this query.</param>
    /// <param name="types">Array of types in the recordset.</param>
    /// <param name="map">The function to map row types to the return type.</param>
    /// <param name="param">The parameters to use for this query.</param>
    /// <param name="transaction">The transaction to use for this query.</param>
    /// <param name="buffered">Whether to buffer the results in memory.</param>
    /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
    /// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
    /// <param name="commandType">Is it a stored proc or a batch?</param>
    /// <returns>An enumerable of <typeparamref name="TReturn" />.</returns>
    public Task<IEnumerable<TReturn>> QueryAsync<TReturn>(string sql, Type[] types,
        Func<object[], TReturn> map, object? param = null, IDbTransaction? transaction = null, bool buffered = true,
        string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);

    /// <summary>
    ///     Execute a command that returns multiple result sets, and access each in turn.
    /// </summary>
    /// <param name="sql">The SQL to execute for this query.</param>
    /// <param name="param">The parameters to use for this query.</param>
    /// <param name="transaction">The transaction to use for this query.</param>
    /// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
    /// <param name="commandType">Is it a stored proc or a batch?</param>
    public Task<GridReader> QueryMultipleAsync(string sql, object? param = null,
        IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);

    /// <summary>
    ///     Execute a command that returns multiple result sets, and access each in turn.
    /// </summary>
    /// <param name="command">The command to execute for this query.</param>
    public Task<GridReader> QueryMultipleAsync(CommandDefinition command);

    /// <summary>
    ///     Execute parameterized SQL and return an <see cref="IDataReader" />.
    /// </summary>
    /// <param name="sql">The SQL to execute.</param>
    /// <param name="param">The parameters to use for this command.</param>
    /// <param name="transaction">The transaction to use for this command.</param>
    /// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
    /// <param name="commandType">Is it a stored proc or a batch?</param>
    /// <returns>An <see cref="IDataReader" /> that can be used to iterate over the results of the SQL query.</returns>
    /// <remarks>
    ///     This is typically used when the results of a query are not processed by Dapper, for example, used to fill a
    ///     <see cref="DataTable" />
    ///     or <see cref="T:DataSet" />.
    /// </remarks>
    /// <example>
    ///     <code>
    /// <![CDATA[
    /// DataTable table = new DataTable("MyTable");
    /// using (var reader = ExecuteReader(cnn, sql, param))
    /// {
    ///     table.Load(reader);
    /// }
    /// ]]>
    /// </code>
    /// </example>
    public Task<IDataReader> ExecuteReaderAsync(string sql, object? param = null,
        IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);

    /// <summary>
    ///     Execute parameterized SQL and return an <see cref="IDataReader" />.
    /// </summary>
    /// <param name="command">The command to execute.</param>
    /// <returns>An <see cref="IDataReader" /> that can be used to iterate over the results of the SQL query.</returns>
    /// <remarks>
    ///     This is typically used when the results of a query are not processed by Dapper, for example, used to fill a
    ///     <see cref="DataTable" />
    ///     or <see cref="T:DataSet" />.
    /// </remarks>
    public Task<IDataReader> ExecuteReaderAsync(CommandDefinition command);

    /// <summary>
    ///     Execute parameterized SQL and return an <see cref="IDataReader" />.
    /// </summary>
    /// <param name="command">The command to execute.</param>
    /// <param name="commandBehavior">The <see cref="CommandBehavior" /> flags for this reader.</param>
    /// <returns>An <see cref="IDataReader" /> that can be used to iterate over the results of the SQL query.</returns>
    /// <remarks>
    ///     This is typically used when the results of a query are not processed by Dapper, for example, used to fill a
    ///     <see cref="DataTable" />
    ///     or <see cref="T:DataSet" />.
    /// </remarks>
    public Task<IDataReader> ExecuteReaderAsync(CommandDefinition command,
        CommandBehavior commandBehavior);

    /// <summary>
    ///     Execute parameterized SQL that selects a single value.
    /// </summary>
    /// <param name="sql">The SQL to execute.</param>
    /// <param name="param">The parameters to use for this command.</param>
    /// <param name="transaction">The transaction to use for this command.</param>
    /// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
    /// <param name="commandType">Is it a stored proc or a batch?</param>
    /// <returns>The first cell returned, as <see cref="object" />.</returns>
    public Task<object?> ExecuteScalarAsync(string sql, object? param = null,
        IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);

    /// <summary>
    ///     Execute parameterized SQL that selects a single value.
    /// </summary>
    /// <typeparam name="T">The type to return.</typeparam>
    /// <param name="sql">The SQL to execute.</param>
    /// <param name="param">The parameters to use for this command.</param>
    /// <param name="transaction">The transaction to use for this command.</param>
    /// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
    /// <param name="commandType">Is it a stored proc or a batch?</param>
    /// <returns>The first cell returned, as <typeparamref name="T" />.</returns>
    public Task<T?> ExecuteScalarAsync<T>(string sql, object? param = null,
        IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);

    /// <summary>
    ///     Execute parameterized SQL that selects a single value.
    /// </summary>
    /// <param name="command">The command to execute.</param>
    /// <returns>The first cell selected as <see cref="object" />.</returns>
    public Task<object?> ExecuteScalarAsync(CommandDefinition command);

    /// <summary>
    ///     Execute parameterized SQL that selects a single value.
    /// </summary>
    /// <typeparam name="T">The type to return.</typeparam>
    /// <param name="command">The command to execute.</param>
    /// <returns>The first cell selected as <typeparamref name="T" />.</returns>
    public Task<T?> ExecuteScalarAsync<T>(CommandDefinition command);

    /// <summary>
    ///     Begin a transaction on this connection.
    /// </summary>
    /// <returns>An <see cref="IDbTransaction" /> that can be used to commit or rollback the transaction.</returns>
    public IDbTransaction BeginTransaction();

    /// <summary>
    ///     Begin a transaction on this connection with a specified isolation level.
    /// </summary>
    /// <param name="il">The isolation level to use for this transaction.</param>
    /// <returns>An <see cref="IDbTransaction" /> that can be used to commit or rollback the transaction.</returns>
    public IDbTransaction BeginTransaction(IsolationLevel il);

    /// <summary>
    ///     Change the database for this connection.
    /// </summary>
    /// <param name="databaseName">
    ///     The name of the database to change to. This must be a valid database name for the current
    ///     server connection.
    /// </param>
    public void ChangeDatabase(string databaseName);

    /// <summary>
    ///     Close the connection to the database.
    /// </summary>
    public void Close();

    /// <summary>
    ///     Create a new command for this connection.
    /// </summary>
    /// <returns>An <see cref="IDbCommand" /> that can be used to execute SQL commands against the database.</returns>
    public IDbCommand CreateCommand();

    /// <summary>
    ///     Open the connection to the database.
    /// </summary>
    public void Open();
}