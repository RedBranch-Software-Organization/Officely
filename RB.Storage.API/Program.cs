using System.Reflection;
using RB.Storage.API.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);
await builder.RunStorageApiAsync(Assembly.GetExecutingAssembly());