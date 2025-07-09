using RB.Storage.API.Application;
using RB.Storage.API.Application.Extensions;

var storageApi = await StorageApi.BuildAsync();
storageApi.UseStorageApi();
await storageApi.RunAsync();
